
namespace BoardGameShop.Web.Pages
{
    public partial class ProductDetails : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        [Inject]
        public IShoppingCartLocalStorageService cartLocalStorageService { get; set; }
        [Parameter]
        public int Id { get; set; }
        public ProductDetailsDto Product { get; set; }
        public string? ErrorMessage { get; set; }
        public string MinMaxTime => FormatPlayTime();
        public string MinMaxPlayer => FormatPlayers();
        public string Age => FormatAge();
        public int CurrentImage { get; set; } = 0;
        protected async override Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetProductById(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected string FormatPlayTime()
        {
            if (Product.MinPlayTime == null)
            {
                return " - ";
            }
            if (Product.MaxPlayTime == null)
            {
                return $"{Product.MinPlayTime}+";
            }
            return $"{Product.MinPlayTime} - {Product.MaxPlayTime}";
        }
        protected string FormatPlayers()
        {
            if (Product.MinPlayer == null)
            {
                return " - ";
            }
            if (Product.MaxPlayer == null)
            {
                return $"{Product.MinPlayer}+";
            }
            return $"{Product.MinPlayer} - {Product.MaxPlayer}";
        }
        protected string FormatAge()
        {
            if (Product.Age == null)
            {
                return " - ";
            }
            return $"{(byte)Product.Age.Value}+";
        }
        private async Task AddToCart(CartItem item)
        {
            await cartLocalStorageService.AddToCart(item);
            NavigationManager.NavigateTo("/cart");
        }
    }
}
