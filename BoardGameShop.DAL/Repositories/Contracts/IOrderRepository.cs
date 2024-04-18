namespace BoardGameShop.DAL.Repositories.Contracts
{
    public interface IOrderRepository : IBaseRepo<Order>
    {
        IQueryable<Order> GetUserOrders(int userId);
    }
}
