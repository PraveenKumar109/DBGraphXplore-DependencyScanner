using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DBGraphXplore.Core.FileHelpers
{
    public static class CsvWriter
    {
        public static void WriteToCsvFile<T>(IEnumerable<T> collection, string filePath)
        {
            if (collection == null || !collection.Any())
                return;

            var properties = typeof(T).GetProperties();
            var csvBuilder = new StringBuilder();

            // Write the header row
            csvBuilder.AppendLine(string.Join(",", properties.Select(p => p.Name)));

            // Write the data rows
            foreach (var item in collection)
            {
                var values = properties.Select(p => p.GetValue(item)?.ToString() ?? string.Empty);
                var line = string.Join(",", values.Select(v => $"\"{v.Replace("\"", "\"\"")}\"")); // Escaping quotes
                csvBuilder.AppendLine(line);
            }

            // Write to file
            File.WriteAllText(filePath, csvBuilder.ToString());
        }
    }
}



