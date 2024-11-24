namespace SupplySyncBackend.Services.Interfaces
{
    public interface IAnalyticsService
    {
        Task<InventorySummaryDto> GetInventorySummaryAsync();
        Task<IEnumerable<TopSellingProductsDto>> GetTopSellingProductsAsync(DateTime startDate, DateTime endDate);
        Task<UserActivityReportDto> GetUserActivityReportAsync(int userId, DateTime startDate, DateTime endDate);
        Task<SalesTrendsDto> GetSalesTrendsAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<FeedbackAnalyticsDto>> GetFeedbackAnalyticsAsync();
    }
}
