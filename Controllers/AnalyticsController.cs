using Microsoft.AspNetCore.Mvc;
using SupplySyncBackend.Services.Interfaces;

namespace SupplySyncBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public AnalyticsController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [HttpGet("inventory-summary")]
        public async Task<IActionResult> GetInventorySummary()
        {
            var summary = await _analyticsService.GetInventorySummaryAsync();
            return Ok(summary);
        }

        [HttpGet("sales-trends")]
        public async Task<IActionResult> GetSalesTrends([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var trends = await _analyticsService.GetSalesTrendsAsync(startDate, endDate);
            return Ok(trends);
        }
    }
}
