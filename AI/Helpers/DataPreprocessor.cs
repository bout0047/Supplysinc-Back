using System.Collections.Generic;

namespace SupplySyncBackend.Helpers
{
    public static class DataPreprocessor
    {
        public static List<T> NormalizeData<T>(IEnumerable<T> data, double min, double max)
        {
            // Normalize numeric data between a given range
            // Placeholder logic to normalize data
            return data.ToList();
        }

        public static List<T> HandleMissingValues<T>(IEnumerable<T> data, T defaultValue)
        {
            // Replace missing values with a default
            return data.Select(item => item == null ? defaultValue : item).ToList();
        }
    }
}
