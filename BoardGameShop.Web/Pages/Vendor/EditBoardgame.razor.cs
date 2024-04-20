namespace BoardGameShop.Web.Pages.Vendor
{
    public partial class EditBoardgame : ComponentBase
    {
        [Inject]
        public IVendorService VendorService { get; set; }
        public string? InitErrorMessage { get; set; }
        public BoardgameActionDto? Boardgame { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        [Parameter]
        public int Id { get; set; }
        protected async override Task OnInitializedAsync()
        {
            try
            {
                Boardgame = await VendorService.GetBoardgameDetail(Id);
            }
            catch (Exception ex)
            {
                InitErrorMessage = ex.Message;
            }
        }
    }
}
