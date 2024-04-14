namespace BoardGameShop.Web.Pages
{
    public partial class Login : ComponentBase
    {
        UserLoginDto _userLoginDto { get; set; } = new UserLoginDto
        {
            Password = string.Empty,
            Username = string.Empty,
        };
    }
}
