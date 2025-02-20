using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Emil.BookStore.Models;

namespace Emil.BookStore.Exceptions
{
    public class DiscountInUseException : Exception, ISerializable
    {
        public DiscountInUseException() { }

        public DiscountInUseException(string message) { }

        public DiscountInUseException(string message, Exception inner) { }

    }
}