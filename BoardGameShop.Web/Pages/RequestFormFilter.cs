namespace BoardGameShop.Web.Pages
{
    public class RequestFormFilter
    {
        public IEnumerable<int> MechanicIds { get; set; }
        public IEnumerable<int> CategoryIds { get; set; }
        public IEnumerable<int> PublisherIds { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }
        public IEnumerable<int> ArtistIds { get; set; }
        public int MaxPlayers { get; set; }
        public int MinPlayers { get; set; }
        public int MinCost { get; set; }
        public int MaxCost { get; set; }
    }
}
