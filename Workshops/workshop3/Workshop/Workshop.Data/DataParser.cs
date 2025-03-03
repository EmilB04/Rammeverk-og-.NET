using System;
using System.Collections.Generic;
using System.IO;
namespace Workshop.Data
{
    /// <summary>
    /// A simple data parser class to demonstrate various parameter designs
    /// and overloads for usability testing.
    /// </summary>
    public class DataParser
    {
        /// <summary>
        /// Overload #1:
        /// Parse a CSV file using a path and specifying header and delimiter.
        /// </summary>
        /// <param name="filePath">Absolute or relative path to the CSV file</param>
        /// <param name="hasHeader">Whether the first line of the file is a header</param>
        /// <param name="delimiter">Delimiter character (default is ',')</param>
        /// <returns>A list of string arrays, each representing a row in the CSV</returns>
        public List<string[]> ParseCsv(string filePath, bool hasHeader, char delimiter = ',')
        {
            return ParseCsv_Internal(filePath, hasHeader, delimiter);
        }
        /// <summary>
        /// Overload #2:
        /// Parse a CSV file based on FileInfo, with a dedicated options object.
        /// </summary>
        /// <param name="file">A FileInfo object referencing the CSV file</param>
        /// <param name="options">ParserOptions object containing delimiter, header flag, etc.</param>
/// <returns>A list of string arrays, each representing a row in the CSV</returns>
public List<string[]> ParseCsv(FileInfo file, ParserOptions options)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            return ParseCsv_Internal(file.FullName, options.HasHeader, options.Delimiter);
        }
        // Internal method performing the actual parsing logic
        private List<string[]> ParseCsv_Internal(string filePath, bool hasHeader, char delimiter)
        {
            var rows = new List<string[]>();
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");
            var lines = File.ReadAllLines(filePath);
            int start = hasHeader ? 1 : 0;
            for (int i = start; i < lines.Length; i++)
            {
                var fields = lines[i].Split(delimiter);
                rows.Add(fields);
            }
            return rows;
        }
    }
}