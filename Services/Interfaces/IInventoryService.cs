namespace SupplySyncBackend.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<ProductResponseDto>> GetLowStockProductsAsync(int threshold);
        Task<bool> ReorderProductAsync(int productId, int quantity);
        Task<bool> UpdateStockAsync(int productId, int newStockQuantity);
        Task<StockStatusDto> GetStockStatusAsync(int productId);
        Task<IEnumerable<ExpiredProductsDto>> GetExpiredProductsAsync(DateTime referenceDate);
    }
}
