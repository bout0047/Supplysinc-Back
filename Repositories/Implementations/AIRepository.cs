using SupplySyncBackend.Repositories;
using SupplySyncBackend.Dtos;
using SupplySyncBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace SupplySyncBackend.Repositories
{
    public class AIRepository : IAIRepository
    {
        private readonly ApplicationDbContext _context;

        public AIRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExpiringProductsDto>> GetExpiringProductsAsync(DateTime referenceDate, int days)
        {
            return await _context.Products
                .Where(p => p.ExpirationDate.HasValue && p.ExpirationDate.Value <= referenceDate.AddDays(days))
                .Select(p => new ExpiringProductsDto
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    ExpirationDate = p.ExpirationDate
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<InventoryForecastDto>> GetSalesDataForPredictionAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Sales
                .Where(s => s.Date >= startDate && s.Date <= endDate)
                .Select(s => new InventoryForecastDto
                {
                    ProductId = s.ProductId,
                    SalesQuantity = s.Quantity,
                    Date = s.Date
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SupplierRecommendationDto>> GetSupplierRecommendationsAsync(int productId)
        {
            return await _context.Suppliers
                .Include(s => s.Products)
                .Where(s => s.Products.Any(p => p.Id == productId))
                .Select(s => new SupplierRecommendationDto
                {
                    SupplierId = s.Id,
                    SupplierName = s.Name,
                    ProductId = productId,
                    ProductCategory = s.Products.FirstOrDefault(p => p.Id == productId)?.Category ?? string.Empty
                })
                .ToListAsync();
        }
    }
}
