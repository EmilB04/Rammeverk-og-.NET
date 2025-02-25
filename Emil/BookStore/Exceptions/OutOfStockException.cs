using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Emil.BookStore.Models;

namespace Emil.BookStore.Exceptions
{
    /// <summary>
    /// Exception thrown when a book is out of stock.
    /// </summary>
    public class OutOfStockException : Exception, ISerializable 
    {
        public OutOfStockException() { }

        public OutOfStockException(string message) : base(message) { }

        public OutOfStockException(string message, Exception inner) : base(message, inner) { }
    }
}