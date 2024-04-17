
namespace BoardGameShop.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly IShoppingCartLocalStorageService cartService;
        private readonly HttpClient httpClient;

        public OrderService(IShoppingCartLocalStorageService cartService, HttpClient httpClient)
        {
            this.cartService = cartService;
            this.httpClient = httpClient;
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
        public async Task RemoveOrderByVendor(string name)
        {
            await cartService.RemoveFromCartByVendor(name);
        }

        public async Task SendOrders(IEnumerable<OrderDto> orders)
        {
            try
            {
                var responce = await httpClient.PostAsJsonAsync("api/order/create", orders);
                if (responce.IsSuccessStatusCode)
                {
                    await cartService.Clear();
                    return;
                }
                throw new Exception(await responce.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
