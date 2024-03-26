namespace BoardGameShop.Model.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal FullPrice { get; set; }
        public decimal Price { get; set; }
        public byte? Discount { get; set; }

    }
}
