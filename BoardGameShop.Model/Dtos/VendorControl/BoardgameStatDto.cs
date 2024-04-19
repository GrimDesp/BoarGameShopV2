namespace BoardGameShop.Model.Dtos.VendorControl
{
    public class BoardgameStatDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public required string Name { get; set; }
        public decimal FullPrice { get; set; }
        public byte? Discount { get; set; }
        public int ItemSold { get; set; }
        public decimal Earned { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
