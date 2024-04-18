namespace BoardGameShop.DAL.Repositories.Contracts
{
    public interface IBoardGameRepository : IBaseRepo<Boardgame>
    {
        Task<IEnumerable<Boardgame>> GetAll();
        Task<int> CountPages(int itemPerPage);
        Task<(IEnumerable<Boardgame>, int)> GetByFilter(RequestFilterDto filterDto);
        Task<Boardgame> GetById(int id);
        IQueryable<Boardgame> GetByVendor(int vendorId);
    }
}
