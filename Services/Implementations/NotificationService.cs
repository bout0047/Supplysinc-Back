using SupplySyncBackend.Services.Interfaces;
using SupplySyncBackend.Dtos;
using SupplySyncBackend.Data;

namespace SupplySyncBackend.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NotificationDto>> GetAllNotifications(int userId)
        {
            // Fetch notifications
            throw new NotImplementedException();
        }

        public async Task<bool> MarkAsRead(int notificationId)
        {
            // Mark notifications as read
            throw new NotImplementedException();
        }

        public async Task<bool> CreateNotification(string message, int userId)
        {
            // Create a new notification
            throw new NotImplementedException();
        }
    }
}
