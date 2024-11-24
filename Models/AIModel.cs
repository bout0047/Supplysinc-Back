namespace SupplySyncBackend.Models
{
    public class AIModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string TrainingDataLocation { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
