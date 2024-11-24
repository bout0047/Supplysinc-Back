namespace SupplySyncBackend.Models
{
    public class ExpirationTrackingModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsExpiringSoon { get; set; } // True if within threshold days
    }
}
