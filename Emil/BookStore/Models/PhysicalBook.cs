using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emil.BookStore.Models
{
    public class PhysicalBook : Book
    {
        public PhysicalBook(string title, string author, string isbn, double price, int quantity, bool isDiscounted = false, Discount? appliedDiscount = null) 
            : base(title, author, isbn, price, quantity, isDiscounted, appliedDiscount) { }
    }
}