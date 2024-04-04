namespace BoardGameShop.DAL.Entities
{
    [Table("Categories")]
    //[EntityTypeConfiguration(typeof(CategoryConfiguration))]
    public class Category : BaseEntity
    {
        [Required, StringLength(20)]
        public string Name { get; set; } = string.Empty;
        [StringLength(200)]
        public string? Description { get; set; } = string.Empty;
        [InverseProperty(nameof(Boardgame.Categories))]
        public IEnumerable<Boardgame> Boardgames { get; set; } = new List<Boardgame>();
        [InverseProperty(nameof(BoardgameToCategory.CategoryNavigation))]
        public IEnumerable<BoardgameToCategory> BoardgameCategories { get; set; } = new List<BoardgameToCategory>();
    }
}
