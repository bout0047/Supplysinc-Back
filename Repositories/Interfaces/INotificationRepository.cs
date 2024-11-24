using SupplySyncBackend.Models;

namespace SupplySyncBackend.Repositories
{
    public interface INotificationRepository
    {
        Task AddNotificationAsync(Notification notification);
        Task<IEnumerable<Notification>> GetNotificationsByUserAsync(int userId);
    }
}
