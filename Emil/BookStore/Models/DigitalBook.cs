using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emil.BookStore.Models
{
    public class DigitalBook : Book
    {
        public DigitalBook(string title, string author, string isbn, double price, int quantity)
            : base(title, author, isbn, price, quantity) { }
    }
}