namespace SupplySyncBackend.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetAllNotifications(int userId);
        Task<bool> MarkAsRead(int notificationId);
        Task<bool> CreateNotification(string message, int userId);
    }
}
