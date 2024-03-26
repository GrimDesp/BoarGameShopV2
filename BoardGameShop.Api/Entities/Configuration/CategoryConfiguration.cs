namespace BoardGameShop.Api.Entities.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.BoardGames)
                .WithOne()
                .HasForeignKey(x => x.CategoryIds);
        }
    }
}
