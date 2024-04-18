namespace BoardGameShop.Web.Services.Contracts
{
    public interface IOrderService
    {
        Task<Dictionary<string, List<CartItem>>> GetItemsGroupByVendor();
        Task RemoveOrderByVendor(string name);
        Task SendOrders(IEnumerable<CreateOrderDto> orders);
        Task<IEnumerable<OrderDetailsDto>> GetUserOrders();
    }
}
