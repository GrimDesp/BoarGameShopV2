namespace BoardGameShop.Web.Pages.Vendor.BoardgameActionForm
{
    public partial class BoardgameActionForm : ComponentBase
    {
        [Parameter]
        public string? ErrorMessage { get; set; }
        [Parameter]
        public BoardgameActionDto Boardgame { get; set; }
    }
}
