namespace BoardGameShop.Web.Pages.Vendor
{
    public partial class Boardgames : ComponentBase
    {
        [Inject]
        public IVendorService VendorService { get; set; }
        public string? InitErrorMessage { get; set; }
        List<BoardgameStatDto>? BoardgamesInfo { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                BoardgamesInfo = await VendorService.GetBoardgames();
            }
            catch (Exception ex)
            {
                InitErrorMessage = ex.Message;
            }
        }
    }
}
