namespace BoardGameShop.DAL.Entities
{
    public class BoardgameToMechanic
    {
        public int BoardgameId { get; set; }
        [ForeignKey(nameof(BoardgameId)), Required]
        public Boardgame? BoardgameNavigation { get; set; }
        public int MechanicId { get; set; }
        [ForeignKey(nameof(MechanicId)), Required]
        public Mechanic? MechanicNavigation { get; set; }
    }
}
