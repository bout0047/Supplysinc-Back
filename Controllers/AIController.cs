using Microsoft.AspNetCore.Mvc;
using SupplySyncBackend.Services.Interfaces;
using SupplySyncBackend.Dtos.AI;

namespace SupplySyncBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        private readonly IAIService _aiService;

        public AIController(IAIService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("predict-demand")]
        public async Task<IActionResult> PredictDemand([FromBody] PredictionRequestDto request)
        {
            var prediction = await _aiService.GetDemandPrediction(request);
            return Ok(prediction);
        }

        [HttpGet("restocking-recommendations")]
        public async Task<IActionResult> GetRestockingRecommendations()
        {
            var recommendations = await _aiService.GetRestockingRecommendations();
            return Ok(recommendations);
        }
    }
}
