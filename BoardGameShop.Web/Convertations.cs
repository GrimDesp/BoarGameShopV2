using System.Runtime.CompilerServices;

namespace BoardGameShop.Web
{
    public static class Convertations
    {
        public static IEnumerable<OrderItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems)
        {
            return cartItems.Select(i => new OrderItemDto { Id = i.Id, Qty = i.Quantity, TimeStamp = i.TimeStamp });
        }
    }
}
