namespace SupplySyncBackend.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDto>> GetAllOrders();
        Task<OrderResponseDto?> GetOrderById(int id);
        Task<OrderDto> CreateOrder(OrderDto orderDto);
        Task<bool> UpdateOrderStatus(int id, string status);
        Task<bool> CancelOrder(int id);
    }
}
