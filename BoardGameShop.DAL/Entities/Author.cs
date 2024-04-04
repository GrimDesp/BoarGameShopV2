namespace BoardGameShop.DAL.Entities
{
    public class Author : Creator
    {
        [InverseProperty(nameof(Boardgame.Authors))]
        public IEnumerable<Boardgame> Boardgames { get; set; } = new List<Boardgame>();
        [InverseProperty(nameof(BoardgameToAuthor.AuthorNavigation))]
        public IEnumerable<BoardgameToAuthor> BoardgameToAuthors { get; set; } = new List<BoardgameToAuthor>();
    }
}
