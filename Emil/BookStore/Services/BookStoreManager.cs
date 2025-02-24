using System;
using System.Collections.Generic;
using System.Dynamic;
using Emil.BookStore.Exceptions;
using Emil.BookStore.Interfaces;
using Emil.BookStore.Models;
using Emil.BookStore.Services;

namespace Emil.BookStore
{
    public class BookStoreManager : IBookService
    {
        private List<Book> _books;

        /// <summary>
        /// Represents a collection of books managed by the BookStoreManager.
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
                throw new ArgumentNullException(nameof(book), "Entered book is null, please enter a valid book.");
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Entered title is null, empty, or whitespace. Enter a valid title.");
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new ArgumentException("Entered author is null, empty, or whitespace. Enter a valid author.");
            if (string.IsNullOrWhiteSpace(book.Isbn))
                throw new ArgumentException("Entered ISBN is null, empty, or whitespace. Enter a valid ISBN.");
            if (_books.Exists(b => b.Isbn == book.Isbn))
                throw new ArgumentException("A book with the same ISBN already exists. Enter a unique ISBN.");
            if (book.Price <= 0)
                throw new ArgumentOutOfRangeException(nameof(book.Price), "Price cannot be zero or negative. Enter a valid price.");
            if (double.IsNaN(book.Price))
                throw new ArgumentException("Entered price is not a number. Enter a valid price.");
            if (book.Quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(book.Quantity), "Quantity cannot be negative. Enter a positive quantity.");
            _books.Add(book);
            Console.WriteLine("Book added successfully.");
        }

        /// <summary>
        /// Removes a book from the store.
        /// </summary>
        /// <param name="book">The book to be removed.</param>
        /// <exception cref="ArgumentNullException">Thrown when the book is null.</exception>
        /// <exception cref="ArgumentException">Thrown when title, author, or isbn is null, empty, or whitespace.</exception>
        /// <exception cref="OutOfStockException">Thrown when the book is not found.</exception>
        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null. Enter a valid book.");
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Title cannot be empty. Enter a valid title.");
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new ArgumentException("Author cannot be empty. Enter a valid author.");
            if (string.IsNullOrWhiteSpace(book.Isbn))
                throw new ArgumentException("ISBN cannot be empty. Enter a valid ISBN.");
            if (!_books.Contains(book))
                throw new OutOfStockException("Book not found.");

            _books.Remove(book);
            Console.WriteLine("Book removed successfully.");
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
        /// Returns the book if found or null if not found.
        /// </summary>
        /// <param name="title">The title of the book to be retrieved.</param>
        /// <returns>The book with the specified title, if found.</returns>
        /// <exception cref="ArgumentException">Thrown when the title is null, empty, or whitespace.</exception>
        public Book? GetBookByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException(nameof(title), "Title cannot be null, empty, or whitespace. Enter a valid title.");
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
        /// Returns the book if found, or null if not found.
        /// </summary>
        /// <param name="isbn">The ISBN of the book to be retrieved.</param>
        /// <returns>The book with the specified ISBN, if found.</returns>
        /// <exception cref="ArgumentException">Thrown when the ISBN is null, empty, or whitespace.</exception>
        public Book? GetBookByIsbn(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException(nameof(isbn), "ISBN cannot be null, empty, or whitespace. Enter a valid ISBN.");
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
        /// Gets a book by title or ISBN.
        /// Returns the book if found, or null if not found.
        /// </summary>
        /// <param name="titleOrIsbn">The title or ISBN of the book to be retrieved.</param>
        /// <returns>The book with the specified title or ISBN, if found.</returns>
        /// <exception cref="ArgumentException">Thrown when the title or ISBN is null, empty, or whitespace.</exception>
        public Book? GetBookByTitleOrIsbn(string titleOrIsbn)
        {
            if (string.IsNullOrWhiteSpace(titleOrIsbn)) 
                throw new ArgumentException(nameof(titleOrIsbn), "Title or ISBN cannot be null, empty, or whitespace. Enter a valid title or ISBN.");
            var book = GetBookByTitle(titleOrIsbn) ?? GetBookByIsbn(titleOrIsbn);
            if (book != null)
            {
                return book;
            }
            else
            {
                Console.WriteLine($"Book with title or ISBN '{titleOrIsbn}' was not found");
                return null;
            }
        }

        /// <summary>
        /// Gets all books by author.
        /// NOT IMPLEMENTED YET.
        /// </summary>
        /// <param name="author">The author whose books are to be retrieved.</param>
        /// <returns>A list of books by the specified author.</returns>
        /// <exception cref="ArgumentException">Thrown when the author is null, empty, or whitespace.</exception>
        public List<Book>? GetBooksByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException(nameof(author), "Author cannot be null, empty, or whitespace. Enter a valid author.");
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
        /// Updates the stock of a book.
        /// </summary>
        /// <param name="book">The book to update.</param>
        /// <param name="quantityChange">The quantity to add or remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the quantity is negative.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the book is null.</exception>
        /// <exception cref="OutOfStockException">Thrown when the book is not found.</exception>
        public void UpdateBookStock(Book book, int quantityChange)
        {
            if (quantityChange == 0)
                throw new ArgumentOutOfRangeException(nameof(quantityChange), "Quantity change cannot be zero. Enter a positive or negative quantity.");
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book not found.");
            if (!_books.Contains(book))
                throw new OutOfStockException("Book not found.");
            if (book.Quantity + quantityChange < 0)
                throw new ArgumentOutOfRangeException(nameof(book.Quantity), "Quantity cannot be negative. Enter a positive quantity.");
            else
            {
                book.Quantity += quantityChange;
                Console.WriteLine("Stock updated successfully.");
            }
        }
        
        /// <summary>
        /// Gets the stock quantity of a book.
        /// </summary>
        /// <param name="book">The book to check.</param>
        /// <returns>The stock quantity of the book.</returns>
        /// <exception cref="OutOfStockException">Thrown when the book is not found.</exception>
        public int GetStockQuantity(Book book)
        {
            if (book != null)
            {
                return book.Quantity;
            }
            else
            {
                throw new OutOfStockException("Book not found.");
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
        /// <exception cref="ArgumentNullException">Thrown when the book is null.</exception>
        /// <exception cref="OutOfStockException">Thrown when the book is not found.</exception>
        public bool IsBookDiscounted(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null. Enter a valid book.");
            if (!_books.Contains(book))
                throw new OutOfStockException("Book not found.");
            if (book.IsDiscounted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets all books in the store.
        /// </summary>
        /// <returns>A list of all books in the store.</returns>
        /// <exception cref="OutOfStockException">Thrown when there are no books in the store.</exception>
        public List<Book> GetAllBooks()
        {
            if (_books.Count == 0)
                throw new OutOfStockException("No books in the store.");
            return _books;
        }

        /// <summary>
        /// Prints all discounted books in the store.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when there are no books in the store.</exception>
        public void PrintAllDiscountedBooks()
        {
            if (!FeatureFlags.EnableDiscounts)
            {
                Console.WriteLine("Discounts are currently disabled.");
                return;
            }

            if (_books.Count == 0)
            {
                Console.WriteLine("No books in the store.");
                return;
            }

            bool hasDiscountedBooks = false;
            foreach (var book in _books)
            {
                if (book.IsDiscounted && book.AppliedDiscount != null)
                {
                    hasDiscountedBooks = true;
                    var discount = book.AppliedDiscount;
                    string discountDetails = discount.Amount.HasValue
                        ? $"Amount: {discount.Amount.Value:C}"
                        : $"Percentage: {(discount.Percentage.HasValue ? discount.Percentage.Value.ToString() : "N/A")}%";
                    Console.WriteLine($"Title: {book.Title}, Discount: {discountDetails}");
                }
            }

            if (!hasDiscountedBooks)
            {
                Console.WriteLine("No discounted books available.");
            }
        }

        /// <summary>
        /// Gets all discounted books in the store.
        /// </summary>
        /// <returns>A list of all discounted books in the store.</returns>
        /// <exception cref="ArgumentException">Thrown when there are no books in the store.</exception>
        /// <exception cref="ArgumentException">Thrown when provied discount code is null, empty, or whitespace.</exception>
        public List<Book> GetBooksWithDiscount(string discountCode)
        {
            if (!FeatureFlags.EnableDiscounts)
            {
                Console.WriteLine("Discounts are currently disabled.");
                return new List<Book>();
            }

            if (_books.Count == 0)
                throw new OutOfStockException("No books in the store.");
            if (string.IsNullOrWhiteSpace(discountCode))
                throw new ArgumentException("Discount code cannot be null, empty, or whitespace.");

            List<Book> discountedBooks = new List<Book>();
            foreach (var book in _books)
            {
                if (book.IsDiscounted && book.AppliedDiscount != null)
                {
                    var discount = book.AppliedDiscount;
                    if (discount.Code == discountCode)
                    {
                        discountedBooks.Add(book);
                    }
                }
            }

            if (discountedBooks.Count == 0)
            {
                Console.WriteLine("No books with the specified discount code found.");
            }

            return discountedBooks;
        }
    }
}

