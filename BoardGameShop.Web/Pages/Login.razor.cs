namespace BoardGameShop.Web.Pages
{
    public partial class Login : ComponentBase
    {
        private bool inRequest = false;
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAuthService auth { get; set; }
        private string _failRegMessage = string.Empty;
        UserLoginDto User { get; set; } = new UserLoginDto
        {
            Password = string.Empty,
            Username = string.Empty,
        };
        private async void Login_OnClick()
        {
            inRequest = true;
            if (User.Password.Length <= 5)
            {
                _failRegMessage = "Пароль повинен містити 6 або більше символів";
                inRequest = false;
                return;
            }
            if (User.Username.Length <= 2)
            {
                _failRegMessage = "Логін повинен містити 3 або більше символів";
                inRequest = false;
                return;
            }
            try
            {
                await auth.Login(User);
                inRequest = false;
                NavigationManager.NavigateTo("");
            }
            catch (Exception ex)
            {
                _failRegMessage = ex.Message;
                inRequest = false;
                StateHasChanged();
            }
        }
    }
}
