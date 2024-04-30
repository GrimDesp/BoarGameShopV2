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
        public StatsForFilterDto? EntitiesData { get; set; }
        private string? SuccessMessage { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        private bool updateSuccess = false;
        protected async override Task OnInitializedAsync()
        {
            try
            {
                Boardgame = await VendorService.GetBoardgameDetail(Id);
                EntitiesData = await ProductService.GetStatsForFilterAsync();
            }
            catch (Exception ex)
            {
                InitErrorMessage = ex.Message;
            }
        }
        protected async Task UpdateBoardgame(BoardgameActionDto boardgame)
        {
            try
            {
                SuccessMessage = string.Empty;
                StateHasChanged();
                var timestamp = await VendorService.UpdateBoardgame(boardgame);
                updateSuccess = true;
                SuccessMessage = "Успішно збережено";
                Boardgame = boardgame;
                Boardgame.TimeStamp = timestamp;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                updateSuccess = false;
                ErrorMessage = ex.Message;
            }
        }
    }
}
