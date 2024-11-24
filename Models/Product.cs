namespace SupplySyncBackend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        // Add other properties as required
    }
}
