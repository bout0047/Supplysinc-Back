using Microsoft.EntityFrameworkCore;
using SupplySyncBackend.Models;

namespace SupplySyncBackend.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Add initial seeding data
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "hashed_password", RoleId = 1 }
            );

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "Default Supplier", ContactInfo = "info@supplier.com" }
            );
        }

        public static void SeedDatabase(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { Id = 1, Name = "Admin" },
                    new Role { Id = 2, Name = "User" }
                );
            }

            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "hashed_password",
                    RoleId = 1
                });
            }

            if (!context.Suppliers.Any())
            {
                context.Suppliers.Add(new Supplier
                {
                    Id = 1,
                    Name = "Default Supplier",
                    ContactInfo = "info@supplier.com"
                });
            }

            context.SaveChanges();
        }
    }
}
