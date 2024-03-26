using BoardGameShop.Api.Repositories.Contracts;

namespace BoardGameShop.Api.Repositories
{
    public class BaseRepository<T> : IBaseRepo<T> where T : BaseEntity, new()
    {
        private bool disposedValue;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            Context = applicationDbContext;
            Table = Context.Set<T>();
            disposedValue = false;
        }

        public ApplicationDbContext Context { get; }
        public DbSet<T> Table { get; }
        public Task<int> Add(T entity, bool persiste = true)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRange(IEnumerable<T> entities, bool persiste = true)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id, byte[] timeStamp, bool persiste = true)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(T entity, bool persiste = true)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteRange(IEnumerable<T> entities, bool persiste = true)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(T entity, bool persiste = true)
        {
            throw new NotImplementedException();
        }
        private bool _IsDisposed;
        protected virtual void Dispose(bool disposing)
        {
            if (_IsDisposed)
                return;
            if (disposing)
            {
                if (disposedValue)
                {
                    Context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _IsDisposed = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~BaseRepository()
        {
            //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
