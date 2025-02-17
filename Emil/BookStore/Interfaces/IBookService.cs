using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emil.BookStore.Interfaces
{
    /// <summary>
    /// Interface for book service operations.
    /// </summary>
    /// <remarks>
    /// This interface is used to implement the BookStoreManager class
    /// </remarks>
    /// <seealso cref="BookStoreManger"/>
    /// <seealso cref="Book"/>
    public interface IBookService
    {
        /// <summary>
        /// Adds a new book to the collection.
        /// </summary>
        /// <param name="book">The book to add.</param>
        void AddBook(Book book);

        /// <summary>
        /// Removes a book from the collection.
        /// </summary>
        /// <param name="book">The book to remove.</param>
        void RemoveBook(Book book);

        /// <summary>
        /// Prints all books in the collection.
        /// </summary>
        void PrintAllBooks();

        /// <summary>
        /// Retrieves a book by its title.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <returns>The book with the specified title.</returns>
        Book GetBookByTitle(string title);

        /// <summary>
        /// Retrieves a book by its ISBN.
        /// </summary>
        /// <param name="isbn">The ISBN of the book.</param>
        /// <returns>The book with the specified ISBN.</returns>
        Book GetBookByIsbn(string isbn);

        /// <summary>
        /// Retrieves a book by its title or ISBN.
        /// </summary>
        /// <param name="titleOrIsbn">The title or ISBN of the book.</param>
        /// <returns>The book with the specified title or ISBN.</returns>
        Book GetBookByTitleOrIsbn(string titleOrIsbn);

        /// <summary>
        /// Retrieves a list of books by the author's name.
        /// </summary>
        /// <param name="author">The name of the author.</param>
        /// <returns>A list of books by the specified author.</returns>
        List<Book> GetBooksByAuthor(string author);

        /// <summary>
        /// Updates the stock of a book.
        /// </summary>
        /// <param name="book">The book to update.</param>
        /// <param name="quantity">The quantity to add or remove.</param>
        void UpdateBookStock(Book book, int quantity);

        /// <summary>
        /// Gets the stock quantity of a book.
        /// </summary>
        /// <param name="book">The book to check.</param>
        /// <returns>The stock quantity of the book.</returns>
        int GetStockQuantity(Book book);

        /// <summary>
        /// Checks if a book is discounted.
        /// </summary>
        /// <param name="book">The book to check.</param>
        /// <returns>True if the book is discounted, false otherwise.</returns>
        bool IsBookDiscounted(Book book);

    }
}