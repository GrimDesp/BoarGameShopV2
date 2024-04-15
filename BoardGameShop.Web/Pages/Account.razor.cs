
namespace BoardGameShop.Web.Pages
{
    public partial class Account : ComponentBase
    {
        [Inject]
        public NavigationManager navManager { get; set; }
        [Inject]
        public IAuthService authService { get; set; }
        public UserUpdateDto? user { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        private string errorMessage = string.Empty;
        private string succesMessage = string.Empty;
        private bool inRequest = false;
        protected async override Task OnInitializedAsync()
        {
            user = await authService.GetUserData() ?? new UserUpdateDto();
        }
        private async void Submit_OnClick()
        {
            inRequest = true;
            succesMessage = string.Empty;
            errorMessage = string.Empty;
            if (user.Firstname?.Length > 50)
            {
                errorMessage = "Ім`я більше 50 символів";
                inRequest = false;
                return;
            }
            if (user.Lastname?.Length > 50)
            {
                errorMessage = "Фамілія більше 50 символів";
                inRequest = false;
                return;
            }
            if (user.Secondname?.Length > 50)
            {
                errorMessage = "По батькові більше 50 символів";
                inRequest = false;
                return;
            }
            if (user.PhoneNumber?.Length > 15)
            {
                errorMessage = "Номер більше 15 символів";
                inRequest = false;
                return;
            }
            try
            {
                await authService.UpdateUser(user);
                succesMessage = "Дані змінено успішно";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                inRequest = false;
                StateHasChanged();
            }
        }
    }
}
