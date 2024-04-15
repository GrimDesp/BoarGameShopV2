using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGameShop.Web.Pages
{
    public partial class Registration : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAuthService auth { get; set; }
        public UserRegistrationDto User { get; set; } = new();
        private string _failRegMessage = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string SecondPassword { get; set; } = string.Empty;
        private async void Registration_OnClick()
        {
            if (Password != SecondPassword)
            {
                _failRegMessage = "Паролі не повторюються";
                return;
            }
            if (Password.Length <= 5)
            {
                _failRegMessage = "Пароль повинен містити 6 або більше символів";
                return;
            }
            if (User.Username.Length <= 2)
            {
                _failRegMessage = "Логін повинен містити 3 або більше символів";
                return;
            }
            if (User.Email.Length <= 4)
            {
                _failRegMessage = "Неправильна електронна почта";
                return;
            }
            try
            {
                User.Password = Password;
                await auth.Registration(User);
                NavigationManager.NavigateTo("login");
            }
            catch (Exception ex)
            {
                _failRegMessage = ex.Message;
                return;
            }

        }
    }
}
