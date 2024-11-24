using Microsoft.EntityFrameworkCore;

namespace SupplySyncBackend.Data
{
    public class DatabaseConfig : DbContext
    {
        // Constructor accepting DbContextOptions
        public DatabaseConfig(DbContextOptions<DatabaseConfig> options) : base(options)
        {
        }

        // Define DbSets for your entities
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        // Optional: If you want a table for storing recommendations
        public DbSet<DiscountRecommendationDto> DiscountRecommendations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: Configuring Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).HasPrecision(18, 2); // Decimal precision
            });

            // Additional configurations can go here
        }
    }
}
