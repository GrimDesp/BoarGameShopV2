namespace BoardGameShop.DAL.Repositories.Contracts
{
    public interface ICategoryRepository : IBaseRepo<Category>
    {
        Task<IEnumerable<Category>> GetAll();
    }
}
