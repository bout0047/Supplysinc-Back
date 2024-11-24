using Microsoft.AspNetCore.Mvc;
using SupplySyncBackend.Services.Interfaces;
using SupplySyncBackend.Dtos.Products;

namespace SupplySyncBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            var result = await _productService.AddProduct(productDto);
            return result ? Ok("Product added successfully.") : BadRequest("Failed to add product.");
        }
    }
}
