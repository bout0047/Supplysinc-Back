namespace SupplySyncBackend.Services.Interfaces
{
    public interface IAIService
    {
        Task<PredictionResponseDto> GetDemandPrediction(PredictionRequestDto predictionRequestDto);
        Task<IEnumerable<ProductResponseDto>> GetRestockingRecommendations();
        Task<bool> UpdateAIModels();
    }
}
