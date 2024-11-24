namespace SupplySyncBackend.Dtos.AI
{
    public class PredictionRequestDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime PredictionDate { get; set; }
    }
}
