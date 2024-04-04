namespace BoardGameShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly IBoardGameRepository gameRepository;

        public BoardGameController(IBoardGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }
        // GET: api/<BoardGameController>
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await gameRepository.GetAll();
            if (games == null)
            {
                return NotFound();
            }
            return Ok(games.ConvertToDto());
        }
        [Produces("application/json")]
        [HttpPost("Filter")]
        public async Task<IActionResult> FindAll([FromBody] RequestFilterDto filter)
        {
            (var games, int totalPage) = await gameRepository.GetByFilter(filter);
            var gamesDto = games.ConvertToDto();
            var result = new ProductsPageDto { Products = gamesDto, TotalPages = totalPage };
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
