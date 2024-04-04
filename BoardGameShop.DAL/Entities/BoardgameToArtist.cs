namespace BoardGameShop.DAL.Entities
{
    public class BoardgameToArtist
    {
        public int BoardgameId { get; set; }
        [ForeignKey(nameof(BoardgameId))]
        public Boardgame BoardgameNavigation { get; set; } = new();
        public int ArtistId { get; set; }
        [ForeignKey(nameof(ArtistId))]
        public Artist ArtistNavigation { get; set; } = new();
    }
}
