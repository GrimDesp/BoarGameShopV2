namespace BoardGameShop.DAL.Entities
{
    //[EntityTypeConfiguration(typeof(MechanicConfiguration))]
    public class Mechanic : BaseEntity
    {
        [Required, StringLength(20)]
        public string Name { get; set; } = string.Empty;
        [StringLength(200)]
        public string? Description { get; set; } = string.Empty;
        [InverseProperty(nameof(BoardGame.Mechanics))]
        public List<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
