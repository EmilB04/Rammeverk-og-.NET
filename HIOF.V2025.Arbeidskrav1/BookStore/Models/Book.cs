using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Good to go! 🚀
namespace HIOF.V2025.Arbeidskrav1.BookStore
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Constructor for Book.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="isbn">The ISBN of the book.</param>
        /// <param name="price">The price of the book.</param>
        /// <param name="quantity">The quantity of the book in stock.</param>
        /// <exception cref="ArgumentNullException">Thrown when title, author, or isbn is null, empty, or whitespace.</exception>
        /// <exception cref="ArgumentException">Thrown when price is less than or equal to zero, or when quantity is negative.</exception>
        public Book(string title, string author, string isbn, double price, int quantity)
        {
            // Copilot-prompt: "Do I need curly braces for this if-statement since it's so long with only one line?"
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title), "Title cannot be null, empty, or whitespace. Please enter a valid title.");
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentNullException(nameof(author), "Author cannot be null, empty, or whitespace. Please enter a valid author.");
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentNullException(nameof(isbn), "ISBN cannot be null, empty, or whitespace. Please enter a valid ISBN.");
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be zero or negative. Please enter a positive price.");
            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative. Please enter a positive quantity.");

            Title = title;
            Author = author;
            Isbn = isbn;
            Price = price;
            Quantity = quantity;
        }

        /// <summary>
        /// Returns a string that represents the current book.
        /// </summary>
        /// <returns>A string that represents the current book.</returns>
        public override string ToString()
        {
            return $"{Title} by {Author} (ISBN: {Isbn}) - ${Price} | Quantity: {Quantity}";
        }
    }
}