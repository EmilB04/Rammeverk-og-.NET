using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Data
{
    /// <summary>
    /// Options for parsing CSV data.
    /// </summary>
    public class ParserOptions
    {
        /// <summary>
        /// Indicates if the first row is a header (default = false).
        /// </summary>
        public bool HasHeader { get; set; } = false;
        /// <summary>
        /// Delimiter character (default = ',').
        /// </summary>
        public char Delimiter { get; set; } = ',';
    }
}
