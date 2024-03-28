
namespace BoardGameShop.Web.Pages
{
    public partial class AllGames : ComponentBase
    {
        public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
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
    }
}
