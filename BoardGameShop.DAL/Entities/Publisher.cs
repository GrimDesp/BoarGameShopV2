namespace BoardGameShop.DAL.Entities
{
    public class Publisher : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [InverseProperty(nameof(Boardgame.PublisherNavigation))]
        public IEnumerable<Boardgame> BoardGames { get; set; } = new List<Boardgame>();
    }
}
