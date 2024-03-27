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
        [InverseProperty(nameof(BoardGame.Categories))]
        public List<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
