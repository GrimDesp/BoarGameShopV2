namespace BoardGameShop.DAL.Entities
{
    public class BoardgameToCategory
    {
        public int BoardgameId { get; set; }
        [ForeignKey(nameof(BoardgameId))]
        public Boardgame BoardgameNavigation { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category CategoryNavigation { get; set; }
    }
}
