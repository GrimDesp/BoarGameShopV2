
using System.Collections;

namespace BoardGameShop.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public IQueryable<Order> GetUserOrders(int userId)
        {
            return Table.Where(o => o.UserId == userId)
                .Include(o => o.VendorNavigation).AsQueryable();
        }
    }
}
