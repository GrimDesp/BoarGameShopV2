namespace BoardGameShop.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly IShoppingCartLocalStorageService cartService;

        public OrderService(IShoppingCartLocalStorageService cartService)
        {
            this.cartService = cartService;
        }
        public async Task<Dictionary<string, List<CartItem>>> GetItemsGroupByVendor()
        {
            var result = new Dictionary<string, List<CartItem>>();
            var allItems = await cartService.GetCartItemsAsync();
            if (allItems == null || !allItems.Any())
            {
                throw new Exception("Кошик порожній");
            }
            var vendors = allItems.Select(c => c.VendorName).Distinct();
            if (!vendors.Any())
            {
                throw new Exception("Кошик порожній");
            }
            foreach (var name in vendors)
            {
                result.Add(name, allItems.Where(i => i.VendorName == name).ToList());
            }
            return result;
        }
    }
}
