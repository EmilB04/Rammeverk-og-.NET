using System;
using System.Collections.Generic;

namespace HIOF.V2025.Arbeidskrav1.BookStore
{
    public class BookStoreManager
    {
        private List<Book> _books;
        private List<Customer> _customers;

        public BookStoreManager()
        {
            _books = new List<Book>();
            _customers = new List<Customer>();
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            }
            _books.Add(book);
        }

        public Book FindBookByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null, empty, or whitespace.", nameof(title));
            }

            foreach (var book in _books)
            {
                if (book.Title == title)
                {
                    return book;
                }
            }

            return null; // Returner null hvis boken ikke finnes
        }

        public Book FindBookByIsbn(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("ISBN cannot be null, empty, or whitespace.", nameof(isbn));
            }

            foreach (var book in _books)
            {
                if (book.Isbn == isbn)
                {
                    return book;
                }
            }

            return null; // Returner null hvis boken ikke finnes
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                throw new ArgumentException("First name cannot be null, empty, or whitespace.", nameof(customer.FirstName));
            }

            _customers.Add(customer);
        }

        public Customer FindCustomer(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null, empty, or whitespace.", nameof(firstName));
            }

            foreach (var customer in _customers)
            {
                if (customer.FirstName == firstName)
                {
                    return customer;
                }
            }

            return null; // Returner null hvis kunden ikke finnes
        }
    }
}
