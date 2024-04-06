namespace BoardGameShop.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductsPageDto> GetProductsAsync();
        Task<ProductsPageDto> GetProductsAsync(RequestFilterDto filter);
        Task<StatsForFilterDto> GetStatsForFilterAsync();
        Task<ProductDetailsDto> GetProductById(int id);
    }
}
