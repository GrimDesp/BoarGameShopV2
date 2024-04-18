namespace BoardGameShop.Model.Dtos
{
    public class OrderDetailsDto
    {
        public required int OrderId { get; set; }
        public required string VendorName { get; set; }
        public List<OrderItemInfoDto> Items { get; set; } = new();
        public UserPersonalInfoDto User { get; set; } = new();
        public string? DeliveryAddress { get; set; }
        public required DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string? MessageFromUser { get; set; }
    }
    public class OrderItemInfoDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
