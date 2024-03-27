namespace BoardGameShop.DAL.Entities
{
    public class Author : Creator
    {
        [InverseProperty(nameof(BoardGame.Designers))]
        public List<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
