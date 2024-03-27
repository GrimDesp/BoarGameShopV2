namespace BoardGameShop.Model.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal FullPrice { get; set; }
        public decimal Price { get; set; }
        public byte? Discount { get; set; }
        public IEnumerable<string> ImageUrls { get; set; } = new List<string>();

    }
}
