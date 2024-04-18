namespace BoardGameShop.Model.Dtos
{
    public class CreateOrderDto
    {
        public IEnumerable<OrderItemDto> Items { get; set; }
        public int VendorId { get; set; }
        public UserPersonalInfoDto User { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? MessageFromUser { get; set; }
    }
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
