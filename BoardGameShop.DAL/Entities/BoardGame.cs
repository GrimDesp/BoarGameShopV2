namespace BoardGameShop.DAL.Entities
{
    [EntityTypeConfiguration(typeof(BoardgameConfiguration))]
    public class Boardgame : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string? Description { get; set; } = string.Empty;
        [DefaultValue(0)]
        public int Quantity { get; set; } = 0;
        public byte? MinPlayer { get; set; }
        public byte? MaxPlayer { get; set; }
        public int? MinPlayTime { get; set; }
        public int? MaxPlayTime { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public AgeEnum? Age { get; set; }
        [Required]
        [Precision(20, 2)]
        public decimal FullPrice { get; set; }
        public byte? Discount { get; set; }

        [InverseProperty(nameof(Category.Boardgames))]
        public List<Category> Categories { get; set; } = new List<Category>();
        [InverseProperty(nameof(BoardgameToCategory.BoardgameNavigation))]
        public List<BoardgameToCategory> BoardgameCategories { get; set; } = new List<BoardgameToCategory>();


        [InverseProperty(nameof(BoardgameToMechanic.BoardgameNavigation))]
        public List<BoardgameToMechanic> BoardgameMechanics { get; set; } = new List<BoardgameToMechanic>();
        [InverseProperty(nameof(Mechanic.Boardgames))]
        public List<Mechanic> Mechanics { get; set; } = new List<Mechanic>();

        [InverseProperty(nameof(Author.Boardgames))]
        public List<Author> Authors { get; set; } = new List<Author>();
        [InverseProperty(nameof(BoardgameToAuthor.BoardgameNavigation))]
        public List<BoardgameToAuthor> BoardgameAuthors { get; set; } = new List<BoardgameToAuthor>();

        [InverseProperty(nameof(Artist.Boardgames))]
        public List<Artist> Artists { get; set; } = new List<Artist>();
        [InverseProperty(nameof(BoardgameToArtist.BoardgameNavigation))]
        public List<BoardgameToArtist> BoardgameArtists { get; set; } = new List<BoardgameToArtist>();

        [Required]
        public int PublisherId { get; set; }
        [Required, ForeignKey(nameof(PublisherId))]
        [InverseProperty(nameof(Publisher.BoardGames))]
        public Publisher PublisherNavigation { get; set; } = new();
        public int VendorId { get; set; }
        [InverseProperty(nameof(Vendor.Boardgames))]
        public Vendor VendorNavigation { get; set; } = new();
        [InverseProperty(nameof(OrderItem.BoardgameNavigation))]
        public List<OrderItem> OrderItems { get; set; } = new();

    }
}
