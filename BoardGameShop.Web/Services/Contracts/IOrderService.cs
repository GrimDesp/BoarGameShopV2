namespace BoardGameShop.Web.Services.Contracts
{
    public interface IOrderService
    {
        Task<Dictionary<string, List<CartItem>>> GetItemsGroupByVendor();
    }
}
