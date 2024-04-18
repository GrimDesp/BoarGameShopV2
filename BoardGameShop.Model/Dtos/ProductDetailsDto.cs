namespace BoardGameShop.Model.Dtos
{
    public class ProductDetailsDto
    {
        public int ProductId { get; set; }
        public byte[] TimeSpam { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string PublisherName { get; set; } = string.Empty;
        public string VendorName { get; set; } = string.Empty;
        public int VendorId { get; set; }
        public int? MinPlayer { get; set; }
        public int? MaxPlayer { get; set; }
        public decimal FullPrice { get; set; }
        public decimal? Price { get; set; }
        public int? MinPlayTime { get; set; }
        public int? MaxPlayTime { get; set; }
        public AgeEnum? Age { get; set; }
        public bool IsAvaible { get; set; }
        public List<string>? ImageUrls { get; set; } = new();
        public IEnumerable<string>? Mechanics { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string>? Categories { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string>? Authors { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string>? Artists { get; set; } = Enumerable.Empty<string>();
    }
}
//