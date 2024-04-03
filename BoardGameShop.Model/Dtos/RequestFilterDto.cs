namespace BoardGameShop.Model.Dtos
{
    public class RequestFilterDto
    {
        public IEnumerable<int> MechanicIds { get; set; } = Enumerable.Empty<int>();
        public IEnumerable<int> CategoryIds { get; set; } = Enumerable.Empty<int>();
        public IEnumerable<int> PublisherIds { get; set; } = Enumerable.Empty<int>();
        public IEnumerable<int> AuthorsIds { get; set; } = Enumerable.Empty<int>();
        public IEnumerable<int> ArtistIds { get; set; } = Enumerable.Empty<int>();
        public int MaxPlayers { get; set; }
        public int MinPlayers { get; set; }
        public int MinCost { get; set; }
        public int MaxCost { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
