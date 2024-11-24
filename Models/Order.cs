namespace SupplySyncBackend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        // Add other properties as required
    }
}
