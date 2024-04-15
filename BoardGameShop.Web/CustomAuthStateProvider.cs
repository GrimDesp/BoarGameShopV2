
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace BoardGameShop.Web
{
    public class CustomAuthStateProvider : AuthenticationStateProvider, IDisposable
    {
        public string Username { get; set; } = string.Empty;
        private readonly ILocalStorageService localStorage;
        private readonly HttpClient http;

        public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient http)
        {
            AuthenticationStateChanged += OnAuthenticationStateChanged;
            this.localStorage = localStorage;
            this.http = http;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await localStorage.GetItemAsync<string>("token") ?? "";

            var identity = new ClaimsIdentity();
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            http.DefaultRequestHeaders.Authorization = null;
            if (jwtTokenHandler.CanReadToken(token))
            {
                var jwtToken = jwtTokenHandler.ReadJwtToken(token);
                identity = new ClaimsIdentity(jwtToken.Claims, "boardgameShop");
                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
        private async void OnAuthenticationStateChanged(Task<AuthenticationState> task)
        {
            var user = await task;
            if (user != null)
            {
                Username = user.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
            }
        }

        public void Dispose()
        {
            AuthenticationStateChanged -= OnAuthenticationStateChanged;
        }
    }
}
