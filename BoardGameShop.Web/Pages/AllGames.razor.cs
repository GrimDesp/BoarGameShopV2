﻿namespace BoardGameShop.Web.Pages
{
    public partial class AllGamesBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        public IEnumerable<ProductDto>? Products { get; set; }
        public RequestFilterDto FilterDto { get; set; } = new RequestFilterDto();
        public int CurrentPage { get; set; } = 0;
        public int TotalPages { get; set; }
        public int PaginationSize { get; } = 2;
        public string? ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            FilterDto.CurrentPage = CurrentPage;
            FilterDto.ItemsPerPage = PaginationSize;
            await UpdateProducts();
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
            await UpdateProducts();
        }
        public async Task UpdateProducts()
        {
            Products = null;
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
        public async Task OnPaginationClick(int page)
        {
            CurrentPage = page;
            FilterDto.CurrentPage = page;
            await UpdateProducts();
        }
    }
}
