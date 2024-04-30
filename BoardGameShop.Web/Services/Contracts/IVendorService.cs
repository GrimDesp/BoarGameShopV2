namespace BoardGameShop.Web.Services.Contracts
{
    public interface IVendorService
    {
        Task<List<BoardgameStatDto>> GetBoardgames();
        Task SaveDeletionChanges(List<BoardgameDeleteChangeDto> boardgames);
        Task<BoardgameActionDto> GetBoardgameDetail(int gameId);
        Task<byte[]> UpdateBoardgame(BoardgameActionDto boardgame);
    }
}
