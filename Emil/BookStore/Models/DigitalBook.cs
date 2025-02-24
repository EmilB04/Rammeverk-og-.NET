using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emil.BookStore.Models
{
    public class DigitalBook : Book
    {
        /// <summary>
        /// Constructor for Digital books.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="isbn">The ISBN of the book.</param>
        /// <param name="price">The price of the book.</param>
        /// <param name="quantity">The quantity of the book in stock.</param>
        /// <param name="isDiscounted">Indicates whether the book is discounted.</param>
        /// <param name="appliedDiscount">The discount applied to the book.</param>
        public DigitalBook(string title, string author, string isbn, double price, int quantity, bool isDiscounted = false, Discount? appliedDiscount = null)
            : base(title, author, isbn, price, quantity, isDiscounted, appliedDiscount) { }

    }
}