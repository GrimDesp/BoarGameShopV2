namespace BoardGameShop.DAL.Repositories
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
        public async Task<int> Add(T entity, bool persiste = true)
        {
            await Table.AddAsync(entity);
            return persiste ? await SaveChanges() : 0;
        }

        public async Task<int> AddRange(IEnumerable<T> entities, bool persiste = true)
        {
            await Table.AddRangeAsync(entities);
            return persiste ? await SaveChanges() : 0;
        }

        public async Task<int> Delete(int id, byte[] timeStamp, bool persiste = true)
        {
            T entity = new T { Id = id, TimeSpam = timeStamp };
            Context.Entry(entity).State = EntityState.Deleted;
            return persiste ? await SaveChanges() : 0;
        }

        public async void Delete(T entity, bool persiste = true)
        {
            Table.Remove(entity);
            if (persiste)
                await SaveChanges();
            return;
        }

        public async void DeleteRange(IEnumerable<T> entities, bool persiste = true)
        {
            Table.RemoveRange(entities);
            if (persiste)
                await SaveChanges();
            return;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public async Task<T?> Find(int id)
        {
            return await Table.FindAsync(id);
        }
        public async Task<int> Update(T entity, bool persiste = true)
        {
            Table.Update(entity);
            return persiste ? await SaveChanges() : 0;
        }
        public async Task<int> SaveChanges()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("In base repo" + ex.Message, ex);
            }
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
