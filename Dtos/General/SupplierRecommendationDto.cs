namespace SupplySyncBackend.Dtos.General
{
    public class SupplierRecommendationDto
    {
        public int ProductId { get; set; }
        public List<int> RecommendedSuppliers { get; set; } = new List<int>();
    }
}
