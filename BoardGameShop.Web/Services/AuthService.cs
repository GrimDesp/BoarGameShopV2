
using System.Security.Claims;

namespace BoardGameShop.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authState;
        public string Username { get; set; } = string.Empty;

        public AuthService(HttpClient client, ILocalStorageService localStorage, AuthenticationStateProvider authState)
        {
            httpClient = client;
            this.localStorage = localStorage;
            this.authState = authState;
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
                    throw new Exception(await responce.Content.ReadAsStringAsync());
                }
                if (responce.IsSuccessStatusCode)
                {
                    await localStorage.SetItemAsync<string>("token", await responce.Content.ReadAsStringAsync());
                    await authState.GetAuthenticationStateAsync();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("token");
            await authState.GetAuthenticationStateAsync();
            Username = "";
        }
    }
}
