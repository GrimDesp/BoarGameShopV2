namespace BoardGameShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrders(IEnumerable<OrderDto> request)
        {
            if (request != null && request.Count() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
