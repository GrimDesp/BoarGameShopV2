namespace BoardGameShop.DAL.Entities.Configuration
{
    public class BoardgameConfiguration : IEntityTypeConfiguration<Boardgame>
    {
        public void Configure(EntityTypeBuilder<Boardgame> builder)
        {
            builder.ToTable("BoardGames");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.PublisherNavigation)
                .WithMany(y => y.BoardGames)
                .IsRequired()
                .HasForeignKey(x => x.PublisherId);

            builder.HasOne(x => x.VendorNavigation)
                .WithMany(y => y.Boardgames)
                .HasForeignKey(x => x.VendorId).IsRequired();

            builder.HasMany(x => x.Mechanics)
                .WithMany(y => y.Boardgames)
                .UsingEntity<BoardgameToMechanic>(
                j => j.HasOne(cd => cd.MechanicNavigation)
                .WithMany(cd => cd.BoardgameMechanics)
                .HasForeignKey(cd => cd.MechanicId)
                .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(cd => cd.BoardgameNavigation)
                .WithMany(cd => cd.BoardgameMechanics)
                .HasForeignKey(cd => cd.BoardgameId)
                .OnDelete(DeleteBehavior.Cascade),
                j => j.HasKey(cd => new { cd.MechanicId, cd.BoardgameId }));

            builder.HasMany(x => x.Categories)
                .WithMany(y => y.Boardgames)
                .UsingEntity<BoardgameToCategory>(
                j => j.HasOne(cd => cd.CategoryNavigation)
                .WithMany(cd => cd.BoardgameCategories)
                .HasForeignKey(cd => cd.CategoryId)
                .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(cd => cd.BoardgameNavigation)
                .WithMany(cd => cd.BoardgameCategories)
                .HasForeignKey(cd => cd.BoardgameId)
                .OnDelete(DeleteBehavior.Cascade),
                j => j.HasKey(cd => new { cd.BoardgameId, cd.CategoryId }));

            builder.HasMany(x => x.Authors)
                .WithMany(y => y.Boardgames)
                .UsingEntity<BoardgameToAuthor>(
                j => j.HasOne(cd => cd.AuthorNavigation)
                .WithMany(cd => cd.BoardgameToAuthors)
                .HasForeignKey(cd => cd.AuthorId)
                .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(cd => cd.BoardgameNavigation)
                .WithMany(cd => cd.BoardgameAuthors)
                .HasForeignKey(cd => cd.BoardgameId)
                .OnDelete(DeleteBehavior.Cascade),
                j => j.HasKey(cd => new { cd.AuthorId, cd.BoardgameId })
                );

            builder.HasMany(x => x.Artists)
                .WithMany(y => y.Boardgames)
                .UsingEntity<BoardgameToArtist>(
                j => j.HasOne(cd => cd.ArtistNavigation)
                .WithMany(cd => cd.BoardgameArtists)
                .HasForeignKey(j => j.ArtistId)
                .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(j => j.BoardgameNavigation)
                .WithMany(cd => cd.BoardgameArtists)
                .HasForeignKey(j => j.BoardgameId)
                .OnDelete(DeleteBehavior.Cascade),
                j => j.HasKey(j => new { j.BoardgameId, j.ArtistId }));
        }
    }
}
