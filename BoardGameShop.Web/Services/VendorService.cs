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
        public async Task SaveDeletionChanges(List<BoardgameDeleteChangeDto> boardgames)
        {
            try
            {
                var responce = await httpClient.PostAsJsonAsync("api/BoardGame/vendor/deletionUpdate", boardgames);
                if (responce.IsSuccessStatusCode)
                {
                    return;
                }
                if (responce.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Помилка авторизації : " + await responce.Content.ReadAsStringAsync());
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
