namespace SupplySyncBackend.Dtos.Products
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SupplierName { get; set; }
    }
}
