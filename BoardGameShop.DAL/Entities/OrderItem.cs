namespace BoardGameShop.DAL.Entities
{
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
        public Order OrderNavigation { get; set; }

    }
}
