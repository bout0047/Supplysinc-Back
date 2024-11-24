using SupplySyncBackend.Dtos;
namespace SupplySyncBackend.Repositories
{
    public interface IAIRepository
    {
        Task<IEnumerable<ExpiringProductsDto>> GetExpiringProductsAsync(DateTime referenceDate, int days);
        Task<IEnumerable<InventoryForecastDto>> GetSalesDataForPredictionAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<SupplierRecommendationDto>> GetSupplierRecommendationsAsync(int productId);
    }
}
