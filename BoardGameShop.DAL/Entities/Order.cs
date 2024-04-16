namespace BoardGameShop.DAL.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        [Required]
        public int PublisherId { get; set; }
        public string? MessageFromUser { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
        [Required]
        public PaymentStatus PaymentStatus { get; set; }
        [Required]
        public IEnumerable<OrderItem> OrderItems { get; set; } = Enumerable.Empty<OrderItem>();
    }
}
