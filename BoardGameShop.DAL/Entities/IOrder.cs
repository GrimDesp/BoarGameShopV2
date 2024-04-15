namespace BoardGameShop.DAL.Entities
{
    internal class IOrder : BaseEntity
    {
        public DateTime CreationTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public int PublisherId { get; set; }
        public string? MessageFromUser { get; set; }
        public IEnumerable<IOrderItems> OrderItems { get; set; } = Enumerable.Empty<IOrderItems>();
    }
}
