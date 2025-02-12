using System;
using System.Collections.Generic;
using System.Dynamic;
using HIOF.V2025.Arbeidskrav2.BookStore.Interfaces;

// GOOD TO GO! 🚀

namespace HIOF.V2025.Arbeidskrav2.BookStore
{
    public class BookStoreManager : IBookService
    {
        private List<Book> _books;

        /// <summary>
        /// Constructor for BookStoreManager
        /// </summary>
        public BookStoreManager()
        {
            _books = new List<Book>();
        }

        /// <summary>
        /// Adds a book to the store.
        /// </summary>
        /// <param name="book">The book to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown when the book is null.</exception>
        /// <exception cref="ArgumentException">Thrown when title, author, or isbn is null, empty, or whitespace, or if a book with the same ISBN already exists.</exception>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null. Enter a valid book.");
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Title cannot be empty. Enter a valid title.");
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new ArgumentException("Author cannot be empty. Enter a valid author.");
            if (string.IsNullOrWhiteSpace(book.Isbn))
                throw new ArgumentException("ISBN cannot be empty. Enter a valid ISBN.");
            if (_books.Exists(b => b.Isbn == book.Isbn))
                throw new ArgumentException("A book with the same ISBN already exists. Enter a unique ISBN.");
            if (book.Price <= 0)
                throw new ArgumentOutOfRangeException(nameof(book.Price), "Price cannot be zero or negative. Enter a valid price.");
            if (double.IsNaN(book.Price))
                throw new ArgumentException("Price cannot be something other than a number. Enter a valid price.");
            if (book.Quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(book.Quantity), "Quantity cannot be negative. Enter a positive quantity.");
            _books.Add(book);
            Console.WriteLine("Book added successfully.");
        }

        /// <summary>
        /// Removes a book from the store.
        /// NOT IMPLEMENTED YET.
        /// </summary>
        /// <param name="book">The book to be removed.</param>
        /// <exception cref="ArgumentNullException">Thrown when the book is null.</exception>
        /// <exception cref="ArgumentException">Thrown when title, author, or isbn is null, empty, or whitespace.</exception>
        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null." + "Enter a valid book.");
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Title cannot be empty." + "Enter a valid title.");
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new ArgumentException("Author cannot be empty." + "Enter a valid author.");
            if (string.IsNullOrWhiteSpace(book.Isbn))
                throw new ArgumentException("ISBN cannot be empty." + "Enter a valid ISBN.");

            _books.Remove(book);
        }

        /// <summary>
        /// Prints all books in the store.
        /// Prints "No books in the store." if there are no books in the store.
        /// </summary>
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

        /// <summary>
        /// Gets a book by title.
        /// Returns the book if found.
        /// </summary>
        /// <param name="title">The title of the book to be retrieved.</param>
        /// <returns>The book with the specified title, if found.</returns>
        /// <exception cref="ArgumentException">Thrown when the title is null, empty, or whitespace.</exception>
        public Book GetBookByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException(nameof(title), "Title cannot be null, empty, or whitespace." + "Enter a valid title.");
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
                Console.WriteLine($"Book with title '{title}' was not found");
            }
            return null; // Return null if no book is found
        }

        /// <summary>
        /// Gets a book by ISBN.
        /// Returns the book if found.
        /// </summary>
        /// <param name="isbn">The ISBN of the book to be retrieved.</param>
        /// <returns>The book with the specified ISBN, if found.</returns>
        /// <exception cref="ArgumentException">Thrown when the ISBN is null, empty, or whitespace.</exception>
        public Book GetBookByIsbn(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException(nameof(isbn), "ISBN cannot be null, empty, or whitespace." + "Enter a valid ISBN.");
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
                Console.WriteLine($"Book with ISBN '{isbn}' was not found");
            }
            return null; // Return null if no book is found
        }

        /// <summary>
        /// Gets all books by author.
        /// NOT IMPLEMENTED YET.
        /// </summary>
        /// <param name="author">The author whose books are to be retrieved.</param>
        /// <returns>A list of books by the specified author.</returns>
        /// <exception cref="ArgumentException">Thrown when the author is null, empty, or whitespace.</exception>
        public List<Book> GetBooksByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException(nameof(author), "Author cannot be null, empty, or whitespace." + "Enter a valid author.");
            }
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

        /// <summary>
        /// Updates the stock quantity of a book by ISBN.
        /// Throws ArgumentException if the book is not found.
        /// </summary>
        /// <param name="isbn">The ISBN of the book whose stock is to be updated.</param>
        /// <param name="quantityChange">The change in quantity (positive or negative).</param>
        /// <exception cref="ArgumentException">Thrown when the book is not found.</exception>
        public void UpdateBookStock(string isbn, int quantityChange)
        {
            var book = GetBookByIsbn(isbn);
            if (book != null)
            {
                book.Quantity += quantityChange;
                Console.WriteLine("Stock updated successfully.");
            }
            else
            {
                throw new ArgumentException("Book not found.");
            }
        }
        public int GetStockQuantity(string isbn)
        {
            var book = GetBookByIsbn(isbn);
            if (book != null)
            {
                return book.Quantity;
            }
            else
            {
                throw new ArgumentException("Book not found.");
            }
        }

        /// <summary>
        /// Gets the total quantity of all books in the store.
        /// </summary>
        /// <returns>The total quantity of all books in the store.</returns>
        public int GetAllQuantity()
        {
            int totalQuantity = 0;
            foreach (var book in _books)
            {
                totalQuantity += book.Quantity;
            }
            return totalQuantity;
        }

        /// <summary>
        /// Checks if a book is discounted.
        /// </summary>
        /// <param name="book"></param>
        /// <returns>A boolean which tells if the book is discounted or not</returns>
        public bool IsBookDiscounted(Book book)
        {
            if (book.IsDiscounted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

