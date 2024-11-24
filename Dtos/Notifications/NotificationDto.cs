namespace SupplySyncBackend.Dtos.Notifications
{
    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
