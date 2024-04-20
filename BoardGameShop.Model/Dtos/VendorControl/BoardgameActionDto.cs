namespace BoardGameShop.Model.Dtos.VendorControl
{
    public class BoardgameActionDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
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
        public List<BoardgameActionCategoryDto> Categories { get; set; } = new();
        public List<BoardgameActionMechanicDto> Mechanics { get; set; } = new();
        public List<BoardgameActionArtistDto> Artists { get; set; } = new();
        public List<BoardgameActionAuthorDto> Authors { get; set; } = new();
        public BoardgameActionPublisherDto? Publisher { get; set; }
    }
    public abstract class BoardgameActionBaseStat
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class BoardgameActionCategoryDto : BoardgameActionBaseStat
    { }
    public class BoardgameActionMechanicDto : BoardgameActionBaseStat
    { }
    public class BoardgameActionArtistDto : BoardgameActionBaseStat
    { }
    public class BoardgameActionAuthorDto : BoardgameActionBaseStat
    { }
    public class BoardgameActionPublisherDto : BoardgameActionBaseStat
    { }

}
