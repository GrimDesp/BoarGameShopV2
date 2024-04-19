namespace BoardGameShop.Web.Pages.Vendor
{
    public partial class Boardgames : ComponentBase
    {
        [Inject]
        public IVendorService VendorService { get; set; }
        public string? InitErrorMessage { get; set; }
        List<BoardgameStatDto>? BoardgamesInfo { get; set; }
        public string? ErrorMessage { get; private set; }

        private Dictionary<int, bool> ChangingDict = new();
        private string requestStatusStyle = "";
        protected override async Task OnInitializedAsync()
        {
            try
            {
                BoardgamesInfo = await VendorService.GetBoardgames();
                foreach (var item in BoardgamesInfo)
                {
                    ChangingDict.Add(item.Id, false);
                }
            }
            catch (Exception ex)
            {
                InitErrorMessage = ex.Message;
            }
        }
        private async void DeletionChange_OnClick(int gameId)
        {
            try
            {
                ChangingDict[gameId] = !ChangingDict[gameId];
                int index = BoardgamesInfo.FindIndex(item => item.Id == gameId);
                BoardgamesInfo[index].IsDeleted = !BoardgamesInfo[index].IsDeleted;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        private async void SaveChanges_OnClick()
        {
            ErrorMessage = null;
            requestStatusStyle = "disabled";
            try
            {
                await VendorService.SaveDeletionChanges(
                    BoardgamesInfo.Where(g => ChangingDict[g.Id])
                    .Select(g => new BoardgameDeleteChangeDto
                    {
                        Id = g.Id,
                        TimeStamp = g.TimeStamp,
                        IsDeleted = g.IsDeleted
                    }).ToList());
                foreach (var item in ChangingDict)
                {
                    ChangingDict[item.Key] = false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                requestStatusStyle = "";
                StateHasChanged();
            }
        }
    }
}
