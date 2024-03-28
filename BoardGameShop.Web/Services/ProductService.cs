namespace BoardGameShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            try
            {
                var products = await httpClient.GetAsync("api/BoardGame");
                if (!products.IsSuccessStatusCode)
                {
                    string message = await products.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
                if (products.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<ProductDto>();
                }
                return await products.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>()
                    ?? Enumerable.Empty<ProductDto>();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
