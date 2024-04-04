namespace BoardGameShop.DAL.Entities
{
    //[EntityTypeConfiguration(typeof(MechanicConfiguration))]
    public class Mechanic : BaseEntity
    {
        [Required, StringLength(20)]
        public string Name { get; set; } = string.Empty;
        [StringLength(200)]
        public string? Description { get; set; } = string.Empty;
        [InverseProperty(nameof(Boardgame.Mechanics))]
        public IEnumerable<Boardgame> Boardgames { get; set; } = new List<Boardgame>();
        [InverseProperty(nameof(BoardgameToMechanic.MechanicNavigation))]
        public IEnumerable<BoardgameToMechanic> BoardgameMechanics { get; set; } = new List<BoardgameToMechanic>();
    }
}
