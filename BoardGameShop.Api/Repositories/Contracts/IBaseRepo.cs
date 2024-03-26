namespace BoardGameShop.Api.Repositories.Contracts
{
    public interface IBaseRepo<T> : IDisposable where T : BaseEntity, new()
    {
        ApplicationDbContext Context { get; }
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity, bool persiste = true);
        Task<int> AddRange(IEnumerable<T> entities, bool persiste = true);
        Task<int> Update(T entity, bool persiste = true);
        Task<int> Delete(int id, byte[] timeStamp, bool persiste = true);
        Task<int> Delete(T entity, bool persiste = true);
        Task<int> DeleteRange(IEnumerable<T> entities, bool persiste = true);
        Task<int> SaveChanges();

    }
}
