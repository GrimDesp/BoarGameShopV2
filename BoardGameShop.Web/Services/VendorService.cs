namespace BoardGameShop.Web.Services
{
    public class VendorService : IVendorService
    {
        private readonly HttpClient httpClient;

        public VendorService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<BoardgameStatDto>> GetBoardgames()
        {
            try
            {
                var responce = await httpClient.GetAsync("api/BoardGame/vendor/games");
                if (responce.IsSuccessStatusCode)
                {
                    return await responce.Content.ReadFromJsonAsync<List<BoardgameStatDto>>()
                        ?? new List<BoardgameStatDto>();
                }
                throw new Exception(await responce.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка від сервера : " + ex.Message);
            }
        }
    }
}
