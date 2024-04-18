namespace BoardGameShop.DAL.Entities.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Orders)
                .WithOne()
                .HasForeignKey(o => o.UserId);
        }
    }
}
