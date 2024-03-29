
namespace BoardGameShop.Web.Pages
{
    public partial class AllGamesBase : ComponentBase
    {
        public IEnumerable<ProductDto>? Products { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        public string? Message { get; set; }
        protected async override Task OnInitializedAsync()
        {
            try
            {
                Products = await ProductService.GetProductsAsync();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        protected string FormatPlayTime(ProductDto game)
        {
            if (game.MinPlayTime == null)
            {
                return " - ";
            }
            if (game.MaxPlayTime == null)
            {
                return $"{game.MinPlayTime}+";
            }
            return $"{game.MinPlayTime} - {game.MaxPlayTime}";
        }
        protected string FormatPlayers(ProductDto game)
        {
            if (game.MinPlayer == null)
            {
                return " - ";
            }
            if (game.MaxPlayer == null)
            {
                return $"{game.MinPlayer}+";
            }
            return $"{game.MinPlayer} - {game.MaxPlayer}";
        }
        protected string FormatAge(ProductDto game)
        {
            if (game.Age == null)
            {
                return " - ";
            }
            return $"{game.Age.Value}+";
        }
    }
}
