using System.IO;

namespace SupplySyncBackend.Helpers
{
    public static class ModelManager
    {
        private const string ModelDirectory = "Models";

        public static void SaveModel(byte[] modelData, string modelName)
        {
            Directory.CreateDirectory(ModelDirectory);
            File.WriteAllBytes(Path.Combine(ModelDirectory, modelName), modelData);
        }

        public static byte[] LoadModel(string modelName)
        {
            var modelPath = Path.Combine(ModelDirectory, modelName);
            if (File.Exists(modelPath))
            {
                return File.ReadAllBytes(modelPath);
            }

            throw new FileNotFoundException($"Model '{modelName}' not found.");
        }

        public static void DeleteModel(string modelName)
        {
            var modelPath = Path.Combine(ModelDirectory, modelName);
            if (File.Exists(modelPath))
            {
                File.Delete(modelPath);
            }
        }
    }
}
