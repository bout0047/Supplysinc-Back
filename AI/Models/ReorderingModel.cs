namespace SupplySyncBackend.Models
{
    public class ReorderingModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CurrentStock { get; set; }
        public int ReorderThreshold { get; set; }
        public int SuggestedReorderQuantity { get; set; }
    }
}
