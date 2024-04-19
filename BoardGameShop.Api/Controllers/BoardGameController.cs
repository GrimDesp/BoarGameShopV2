using Microsoft.AspNetCore.Authorization;
namespace BoardGameShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly IBoardGameRepository gameRepository;
        private readonly IOrderRepository orderRepo;
        private readonly IVendorEmployeeRepository vendorEmpRepo;

        public BoardGameController(IBoardGameRepository gameRepository,
            IOrderRepository orderRepo, IVendorEmployeeRepository vendorEmpRepo)
        {
            this.gameRepository = gameRepository;
            this.orderRepo = orderRepo;
            this.vendorEmpRepo = vendorEmpRepo;
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
        [HttpGet("vendor/games"), Authorize(Roles = nameof(Role.Vendor))]
        [Produces("application/json")]
        public async Task<IActionResult> FindGamesByVendor()
        {
            bool isConvert = int.TryParse(User.FindFirstValue(ClaimTypes.Sid), out int userId);
            if (!isConvert)
            {
                return Unauthorized("Не вдалось отримати id користувача");
            }
            try
            {
                int id = await vendorEmpRepo.GetVendorId(userId);
                var querybleOrder = gameRepository.GetOrderItemsByVendor(id).Include(g => g.PublisherNavigation)
                    .Select(g => new BoardgameStatDto
                    {
                        Id = g.Id,
                        Name = g.Name,
                        TimeStamp = g.TimeSpam,
                        PublisherName = g.PublisherNavigation.Name,
                        Discount = g.Discount,
                        FullPrice = g.FullPrice,
                        IsDeleted = g.IsDeleted,
                        Quantity = g.Quantity,
                        ItemSold = g.OrderItems.Where(oi => oi.OrderNavigation.CompletionDate != null).Sum(oi => oi.Qty),
                        Earned = g.OrderItems.Where(oi => oi.OrderNavigation.CompletionDate != null).Sum(oi => oi.ItemCost)
                    });
                return Ok(await querybleOrder.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Помилка : " + ex.Message + ex.InnerException?.Message);
            }
        }

        [HttpPost("vendor/deletionUpdate"), Authorize(Roles = nameof(Role.Vendor))]
        [Produces("application/json")]
        public async Task<IActionResult> DeletionChangesFromVendor(List<BoardgameDeleteChangeDto> request)
        {
            bool isConvert = int.TryParse(User.FindFirstValue(ClaimTypes.Sid), out int userId);
            if (!isConvert)
            {
                return Unauthorized("Не вдалось отримати id користувача");
            }
            try
            {
                int id = await vendorEmpRepo.GetVendorId(userId);
                var games = await gameRepository.GetByVendor(id)
                    .Where(g => request.Select(r => r.Id).Contains(g.Id))
                    .ToListAsync();
                games.ForEach(game => game.IsDeleted = request.Where(r => r.Id == game.Id).Single().IsDeleted);
                await gameRepository.UpdateRange(games);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException?.Message);
                throw;
            }
        }
    }
}
