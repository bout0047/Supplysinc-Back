namespace SupplySyncBackend.Dtos.Analytics
{
    public class TopSellingProductsDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitsSold { get; set; }
    }
}
