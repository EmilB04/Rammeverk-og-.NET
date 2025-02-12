using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav2.BookStore.Interfaces
{
    /// <summary>
    /// Interface for BookService.
    /// Contains methods for adding, removing, and printing books, as well as getting books by ISBN, title, and author.
    /// </summary>
    public interface IBookService
    {
        // Books CRUD
        public void AddBook(Book book);
        public void RemoveBook(Book book);
        public void PrintAllBooks();
        Book GetBookByIsbn(string isbn);
        Book GetBookByTitle(string title);
        List<Book> GetBooksByAuthor(string author);
    }
}