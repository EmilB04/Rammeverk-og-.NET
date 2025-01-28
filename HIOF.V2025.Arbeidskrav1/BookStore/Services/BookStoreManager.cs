using System;
using System.Collections.Generic;
using HIOF.V2025.Arbeidskrav1.BookStore.Interfaces;

// GOOD TO GO! 🚀

namespace HIOF.V2025.Arbeidskrav1.BookStore
{
    public class BookStoreManager : IBookService
    {
        private List<Book> _books;

        public BookStoreManager()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            if (string.IsNullOrWhiteSpace(book.Title)) throw new ArgumentException("Title cannot be empty.");
            if (string.IsNullOrWhiteSpace(book.Author)) throw new ArgumentException("Author cannot be empty.");
            if (string.IsNullOrWhiteSpace(book.Isbn)) throw new ArgumentException("ISBN cannot be empty.");
            if (_books.Exists(b => b.Isbn == book.Isbn))
                throw new ArgumentException("A book with the same ISBN already exists.");

            _books.Add(book);
            Console.WriteLine("Book added successfully.");
        }
        public void RemoveBook(Book book) // For further development
        {
            if (book == null) throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            if (string.IsNullOrWhiteSpace(book.Title)) throw new ArgumentException("Title cannot be empty.");
            if (string.IsNullOrWhiteSpace(book.Author)) throw new ArgumentException("Author cannot be empty.");
            if (string.IsNullOrWhiteSpace(book.Isbn)) throw new ArgumentException("ISBN cannot be empty.");

            _books.Remove(book);
        }
        public void PrintAllBooks()
        {
            if (_books.Count == 0) Console.WriteLine("No books in the store.");
            else
            {
                foreach (var book in _books)
                {
                    Console.WriteLine(book);
                }
            }
        }
        public Book GetBookByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title cannot be null, empty, or whitespace.", nameof(title));
            else
            {
                foreach (var book in _books)
                {
                    if (book.Title == title)
                    {
                        return book;
                    }
                }
                Console.WriteLine($"Book with title '{title}' was not found");
            }
            return null; // Return null if no book is found
        }
        public Book GetBookByIsbn(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn)) throw new ArgumentException("ISBN cannot be null, empty, or whitespace.", nameof(isbn));
            else
            {
                foreach (var book in _books)
                {
                    if (book.Isbn == isbn)
                    {
                        return book;
                    }
                }
                Console.WriteLine($"Book with ISBN '{isbn}' was not found");
            }
            return null; // Return null if no book is found
        }
        public List<Book> GetBooksByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Author cannot be null, empty, or whitespace.", nameof(author));
            else
            {
                List<Book> booksByAuthor = new List<Book>();
                foreach (var book in _books)
                {
                    if (book.Author == author)
                    {
                        booksByAuthor.Add(book);
                    }
                }
                return booksByAuthor;
            }
        }

        public void UpdateBookStock(string isbn, int quantityChange)
        {
            var book = GetBookByIsbn(isbn);
            if (book != null)
            {
                book.Quantity += quantityChange;
            }
            else
            {
                throw new ArgumentException("Book not found.");
            }
        }
    }
}

