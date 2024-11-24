using SupplySyncBackend.Models;

namespace SupplySyncBackend.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task AddOrderAsync(Order order);
        Task UpdateOrderStatusAsync(int orderId, string status);
        Task DeleteOrderAsync(int orderId);
    }
}
