namespace BoardGameShop.DAL.Entities
{
    public class BoardgameToMechanic
    {
        public int BoardgameId { get; set; }
        [ForeignKey(nameof(BoardgameId))]
        public Boardgame BoardgameNavigation { get; set; } = new();
        public int MechanicId { get; set; }
        [ForeignKey(nameof(MechanicId))]
        public Mechanic MechanicNavigation { get; set; } = new();
    }
}
