using Microsoft.AspNetCore.Mvc;
using SupplySyncBackend.Services.Interfaces;
using SupplySyncBackend.Dtos.General;

namespace SupplySyncBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliers();
            return Ok(suppliers);
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierDto supplierDto)
        {
            var result = await _supplierService.AddSupplier(supplierDto);
            return result ? Ok("Supplier added successfully.") : BadRequest("Failed to add supplier.");
        }
    }
}
