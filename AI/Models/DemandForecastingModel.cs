namespace SupplySyncBackend.Models
{
    public class DemandForecastingModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double AverageDailyDemand { get; set; }
        public double PredictedDemand { get; set; }
        public DateTime ForecastDate { get; set; }
    }
}
