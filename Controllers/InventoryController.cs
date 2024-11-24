using Microsoft.AspNetCore.Mvc;
using SupplySyncBackend.Services.Interfaces;
using SupplySyncBackend.Dtos.Inventory;

namespace SupplySyncBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStockProducts([FromQuery] int threshold)
        {
            var products = await _inventoryService.GetLowStockProductsAsync(threshold);
            return Ok(products);
        }

        [HttpPost("reorder")]
        public async Task<IActionResult> ReorderProduct([FromBody] ReorderDto reorderDto)
        {
            var success = await _inventoryService.ReorderProductAsync(reorderDto.ProductId, reorderDto.ReorderQuantity);
            return success ? Ok("Product reordered successfully.") : BadRequest("Failed to reorder product.");
        }
    }
}
