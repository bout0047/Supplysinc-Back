using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace SupplySyncBackend.Utilities
{
    public static class CsvHelperUtility
    {
        public static List<T> ReadCsv<T>(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            return new List<T>(csv.GetRecords<T>());
        }

        public static void WriteCsv<T>(string filePath, IEnumerable<T> records)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteRecords(records);
        }
    }
}
