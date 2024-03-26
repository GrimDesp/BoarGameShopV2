using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BoardGameShop.Api.Entities.Configuration
{
    public class BoardGameConfiguration : IEntityTypeConfiguration<BoardGame>
    {
        public void Configure(EntityTypeBuilder<BoardGame> builder)
        {
            builder.ToTable("BoardGames");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.PublisherNavigation)
                .WithMany(y => y.BoardGames)
                .IsRequired()
                .HasForeignKey(x => x.PublisherId);
            //builder.HasMany(x => x.Categories).WithOne();
        }
    }
}
