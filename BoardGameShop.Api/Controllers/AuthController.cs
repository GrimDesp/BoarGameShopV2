using Azure.Core;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace BoardGameShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        [HttpPost("registration")]
        public async Task<IActionResult> UserRegistration(UserRegistrationDto request)
        {
            bool isGood = await CheckRegistrationInputs(request);
            if (!isGood)
            {
                return BadRequest("Уже існує або неправильний пароль чи e-mail");
            }
            var user = new User
            {
                Email = request.Email,
                Username = request.Username
            };
            (user.PasswordHash, user.PasswordSalt) = CreatePasswordHash(request.Password);
            await _userRepository.Add(user);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDto request)
        {
            var users = _userRepository.GetUserByUsername(request.Username)
                .Select(cd => new User
                {
                    PasswordHash = cd.PasswordHash,
                    PasswordSalt = cd.PasswordSalt,
                    Username = cd.Username,
                    UserRole = cd.UserRole
                });
            if (!users.Any() || users.Count() != 1)
            {
                return Unauthorized("Неправильний логін або пароль");
            }
            var user = await users.FirstAsync();
            bool verifycation = VerifyUser(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!verifycation)
            {
                return Unauthorized("Неправильний логін або пароль");
            }
            var token = CreateToken(user);
            return Ok(token);
        }
        private async Task<bool> CheckRegistrationInputs(UserRegistrationDto registrationDto)
        {
            bool isExist = await _userRepository.GetUserQueryable()
            .Where(cd => cd.Username == registrationDto.Username || cd.Email == registrationDto.Email)
                .AnyAsync();
            if (isExist)
                return false;
            if (registrationDto.Password.Length <= 5)
                return false;
            if (registrationDto.Username.Length <= 2)
                return false;
            if (!IsValidEmailAddress(registrationDto.Email))
                return false;
            return true;
        }
        private bool IsValidEmailAddress(string address)
            => address != null && new EmailAddressAttribute().IsValid(address);
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Role, user.UserRole.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        bool VerifyUser(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password)
        {
            byte[] passwordSalt;
            byte[] passwordHash;
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return (passwordHash, passwordSalt);
        }
    }
}
