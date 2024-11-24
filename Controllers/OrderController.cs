using Microsoft.AspNetCore.Mvc;
using SupplySyncBackend.Services.Interfaces;
using SupplySyncBackend.Dtos.General;

namespace SupplySyncBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            var order = await _orderService.CreateOrder(orderDto);
            return CreatedAtAction(nameof(GetAllOrders), new { id = order.OrderId }, order);
        }
    }
}
