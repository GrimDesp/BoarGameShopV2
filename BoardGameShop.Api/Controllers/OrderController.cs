using Microsoft.AspNetCore.Authorization;

namespace BoardGameShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBoardGameRepository gameRepo;
        private readonly IOrderRepository orderRepo;
        private readonly IUserRepository userRepo;

        public OrderController(IBoardGameRepository gameRepo, IOrderRepository orderRepo, IUserRepository userRepo)
        {
            this.gameRepo = gameRepo;
            this.orderRepo = orderRepo;
            this.userRepo = userRepo;
        }
        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateOrders(IEnumerable<CreateOrderDto> request)
        {
            try
            {
                if (request == null || request.Count() <= 0)
                {
                    return BadRequest();
                }
                bool isParse = Int32.TryParse(User.FindFirstValue(ClaimTypes.Sid), out int id);
                if (!isParse)
                {
                    return BadRequest("Не вдалось зчитати айді з токена");
                }
                string username = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await userRepo.Find(id);
                if (user.Username != username)
                {
                    return Unauthorized("Користувача не знайдено");
                }
                foreach (var order in request)
                {
                    var games = await gameRepo.GetByVendor(order.VendorId)
                        .Where(g => order.Items.Select(i => i.Id).Contains(g.Id))
                        .ToListAsync();
                    foreach (var item in order.Items)
                    {
                        var game = games.SingleOrDefault(g => g.Id == item.Id);
                        if (game == null)
                        {
                            return BadRequest("Один з товарів не існує");
                        }
                        if (!game.TimeSpam.SequenceEqual(item.TimeStamp))
                        {
                            //new { game.TimeSpam, item.TimeStamp, game.Id, orderId = item.Id }
                            return BadRequest($"Неправильна часова мітка у {game.Name}, дані не актуальні");
                        }
                        if (game.Quantity < item.Qty)
                        {
                            return BadRequest($"Недостатньо {game.Name} на складі");
                        }
                        games[games.IndexOf(game)].Quantity -= item.Qty;

                    }
                    var orderItems = ConvertToEntity(order.Items).ToList();
                    orderItems.ForEach(oi => oi.ItemCost = GetPrice(games.Single(g => g.Id == oi.ItemId), oi.Qty));
                    var orderEntity = new Order
                    {
                        UserId = id,
                        VendorId = order.VendorId,
                        DeliveryAddress = order.DeliveryAddress,
                        Firstname = order.User.Firstname,
                        Lastname = order.User.Lastname,
                        Secondname = order.User.Secondname,
                        OrderItems = orderItems,
                        PhoneNumber = order.User.PhoneNumber,
                        PaymentStatus = PaymentStatus.NotPaid,
                        CreationDate = DateTime.UtcNow,
                        MessageFromUser = "",
                        OrderStatus = OrderStatus.Created
                    };
                    await orderRepo.Add(orderEntity, persiste: false);
                    await gameRepo.UpdateRange(games, persiste: false);
                }
                await orderRepo.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException?.Message);
            }
        }
        [HttpGet("userOrders")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OrderDetailsDto>>> GetUserOrders()
        {
            try
            {
                //TODO винести провірку юзура і получання айді в отдельний клас. Повторюється в CreateOrders()
                bool isParse = Int32.TryParse(User.FindFirstValue(ClaimTypes.Sid), out int id);
                if (!isParse)
                {
                    return BadRequest("Не вдалось зчитати айді з токена");
                }
                string username = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await userRepo.Find(id);
                if (user.Username != username)
                {
                    return Unauthorized("Користувача не знайдено");
                }
                var quryableOrder = orderRepo.GetUserOrders(id);
                var result = await quryableOrder.Select(qo => new OrderDetailsDto
                {
                    OrderId = qo.Id,
                    VendorName = qo.VendorNavigation.Name,
                    DeliveryAddress = qo.DeliveryAddress,
                    MessageFromUser = qo.MessageFromUser,
                    Items = qo.OrderItems.ConvertToDto().ToList(),
                    User = new UserPersonalInfoDto
                    {
                        Firstname = qo.Firstname,
                        Lastname = qo.Lastname,
                        PhoneNumber = qo.PhoneNumber,
                        Secondname = qo.Secondname
                    },
                    CompletionDate = qo.CompletionDate,
                    CreationDate = qo.CreationDate,
                    OrderStatus = qo.OrderStatus,
                    PaymentDate = qo.PaymentDate,
                    PaymentStatus = qo.PaymentStatus
                }).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ex.InnerException?.Message);
            }
        }
        private int GetPrice(Boardgame game, int qty)
        {
            if (game.Discount != null)
                return (int)Math.Ceiling(game.FullPrice * (1 - ((decimal)game.Discount / 100)) * qty);
            return (int)Math.Ceiling(game.FullPrice * qty);
        }
        private IEnumerable<OrderItem> ConvertToEntity(IEnumerable<OrderItemDto> orders)
            => orders.Select(o => new OrderItem { ItemId = o.Id, Qty = o.Qty });
    }
}
