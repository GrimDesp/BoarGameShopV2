namespace BoardGameShop.DAL.Repositories.Contracts
{
    public interface IPublisherRepository : IBaseRepo<Publisher>
    {
        Task<IEnumerable<Publisher>> GetAll();
    }
}
