
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace BoardGameShop.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly CustomAuthStateProvider authState;
        private readonly NavigationManager navManager;

        public AuthService(HttpClient client, ILocalStorageService localStorage,
            CustomAuthStateProvider authState, NavigationManager navManager)
        {
            httpClient = client;
            this.localStorage = localStorage;
            this.authState = authState;
            this.navManager = navManager;
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
            navManager.NavigateTo("");
        }

        public async Task<UserPersonalInfoDto> GetUserData()
        {
            try
            {
                var responce = await httpClient.GetAsync("api/auth/userData");
                if (responce.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await localStorage.RemoveItemAsync("token");
                    throw new Exception(await responce.Content.ReadAsStringAsync());
                }
                if (responce.IsSuccessStatusCode)
                {
                    var user = await responce.Content.ReadFromJsonAsync<UserPersonalInfoDto>();
                    return user;
                }
                throw new Exception("Щось пішло не так");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUser(UserPersonalInfoDto userUpdateDto)
        {
            try
            {
                var responce = await httpClient.PostAsJsonAsync("api/auth/updateUser", userUpdateDto);
                if (responce.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Невалідні дані користувача");
                }
                if (responce.StatusCode == HttpStatusCode.BadRequest)
                {
                    var errorMessage = "Помилка від сервера : ";
                    errorMessage += await responce.Content.ReadAsStringAsync();
                    throw new Exception(errorMessage);
                }
                if (!responce.IsSuccessStatusCode)
                {
                    throw new Exception("Щось пішло не так : " + await responce.Content.ReadAsStringAsync());
                }
                return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
