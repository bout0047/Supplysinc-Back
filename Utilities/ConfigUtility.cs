using System.IO;
using System.Text.Json;

namespace SupplySyncBackend.Utilities
{
    public static class ConfigUtility
    {
        public static T ReadConfig<T>(string configPath)
        {
            if (!File.Exists(configPath))
                throw new FileNotFoundException($"Config file not found: {configPath}");

            var json = File.ReadAllText(configPath);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
