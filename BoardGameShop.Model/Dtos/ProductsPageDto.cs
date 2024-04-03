namespace BoardGameShop.Model.Dtos
{
    public class ProductsPageDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public int TotalPages { get; set; }
    }
}
