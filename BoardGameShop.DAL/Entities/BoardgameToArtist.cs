namespace BoardGameShop.DAL.Entities
{
    public class BoardgameToArtist
    {
        public int BoardgameId { get; set; }
        [ForeignKey(nameof(BoardgameId)), Required]
        public Boardgame? BoardgameNavigation { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey(nameof(ArtistId)), Required]
        public Artist? ArtistNavigation { get; set; }
    }
}
