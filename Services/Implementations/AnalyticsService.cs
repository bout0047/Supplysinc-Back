using SupplySyncBackend.Services.Interfaces;
using SupplySyncBackend.Data;
using SupplySyncBackend.Dtos;
using Microsoft.EntityFrameworkCore;

namespace SupplySyncBackend.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly ApplicationDbContext _context;

        public AnalyticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InventorySummaryDto> GetInventorySummaryAsync()
        {
            var totalProducts = await _context.Products.CountAsync();
            var expiringSoon = await _context.Products.CountAsync(p => p.ExpirationDate <= DateTime.Now.AddDays(7));
            var outOfStock = await _context.Products.CountAsync(p => p.StockQuantity == 0);

            return new InventorySummaryDto
            {
                TotalProducts = totalProducts,
                ExpiringSoon = expiringSoon,
                OutOfStock = outOfStock
            };
        }

        public async Task<IEnumerable<TopSellingProductsDto>> GetTopSellingProductsAsync(DateTime startDate, DateTime endDate)
        {
            // Fetch top-selling products
            throw new NotImplementedException();
        }

        public async Task<UserActivityReportDto> GetUserActivityReportAsync(int userId, DateTime startDate, DateTime endDate)
        {
            // Fetch user activity reports
            throw new NotImplementedException();
        }

        public async Task<SalesTrendsDto> GetSalesTrendsAsync(DateTime startDate, DateTime endDate)
        {
            // Fetch sales trends
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FeedbackAnalyticsDto>> GetFeedbackAnalyticsAsync()
        {
            // Fetch feedback analytics
            throw new NotImplementedException();
        }
    }
}
