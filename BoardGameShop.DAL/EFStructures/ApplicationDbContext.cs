using Microsoft.Identity.Client;

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
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorEmployee> VendorEmployees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BoardgameConfiguration().Configure(modelBuilder.Entity<Boardgame>());
            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
            new OrderItemConfiguration().Configure(modelBuilder.Entity<OrderItem>());
            new VendorConfiguration().Configure(modelBuilder.Entity<Vendor>());
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new OrderItemConfiguration().Configure(modelBuilder.Entity<OrderItem>());
            new VendorEmployeeConfiguration().Configure(modelBuilder.Entity<VendorEmployee>());
            //new MechanicConfiguration().Configure(modelBuilder.Entity<Mechanic>());
            //new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
        }
    }
}
