using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore
{
    /// <summary>
    /// Represents a book in the bookstore
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The title of the book
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The name of the author of the book
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// The ISBN number of the book
        /// </summary>
        public string Isbn { get; set; }
        /// <summary>
        /// The price of the book
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// The quantity of the book
        /// </summary>
        public double Quantity { get; set; }


        /// <summary>
        /// Creates a new instance of book
        /// </summary>
        /// <param name="title"></param>
        /// <param name="authorName"></param>
        /// <param name="isbn"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Book(string title, string authorName, string isbn, double price, double quantity)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            AuthorName = authorName ?? throw new ArgumentNullException(nameof(authorName));
            Isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));
            Price = price;
            Quantity = quantity;
        }

        /// <summary>
        /// Returns a string representation of the book
        /// </summary>
        public override string ToString()
        {
            return $"Title: {Title}, Author: {AuthorName}, ISBN: {Isbn}, Price: {Price}, Quantity: {Quantity}";
        }
    }
}