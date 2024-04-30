namespace BoardGameShop.DAL.Entities
{
    public class BoardgameToCategory
    {
        public int BoardgameId { get; set; }
        [ForeignKey(nameof(BoardgameId)), Required]
        public Boardgame? BoardgameNavigation { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId)), Required]
        public Category? CategoryNavigation { get; set; }
    }
}
