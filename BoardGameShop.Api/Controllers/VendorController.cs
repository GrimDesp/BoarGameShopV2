using BoardGameShop.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(Role.Vendor))]
    public class VendorController : ControllerBase
    {
        private readonly IBoardGameRepository gameRepo;
        private readonly IVendorEmployeeRepository vendorEmpRepo;

        public VendorController(IBoardGameRepository gameRepo, IVendorEmployeeRepository vendorEmpRepo)
        {
            this.gameRepo = gameRepo;
            this.vendorEmpRepo = vendorEmpRepo;
        }
        [HttpGet("games")]
        [Produces("application/json")]
        public async Task<ActionResult<List<BoardgameStatDto>>> FindGamesByVendor()
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid));
                int id = await vendorEmpRepo.GetVendorId(userId);
                var querybleOrder = gameRepo.GetOrderItemsByVendor(id).Include(g => g.PublisherNavigation)
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
            catch (InvalidCastException ex)
            {
                return Unauthorized("Неможливо отримати ідентифікатор користувача : " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized("Недостатньо прав в користувача : " + ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Помилка : " + ex.Message + ex.InnerException?.Message);
            }
        }

        [HttpPost("deletionGameUpdate")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletionChangesFromVendor(List<BoardgameDeleteChangeDto> request)
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid));
                int id = await vendorEmpRepo.GetVendorId(userId);
                var games = await gameRepo.GetByVendor(id)
                    .Where(g => request.Select(r => r.Id).Contains(g.Id))
                    .ToListAsync();
                games.ForEach(game => game.IsDeleted = request.Where(r => r.Id == game.Id).Single().IsDeleted);
                await gameRepo.UpdateRange(games);
                return Ok();
            }
            catch (InvalidCastException ex)
            {
                return Unauthorized("Неможливо отримати ідентифікатор користувача : " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized("Недостатньо прав в користувача : " + ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException?.Message);
            }
        }
        [HttpGet("games/{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<BoardgameActionDto>> GetActionBoardgame(int id)
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid));
                int vendorId = await vendorEmpRepo.GetVendorId(userId);
                var game = await gameRepo.GetByVendor(vendorId)
                    .Include(g => g.Categories)
                    .Include(g => g.Mechanics)
                    .Include(g => g.Authors)
                    .Include(g => g.Artists)
                    .Include(g => g.PublisherNavigation)
                    .Select(g => new Boardgame
                    {
                        Id = g.Id,
                        Age = g.Age,
                        Artists = g.Artists.Select(a => new Artist { FullName = a.FullName, Id = a.Id }).ToList(),
                        Authors = g.Authors.Select(a => new Author { Id = a.Id, FullName = a.FullName }).ToList(),
                        Categories = g.Categories.Select(c => new Category { Id = c.Id, Name = c.Name }).ToList(),
                        Mechanics = g.Mechanics.Select(m => new Mechanic { Id = m.Id, Name = m.Name }).ToList(),
                        PublisherNavigation = new Publisher { Name = g.PublisherNavigation.Name, Id = g.PublisherNavigation.Id },
                        Description = g.Description,
                        Discount = g.Discount,
                        FullPrice = g.FullPrice,
                        IsDeleted = g.IsDeleted,
                        MaxPlayer = g.MaxPlayer,
                        MaxPlayTime = g.MaxPlayTime,
                        MinPlayer = g.MinPlayer,
                        MinPlayTime = g.MinPlayTime,
                        Name = g.Name,
                        Quantity = g.Quantity,
                        TimeSpam = g.TimeSpam,
                    })
                    .SingleAsync(g => g.Id == id);
                return Ok(game.ConvertToActionDto());
            }
            catch (InvalidCastException ex)
            {
                return Unauthorized("Неможливо отримати ідентифікатор користувача : " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized("Недостатньо прав в користувача : " + ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Помилка : " + ex.Message + ex.InnerException?.Message);
            }
            throw new NotImplementedException();
        }
    }
}
