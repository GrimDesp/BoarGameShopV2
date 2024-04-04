namespace BoardGameShop.DAL.EFStructures
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Boardgame> BoardGames { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BoardgameConfiguration().Configure(modelBuilder.Entity<Boardgame>());
            //new MechanicConfiguration().Configure(modelBuilder.Entity<Mechanic>());
            //new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
        }
    }
}
