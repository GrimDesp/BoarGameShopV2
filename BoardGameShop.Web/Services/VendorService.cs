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
                var responce = await httpClient.GetAsync("api/Vendor/games");
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
                var responce = await httpClient.PutAsJsonAsync("api/Vendor/deletionGameUpdate", boardgames);
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
        public async Task<BoardgameActionDto> GetBoardgameDetail(int gameId)
        {
            try
            {
                var responce = await httpClient.GetAsync($"api/Vendor/games/{gameId}");
                if (responce.IsSuccessStatusCode)
                {
                    return await responce.Content.ReadFromJsonAsync<BoardgameActionDto>();
                }
                throw new Exception(await responce.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка від сервера : " + ex.Message);
            }
        }
        public async Task<byte[]> UpdateBoardgame(BoardgameActionDto boardgame)
        {
            try
            {
                var responce = await httpClient.PutAsJsonAsync("api/Vendor/boardgame", boardgame);
                if (responce.IsSuccessStatusCode)
                {
                    return await responce.Content.ReadFromJsonAsync<byte[]>()
                        ?? throw new Exception("Не вдалось отримати мітку часу від серверу, перезагрузіть сторінку");
                }
                if (responce.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Помилка авторизації : " + await responce.Content.ReadAsStringAsync());
                }
                throw new Exception(await responce.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
