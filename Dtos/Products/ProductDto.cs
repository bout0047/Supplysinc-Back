namespace SupplySyncBackend.Dtos.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? SupplierId { get; set; }
    }
}
