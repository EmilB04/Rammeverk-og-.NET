using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emil.BookStore.Models;

namespace Emil.BookStore.Exceptions
{
    public class DiscountInUseException : Exception
    {
        public DiscountInUseException(string message) : base(message)
        {
        }
        public DiscountInUseException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public DiscountInUseException()
        {
        }
    }
}