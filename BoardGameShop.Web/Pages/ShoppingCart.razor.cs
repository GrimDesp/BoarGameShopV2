
namespace BoardGameShop.Web.Pages
{
    public partial class ShoppingCart : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IShoppingCartLocalStorageService CartLocalStorageService { get; set; }
        public List<CartItem>? CartItems { get; set; }
        private int quartItemLimit = 10;
        private bool inDelete = false;
        protected async override Task OnInitializedAsync()
        {
            var items = await CartLocalStorageService.GetCartItemsAsync();
            CartItems = items.ToList();
        }
        private void OnIncrement_Click(int i)
        {
            CartItems[i].Quantity += 1;
            CartLocalStorageService.UpdateCartItem(CartItems[i]);
        }
        private void OnDecrement_Click(int i)
        {
            CartItems[i].Quantity -= 1;
            CartLocalStorageService.UpdateCartItem(CartItems[i]);
        }
        private async void OnClear_Click()
        {
            await CartLocalStorageService.Clear();
            NavigationManager.NavigateTo("");
        }
        private async void OnDelete_Click(int i)
        {
            inDelete = true;
            await CartLocalStorageService.RemoveFromCart(CartItems[i]);
            var items = await CartLocalStorageService.GetCartItemsAsync();
            CartItems = items.ToList();
            inDelete = false;
            StateHasChanged();
        }
    }
}
