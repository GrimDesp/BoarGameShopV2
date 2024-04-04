namespace BoardGameShop.DAL.Entities
{
    public class Artist : Creator
    {
        [InverseProperty(nameof(Boardgame.Artists))]
        public IEnumerable<Boardgame> Boardgames { get; set; } = new List<Boardgame>();
        [InverseProperty(nameof(BoardgameToArtist.ArtistNavigation))]
        public IEnumerable<BoardgameToArtist> BoardgameArtists { get; set; } = new List<BoardgameToArtist>();
    }
}
