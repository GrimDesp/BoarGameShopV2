namespace BoardGameShop.DAL.Entities
{
    [EntityTypeConfiguration(typeof(OrderConfiguration))]
    public class Order : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? PaymentDate { get; set; }
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
