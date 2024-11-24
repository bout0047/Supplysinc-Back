namespace SupplySyncBackend.Dtos.General
{
    public class FeedbackDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
