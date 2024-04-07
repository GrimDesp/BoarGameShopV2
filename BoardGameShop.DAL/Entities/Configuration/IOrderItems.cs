namespace BoardGameShop.DAL.Entities.Configuration
{
    internal class IOrderItems
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ItemCost { get; set; }
        public int Qty { get; set; }

    }
}
