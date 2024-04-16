namespace BoardGameShop.DAL.Entities.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(c => c.OrderItems)
                .WithOne(c => c.OrderNavigation)
                .HasForeignKey(c => c.OrderId)
                .IsRequired();
            builder.Property(o => o.CreationDate).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
            builder.Property(o => o.OrderStatus).HasDefaultValue(OrderStatus.Created);
            builder.Property(o => o.PaymentStatus).HasDefaultValue(PaymentStatus.NotPaid);
        }
    }
}
