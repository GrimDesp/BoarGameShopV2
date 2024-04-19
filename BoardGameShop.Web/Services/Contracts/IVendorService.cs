namespace BoardGameShop.Web.Services.Contracts
{
    public interface IVendorService
    {
        Task<List<BoardgameStatDto>> GetBoardgames();
    }
}
