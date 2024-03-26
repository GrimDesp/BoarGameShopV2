namespace BoardGameShop.DAL.Entities
{
    public class Publisher : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [InverseProperty(nameof(BoardGame.PublisherNavigation))]
        public IEnumerable<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
