
namespace BoardGameShop.Web.Services
{
    public class ShoppingCartLocalStorageService : IShoppingCartLocalStorageService, IDisposable
    {
        public ShoppingCartLocalStorageService(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }
        private const string key = "CartItems";
        private readonly ILocalStorageService localStorage;
        public Func<Task> UpdateCounter { get; set; }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync()
        {
            return await localStorage.GetItemAsync<IEnumerable<CartItem>>(key) ?? new List<CartItem>();
        }

        public async Task AddToCart(CartItem item)
        {
            var items = await localStorage.GetItemAsync<IEnumerable<CartItem>>(key) ?? new List<CartItem>();
            if (!items.Where(i => i.Id == item.Id).Any())
            {
                await localStorage.SetItemAsync(key, items.Append(item));
            }
            return;
        }
        public async Task UpdateCartItem(CartItem item)
        {
            await RemoveFromCart(item.Id);
            await AddToCart(item);
        }
        public async Task RemoveFromCart(CartItem item)
        {
            var items = await localStorage.GetItemAsync<IEnumerable<CartItem>>(key);
            if (items == null)
                return;
            var newItems = items.ToList();
            newItems.RemoveAll(i => i.Id == item.Id);
            await localStorage.SetItemAsync(key, newItems);
        }
        public async Task RemoveFromCart(int id)
        {
            var items = await localStorage.GetItemAsync<IEnumerable<CartItem>>(key);
            if (items == null)
                return;
            var listItems = items.ToList();
            listItems.RemoveAll(i => i.Id == id);
            await localStorage.SetItemAsync(key, listItems);
        }
        public async Task RemoveFromCartRange(IEnumerable<CartItem> items)
        {
            var cartItems = await localStorage.GetItemAsync<IEnumerable<CartItem>>(key);
            if (cartItems == null)
                return;
            await localStorage.SetItemAsync(key, cartItems.ToList().RemoveAll(i => items.Contains(i)));
        }
        public async Task RemoveFromCartByVendor(string name)
        {
            var cartItems = await localStorage.GetItemAsync<IEnumerable<CartItem>>(key);
            if (cartItems == null)
                return;
            await localStorage.SetItemAsync(key, cartItems.Where(i => i.VendorName != name));
        }
        public async Task Clear()
        {
            await localStorage.ClearAsync();
        }

        public async void Dispose()
        {
            await this.Clear();
        }


    }
}
