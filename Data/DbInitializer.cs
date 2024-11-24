using Microsoft.EntityFrameworkCore;

namespace SupplySyncBackend.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Ensure database is created
            if (context.Database.EnsureCreated())
            {
                // Seed initial data if required
                SeedData.SeedDatabase(context);
            }
        }
    }
}
