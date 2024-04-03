namespace BoardGameShop.DAL.Repositories.Contracts
{
    public interface IAuthorRepository : IBaseRepo<Author>
    {
        Task<IEnumerable<Author>> GetAll();
    }
}
