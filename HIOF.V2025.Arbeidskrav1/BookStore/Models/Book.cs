using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// <exception cref="ArgumentException">Thrown when title, author, or isbn is null, empty, or whitespace, or when price is less than or equal to zero, or when quantity is negative.</exception>
        public Book(string title, string author, string isbn, double price, int quantity)
        {
            // Copilot-prompt: "Do I need curly braces for this if-statement since it's so long with only one line?"
            // Copilot-result: Copilot said yes and removed the curly braces from the if-statements and suggested the current format.
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentNullException("Title, Author, and ISBN cannot be empty." + "Please enter a valid title, author, and ISBN.");
            if (price <= 0) throw new ArgumentException("Price must be positive." + "Please enter a valid price.");
            if (quantity < 0) throw new ArgumentException("Quantity must be positive." + "Please enter a valid quantity.");

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