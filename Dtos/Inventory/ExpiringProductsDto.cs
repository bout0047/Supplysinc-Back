namespace SupplySyncBackend.Dtos.Inventory
{
    public class ExpiringProductsDto
    {
        public int ProductId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string ProductName { get; set; }
    }
}
