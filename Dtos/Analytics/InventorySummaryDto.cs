namespace SupplySyncBackend.Dtos.Analytics
{
    public class InventorySummaryDto
    {
        public int TotalProducts { get; set; }
        public int ProductsInStock { get; set; }
        public int ProductsOutOfStock { get; set; }
    }
}
