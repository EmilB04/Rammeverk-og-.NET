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
            else
            {
                _books.Add(book);
            }
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("Book cannot be null.");
            }
            else
            {
                foreach (var b in _books)
                {
                    if (b == book)
                    {
                        _books.Remove(b);
                        break;
                    }
                }
                Console.WriteLine("Book not found.");
            }
        }

        public Book FindBookByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be null, empty, or whitespace.");
            }
            else
            {
                foreach (var book in _books)
                {
                    if (book.Title == title)
                    {
                        return book;
                    }
                }
            }
            return null; // Return null if no book is found
        }

        public Book FindBookByIsbn(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("ISBN cannot be null, empty, or whitespace.");
            }
            else
            {
                foreach (var book in _books)
                {
                    if (book.Isbn == isbn)
                    {
                        return book;
                    }
                }
            }
            return null; // Return null if no book is found
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

            else
            {
                _customers.Add(customer);
            }
        }

        public Customer FindCustomerByFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("First name cannot be null, empty, or whitespace.");
            }

            else
            {
                foreach (var customer in _customers)
                {
                    if (customer.FirstName == firstName)
                    {
                        return customer;
                    }
                }
            }
            return null;
        }
    }
}
