namespace BoardGameShop.DAL.Entities
{
    public class Vendor : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        [InverseProperty(nameof(Boardgame.VendorNavigation))]
        public IEnumerable<Boardgame> Boardgames { get; set; } = new List<Boardgame>();
    }
}
