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

        public Book(string title, string author, string isbn, double price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("Title, Author, and ISBN cannot be empty.");
            if (price <= 0 || quantity < 0)
                throw new ArgumentException("Price must be positive and quantity cannot be negative.");

            Title = title;
            Author = author;
            Isbn = isbn;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} (ISBN: {Isbn}) - ${Price} | Quantity: {Quantity}";
        }
    }
}