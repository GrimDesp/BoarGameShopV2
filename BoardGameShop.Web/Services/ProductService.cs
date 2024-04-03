namespace BoardGameShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<ProductsPageDto> GetProductsAsync()
        {
            try
            {
                var products = await httpClient.GetAsync("api/BoardGame");
                if (!products.IsSuccessStatusCode)
                {
                    string message = await products.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
                return await products.Content.ReadFromJsonAsync<ProductsPageDto>() ?? new ProductsPageDto();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ProductsPageDto> GetProductsAsync(RequestFilterDto filter)
        {
            try
            {
                var products = await httpClient.PostAsJsonAsync<RequestFilterDto>("api/BoardGame/Filter", filter);
                if (!products.IsSuccessStatusCode)
                {
                    string message = await products.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
                return await products.Content.ReadFromJsonAsync<ProductsPageDto>() ?? new ProductsPageDto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<StatsForFilterDto> GetStatsForFilterAsync()
        {
            try
            {
                var stats = await httpClient.GetAsync("api/DataFilter/GetData");
                if (!stats.IsSuccessStatusCode)
                {
                    string message = await stats.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
                return await stats.Content.ReadFromJsonAsync<StatsForFilterDto>()
                    ?? new StatsForFilterDto();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
