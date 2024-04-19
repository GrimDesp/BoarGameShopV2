namespace BoardGameShop.DAL.Entities
{
    [EntityTypeConfiguration(typeof(OrderItemConfiguration))]
    public class OrderItem
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int ItemCost { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        [ForeignKey(nameof(OrderId))]
        public Order OrderNavigation { get; set; }
        [ForeignKey(nameof(ItemId))]
        public Boardgame BoardgameNavigation { get; set; }

    }
}
