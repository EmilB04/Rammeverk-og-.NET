using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Emil.BookStore.Models;

namespace Emil.BookStore.Exceptions
{
    /// <summary>
    /// Exception thrown when a discount is in use.
    /// </summary>
    public class DiscountInUseException : Exception, ISerializable
    {
        public DiscountInUseException() { }

        public DiscountInUseException(string message) : base(message) { }

        public DiscountInUseException(string message, Exception inner) : base(message, inner) { }

    }
}