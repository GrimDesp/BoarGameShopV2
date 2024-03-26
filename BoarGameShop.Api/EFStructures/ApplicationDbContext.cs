namespace BoardGameShop.Api.EFStructures
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BoardGameConfiguration().Configure(modelBuilder.Entity<BoardGame>());
            //new MechanicConfiguration().Configure(modelBuilder.Entity<Mechanic>());
            //new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
        }
    }
}
