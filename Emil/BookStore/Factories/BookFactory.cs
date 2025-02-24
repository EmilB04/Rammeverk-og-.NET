using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emil.BookStore.Models;

namespace Emil.BookStore.Factories
{
    public static class BookFactory
    {
        /// <summary>
        /// NOT IN USE
        /// Creates a book of the specified type.
        /// </summary>
        /// <param name="type">The type of book to create (e.g., "Physical", "Digital").</param>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="isbn">The ISBN of the book.</param>
        /// <param name="price">The price of the book.</param>
        /// <param name="quantity">The quantity of the book in stock.</param>
        /// <returns>A new instance of the specified book type.</returns>
        /// <exception cref="ArgumentException">Thrown when the book type is invalid.</exception>
        public static Book CreateBook(string type, string title, string author, string isbn, double price, int quantity)
        {
            return type switch
            {
                "Physical" => new PhysicalBook(title, author, isbn, price, quantity),
                "Digital" => new DigitalBook(title, author, isbn, price, quantity),
                _ => throw new ArgumentException("Invalid book type")
            };
        }
    }
}