﻿namespace BoardGameShop.DAL.EFStructures
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Artist> Artists { get; set; }
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