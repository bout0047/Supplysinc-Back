namespace SupplySyncBackend.Dtos.AI
{
    public class PredictionResponseDto
    {
        public int ProductId { get; set; }
        public int PredictedQuantity { get; set; }
        public DateTime PredictionDate { get; set; }
    }
}
