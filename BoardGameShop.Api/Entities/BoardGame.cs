using System.ComponentModel;

namespace BoardGameShop.Api.Entities
{
    [EntityTypeConfiguration(typeof(BoardGameConfiguration))]
    public class BoardGame : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string? Description { get; set; } = string.Empty;
        [DefaultValue(0)]
        public int Quantity { get; set; } = 0;
        [DefaultValue(1)]
        public byte MinPlayer { get; set; } = 1;
        [DefaultValue(1)]
        public byte MaxPlayer { get; set; } = 1;
        public int? MinPlayTime { get; set; }
        public int? MaxPlayTime { get; set; }
        [Required]
        [Precision(20, 2)]
        public decimal FullPrice { get; set; }
        public byte? Discount { get; set; }
        public List<int>? CategoryIds { get; set; }
        [ForeignKey(nameof(CategoryIds))]
        public List<Category>? Categories { get; set; }
        public List<int>? MechanicIds { get; set; }
        [ForeignKey(nameof(MechanicIds))]
        public List<Mechanic>? Mechanics { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required, ForeignKey(nameof(PublisherId))]
        [InverseProperty(nameof(Publisher.BoardGames))]
        public Publisher PublisherNavigation { get; set; } = new();
        public List<int>? DesignerIds { get; set; }
        public List<int>? ArtistIds { get; set; }
        [ForeignKey(nameof(DesignerIds))]
        public List<Author>? Designers { get; set; }
        [ForeignKey(nameof(ArtistIds))]
        public List<Artist>? Artists { get; set; }
    }
}
