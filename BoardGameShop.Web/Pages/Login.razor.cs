namespace BoardGameShop.Web.Pages
{
    public partial class Login : ComponentBase
    {
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
            if (User.Password.Length <= 5)
            {
                _failRegMessage = "Пароль повинен містити 6 або більше символів";
                return;
            }
            if (User.Username.Length <= 2)
            {
                _failRegMessage = "Логін повинен містити 3 або більше символів";
                return;
            }
            try
            {
                await auth.Login(User);
                NavigationManager.NavigateTo("");
            }
            catch (Exception ex)
            {
                _failRegMessage = ex.Message;
                return;
            }
        }
    }
}
