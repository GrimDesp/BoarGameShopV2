namespace BoardGameShop.Web.Services.Contracts
{
    public interface IAuthService
    {
        Task Login(UserLoginDto userLoginDto);
        Task Registration(UserRegistrationDto userRegistrationDto);
        Task Logout();
        string Username { get; set; }
    }
}
