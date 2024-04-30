namespace BoardGameShop.Model.Dtos.VendorControl
{
    public class BoardgameActionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public byte? MinPlayer { get; set; }
        public byte? MaxPlayer { get; set; }
        public int? MinPlayTime { get; set; }
        public int? MaxPlayTime { get; set; }
        public bool IsDeleted { get; set; }
        public AgeEnum? Age { get; set; }
        public decimal FullPrice { get; set; }
        public byte? Discount { get; set; }
        public byte[] TimeStamp { get; set; }
        public List<CategoryDto> Categories { get; set; } = new();
        public List<MechanicDto> Mechanics { get; set; } = new();
        public List<ArtistDto> Artists { get; set; } = new();
        public List<AuthorDto> Authors { get; set; } = new();
        public PublisherDto? Publisher { get; set; }
    }
}
