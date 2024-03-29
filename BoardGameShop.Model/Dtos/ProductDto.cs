namespace BoardGameShop.Model.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal FullPrice { get; set; }
        public decimal Price { get; set; }
        public byte? Discount { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public AgeEnum Age { get; set; }
        public byte MinPlayer { get; set; }
        public byte MaxPlayer { get; set; }
        public int? MinPlayTime { get; set; }
        public int? MaxPlayTime { get; set; }

    }
}
