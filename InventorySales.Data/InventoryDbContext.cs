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

            // Add unique constraint for Category Name
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Seeding Data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic Gadgets and Devices" },
                new Category { Id = 2, Name = "Groceries", Description = "Daily household items" }
            );

            // Password is "12345678" (Now hashed with BCrypt)
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", PasswordHash = "$2a$11$Ka8dOJsdn8/r9XFAvZrHu.4wh6.st5D5GGGQpBBKhUr8HGGFDyQ7u", Role = "Admin", Email = "admin@inventory.com" }
            );

            modelBuilder.Entity<Product>().HasData(
               new Product { Id = 1, Name = "Laptop", CategoryId = 1, UnitPrice = 1200.00m, StockQuantity = 10, ReorderLevel = 2, Description = "High-performance laptop" },
               new Product { Id = 2, Name = "Smartphone", CategoryId = 1, UnitPrice = 800.00m, StockQuantity = 20, ReorderLevel = 5, Description = "Latest model smartphone" }
           );
        }
    }
}
