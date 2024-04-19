
namespace BoardGameShop.DAL.Entities.Configuration
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(i => new { i.OrderId, i.ItemId });
            builder.HasOne(i => i.BoardgameNavigation)
                .WithMany(g => g.OrderItems)
                .HasForeignKey(i => i.ItemId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
