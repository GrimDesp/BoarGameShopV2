namespace BoardGameShop.Web.Pages
{
    public partial class AllGamesBase : ComponentBase
    {
        [Inject]
        public HttpClient client { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public RequestFilterDto FilterDto { get; set; } = new RequestFilterDto();
        public int CurrentPage { get; set; } = 0;
        public int TotalPages { get; set; }
        public int PaginationSize { get; } = 2;
        public string? ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            FilterDto.CurrentPage = CurrentPage;
            FilterDto.ItemsPerPage = PaginationSize;
            try
            {
                var pageData = await ProductService.GetProductsAsync(FilterDto);
                Products = pageData.Products;
                TotalPages = pageData.TotalPages;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        public async Task ApplyFilter(RequestFormFilter formFilter)
        {
            FilterDto = new RequestFilterDto
            {
                MechanicIds = formFilter.MechanicIds,
                CategoryIds = formFilter.CategoryIds,
                ArtistIds = formFilter.ArtistIds,
                PublisherIds = formFilter.PublisherIds,
                AuthorsIds = formFilter.ArtistIds,
                MaxCost = formFilter.MaxCost,
                MinCost = formFilter.MinCost,
                MaxPlayers = formFilter.MaxPlayers,
                MinPlayers = formFilter.MinPlayers,
                ItemsPerPage = PaginationSize
            };
            CurrentPage = 0;
            FilterDto.CurrentPage = CurrentPage;
            await UpdateProducts(FilterDto);
        }
        public async Task UpdateProducts(RequestFilterDto filter)
        {
            Products = default;
            try
            {
                var pageData = await ProductService.GetProductsAsync(FilterDto);
                Products = pageData.Products;
                TotalPages = pageData.TotalPages;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        public Task OnPaginationClick(MouseEventArgs e, int page)
        {
            Console.WriteLine(page);
            return null;
        }
    }
}
