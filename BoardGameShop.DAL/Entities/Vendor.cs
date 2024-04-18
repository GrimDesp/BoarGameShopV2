namespace BoardGameShop.DAL.Entities
{
    public class Vendor : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        [InverseProperty(nameof(Boardgame.VendorNavigation))]
        public List<Boardgame> Boardgames { get; set; } = new List<Boardgame>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
