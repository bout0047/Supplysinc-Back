using System.Text.Json;
using SupplySyncBackend.Helpers;
using SupplySyncBackend.Models;

namespace SupplySyncBackend.Services
{
    public class AIIntegrationService
    {
        private readonly string _configPath = "AIConfig.json";
        private dynamic _config;

        public AIIntegrationService()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(_configPath))
            {
                var json = File.ReadAllText(_configPath);
                _config = JsonSerializer.Deserialize<dynamic>(json);
            }
            else
            {
                throw new FileNotFoundException("AIConfig.json not found.");
            }
        }

        public List<DemandForecastingModel> PredictDemand(List<object> inputData)
        {
            var modelPath = _config.ModelPaths.DemandForecasting.ToString();
            var model = ModelManager.LoadModel(modelPath);

            return PredictionHelper.Predict<object, DemandForecastingModel>(model, inputData);
        }

        public List<ExpirationTrackingModel> TrackExpirations(List<object> inputData)
        {
            var modelPath = _config.ModelPaths.ExpirationTracking.ToString();
            var model = ModelManager.LoadModel(modelPath);

            return PredictionHelper.Predict<object, ExpirationTrackingModel>(model, inputData);
        }

        public List<ReorderingModel> SuggestReorders(List<object> inputData)
        {
            var modelPath = _config.ModelPaths.Reordering.ToString();
            var model = ModelManager.LoadModel(modelPath);

            return PredictionHelper.Predict<object, ReorderingModel>(model, inputData);
        }
    }
}
