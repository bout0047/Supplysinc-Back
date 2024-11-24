namespace SupplySyncBackend.Config
{
    public class AISettings
    {
        public string ModelPath { get; set; } = string.Empty;
        public int TrainingEpochs { get; set; }
        public double LearningRate { get; set; }
        public string PreTrainedModelUrl { get; set; } = string.Empty;
    }
}
