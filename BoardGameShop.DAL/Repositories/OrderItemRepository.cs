namespace BoardGameShop.DAL.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {

        public OrderItemRepository(ApplicationDbContext applicationDbContext)
        {
            Context = applicationDbContext;
            Table = Context.Set<OrderItem>();
            disposedValue = false;
        }

        private bool disposedValue;
        public ApplicationDbContext Context { get; }
        public DbSet<OrderItem> Table { get; }
        public IQueryable<OrderItem> GetOrderItemsByVendor(int vendorId)
        {
            return Table.Include(oi => oi.BoardgameNavigation)
                .Where(oi => oi.BoardgameNavigation.VendorId == vendorId)
                .Include(oi => oi.OrderNavigation).AsQueryable();
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

        ~OrderItemRepository()
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
