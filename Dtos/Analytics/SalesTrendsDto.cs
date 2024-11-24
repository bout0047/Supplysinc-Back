namespace SupplySyncBackend.Dtos.Analytics
{
    public class SalesTrendsDto
    {
        public int ProductId { get; set; }
        public DateTime Period { get; set; }
        public int UnitsSold { get; set; }
    }
}
