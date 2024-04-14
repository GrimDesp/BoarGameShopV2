
namespace BoardGameShop.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;

        public AuthService(HttpClient client, ILocalStorageService localStorage)
        {
            httpClient = client;
            this.localStorage = localStorage;
        }
        public async Task Registration(UserRegistrationDto userRegistrationDto)
        {
            try
            {
                var responce = await httpClient.PostAsJsonAsync("api/auth/registration", userRegistrationDto);
                if (responce.StatusCode == HttpStatusCode.BadRequest)
                    throw new Exception(await responce.Content.ReadAsStringAsync());
                if (responce.IsSuccessStatusCode)
                    return;
                throw new Exception("Щось пішло не так");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task Login(UserLoginDto userLoginDto)
        {
            try
            {
                var responce = await httpClient.PostAsJsonAsync("api/auth/login", userLoginDto);
                if (responce.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await localStorage.RemoveItemAsync("token");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
