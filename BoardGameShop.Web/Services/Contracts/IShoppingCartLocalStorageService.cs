namespace BoardGameShop.Web.Services.Contracts
{
    public interface IShoppingCartLocalStorageService
    {
        Func<Task> UpdateCounter { get; set; }
        Task<IEnumerable<CartItem>> GetCartItemsAsync();
        Task AddToCart(CartItem item);
        Task RemoveFromCart(CartItem item);
        Task Clear();
        Task UpdateCartItem(CartItem item);
        Task RemoveFromCart(int id);
        Task RemoveFromCartRange(IEnumerable<CartItem> items);
        Task RemoveFromCartByVendor(string name);
    }
}
