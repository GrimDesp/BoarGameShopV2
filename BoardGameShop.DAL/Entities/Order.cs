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
        public int VendorId { get; set; }
        public Vendor? VendorNavigation { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Secondname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? MessageFromUser { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
        [Required]
        public PaymentStatus PaymentStatus { get; set; }
        [InverseProperty(nameof(OrderItem.OrderNavigation))]
        public List<OrderItem> OrderItems { get; set; }
    }
}
