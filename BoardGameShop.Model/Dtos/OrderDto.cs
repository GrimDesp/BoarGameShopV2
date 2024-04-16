using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameShop.Model.Dtos
{
    public class OrderDto
    {
        public IEnumerable<OrderItemDto> Items { get; set; }
        public int PublisherId { get; set; }
        public UserPersonalInfoDto User { get; set; }
        public string? DeliveryAddress { get; set; }
    }
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
