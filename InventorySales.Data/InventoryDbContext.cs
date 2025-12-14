using InventorySales.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySales.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesDetail> SalesDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding Data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic Gadgets and Devices" },
                new Category { Id = 2, Name = "Groceries", Description = "Daily household items" }
            );

            // Password is "12345678" (In real app, hash this properly)
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", PasswordHash = "12345678", Role = "Admin" }
            );

            modelBuilder.Entity<Product>().HasData(
               new Product { Id = 1, Name = "Laptop", CategoryId = 1, UnitPrice = 1200.00m, StockQuantity = 10, ReorderLevel = 2, Description = "High-performance laptop" },
               new Product { Id = 2, Name = "Smartphone", CategoryId = 1, UnitPrice = 800.00m, StockQuantity = 20, ReorderLevel = 5, Description = "Latest model smartphone" }
           );
        }
    }
}
