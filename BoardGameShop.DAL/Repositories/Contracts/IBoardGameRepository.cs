namespace BoardGameShop.DAL.Repositories.Contracts
{
    public interface IBoardGameRepository : IBaseRepo<BoardGame>
    {
        Task<IEnumerable<BoardGame>> GetAll();
    }
}
