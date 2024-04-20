using Microsoft.AspNetCore.Authorization;
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
        [Produces("application/json")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> FindSingle(int id)
        {
            var game = await gameRepository.GetById(id);
            if (game == null)
                return NotFound();
            return Ok(game.ConvertToDto());
        }

    }
}
