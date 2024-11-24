using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace SupplySyncBackend.Utilities
{
    public static class CsvExporter
    {
        public static void ExportToCsv<T>(IEnumerable<T> data, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(data);
        }
    }
}
