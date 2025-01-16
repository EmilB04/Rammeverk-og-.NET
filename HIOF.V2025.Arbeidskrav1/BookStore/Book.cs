using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore
{
    public class Book
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Isbn { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }

        public Book(string title, string authorName, string isbn, double price, double quantity)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            AuthorName = authorName ?? throw new ArgumentNullException(nameof(authorName));
            Isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));
            Price = price;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return $"Title: {Title}, Author: {AuthorName}, ISBN: {Isbn}, Price: {Price}, Quantity: {Quantity}";
        }
    }
}