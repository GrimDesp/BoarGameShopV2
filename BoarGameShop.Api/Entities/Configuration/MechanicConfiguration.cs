namespace BoardGameShop.Api.Entities.Configuration
{
    public class MechanicConfiguration : IEntityTypeConfiguration<Mechanic>
    {
        public void Configure(EntityTypeBuilder<Mechanic> builder)
        {
            builder.HasMany(x => x.BoardGames)
                .WithOne()
                .HasForeignKey(x => x.CategoryIds);
        }
    }
}
