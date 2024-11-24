namespace SupplySyncBackend.Dtos.General
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public List<int> ProductIds { get; set; } = new List<int>();
    }
}
