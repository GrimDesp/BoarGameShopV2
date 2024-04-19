namespace BoardGameShop.DAL.Repositories
{
    public class VendorEmployeeRepository : IVendorEmployeeRepository
    {
        public VendorEmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            Context = applicationDbContext;
            Table = Context.Set<VendorEmployee>();
            disposedValue = false;
        }

        public async Task<int> GetVendorId(int employeeId)
        {
            var employee = await Table.Include(e => e.VendorNavigation).Include(e => e.UserNavigation)
                .Where(e => e.UserId == employeeId).Select(e => new VendorEmployee
                {
                    VendorNavigation = new Vendor { Id = e.VendorNavigation.Id },
                    UserNavigation = new User { Id = e.UserNavigation.Id, UserRole = e.UserNavigation.UserRole },
                }).SingleAsync();
            return employee.UserNavigation.UserRole == Role.Vendor ? employee.VendorNavigation.Id
                 : throw new Exception("Такого робочого немає");
        }

        private bool disposedValue;
        public ApplicationDbContext Context { get; }
        public DbSet<VendorEmployee> Table { get; }



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

        ~VendorEmployeeRepository()
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
