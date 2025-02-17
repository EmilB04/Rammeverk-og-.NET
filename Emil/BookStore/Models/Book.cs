using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emil.BookStore.Models;

namespace Emil.BookStore
{
    public class Book
    {
        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the ISBN of the book.
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// Gets or sets the price of the book.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the book in stock.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the book is discounted.
        /// </summary>
        public bool IsDiscounted { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the book.
        /// </summary>
        public Discount? AppliedDiscount { get; set; }

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
        public Book(string title, string author, string isbn, double price, int quantity, bool isDiscounted = false, Discount? appliedDiscount = null )
        {
            // Copilot-prompt: "Do I need curly braces for this if-statement since it's so long with only one line?"
            // Copilot-result : Answered "No" to the prompt
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
            if (isDiscounted != true && isDiscounted != false)
                throw new ArgumentException(nameof(isDiscounted), "IsDiscounted must be true or false. Please enter a valid value.");
            if (isDiscounted == true && appliedDiscount == null)
                throw new ArgumentNullException(nameof(appliedDiscount), "AppliedDiscount cannot be null when IsDiscounted is true. Please enter a valid discount.");
            if (isDiscounted == false && appliedDiscount != null)
                throw new ArgumentException(nameof(appliedDiscount), "AppliedDiscount must be null when IsDiscounted is false. Please enter a valid value.");

            Title = title;
            Author = author;
            Isbn = isbn;
            Price = price;
            Quantity = quantity;
            IsDiscounted = isDiscounted;
            AppliedDiscount = appliedDiscount;
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