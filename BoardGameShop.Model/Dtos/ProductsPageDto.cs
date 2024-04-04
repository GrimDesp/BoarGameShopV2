namespace BoardGameShop.Model.Dtos
{
    public class ProductsPageDto
    {
        public IEnumerable<ProductDto> Products { get; set; } = Enumerable.Empty<ProductDto>();
        public int TotalPages { get; set; }
    }
}
