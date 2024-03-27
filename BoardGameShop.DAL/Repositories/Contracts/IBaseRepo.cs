namespace BoardGameShop.DAL.Repositories.Contracts
{
    public interface IBaseRepo<T> : IDisposable where T : BaseEntity, new()
    {
        ApplicationDbContext Context { get; }
        Task<T?> Find(int id);
        Task<int> Add(T entity, bool persiste = true);
        Task<int> AddRange(IEnumerable<T> entities, bool persiste = true);
        Task<int> Update(T entity, bool persiste = true);
        Task<int> Delete(int id, byte[] timeStamp, bool persiste = true);
        void Delete(T entity, bool persiste = true);
        void DeleteRange(IEnumerable<T> entities, bool persiste = true);
        Task<int> SaveChanges();

    }
}
