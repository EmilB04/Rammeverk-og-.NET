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

        // Book methods DONE - missing inventory functionality
        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            }
            else if ((string.IsNullOrWhiteSpace(book.Title)) || string.IsNullOrWhiteSpace(book.AuthorName) || string.IsNullOrWhiteSpace(book.Isbn))
            {
                throw new ArgumentException("Every field needs to be filled out", nameof(book.Title));
            }
            else
            {
                _books.Add(book);
            }
        }
        public Book FindBookByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null, empty, or whitespace.", nameof(title));
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
                Console.WriteLine("Book not found");
            }
            return null; // Return null if no book is found
        }
        public Book FindBookByIsbn(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("ISBN cannot be null, empty, or whitespace.", nameof(isbn));
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
                Console.WriteLine("Book not found");
            }
            return null; // Return null if no book is found
        }
        public void AddCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                throw new ArgumentException("First name cannot be null, empty, or whitespace.", nameof(customer.FirstName));
            }

            else
            {
                _customers.Add(customer);
            }
        }
        public void PrintAllBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("No books in the store.");
            }
            else
            {
                foreach (var book in _books)
                {
                    Console.WriteLine(book);
                }
            }
        }
        public void PrintAllCustomers()
        {
            if (_customers.Count == 0)
            {
                Console.WriteLine("No customers in the store.");
            }
            else
            {
                foreach (var customer in _customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }
        // Customer methods DONE
        public Customer FindCustomerByName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("First name and last name cannot be null, empty, or whitespace.");
            }

            else
            {
                foreach (var customer in _customers)
                {
                    if (customer.FirstName == firstName && customer.LastName == lastName)
                    {
                        return customer;
                    }
                }
                Console.WriteLine($"Customer '{firstName} {lastName}' not found");
            }
            return null;
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
                Console.WriteLine($"Customer with firstname '{firstName}' was not found");
            }
            return null;
        }
        public Customer FindCustomerByLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Last name cannot be null, empty, or whitespace.");
            }

            else
            {
                foreach (var customer in _customers)
                {
                    if (customer.LastName == lastName)
                    {
                        return customer;
                    }
                }
                Console.WriteLine($"Customer with last name '{lastName}' was not found");
            }
            return null;
        }
        public Customer FindCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be null, empty, or whitespace.");
            }

            else
            {
                foreach (var customer in _customers)
                {
                    if (customer.Email == email)
                    {
                        return customer;
                    }
                }
                Console.WriteLine($"Customer with email '{email}' was not found");
            }
            return null;
        }
        public Customer FindCustomerByPhoneNumber(int phoneNumber)
        {
            foreach (var customer in _customers)
            {
                if (customer.PhoneNumber == phoneNumber)
                {
                    return customer;
                }
            }
            Console.WriteLine($"Customer with phone number '{phoneNumber}' was not found");
            return null;
        }

        // Order methods - NOT DONE

    }
}
