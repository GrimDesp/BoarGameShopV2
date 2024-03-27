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

        // GET api/<BoardGameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BoardGameController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BoardGameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BoardGameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
