using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore
{
    public class Book
    {
        private string _title;
        private string _authorName;
        private string _isbn;
        private double _price;

        public Book(string title, string authorName, string isbn, double price)
        {
            _title = title;
            _authorName = authorName;
            _isbn = isbn;
            _price = price;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string AuthorName
        {
            get => _authorName;
            set => _authorName = value;
        }

        public string Isbn
        {
            get => _isbn;
            set => _isbn = value;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }
    }
}