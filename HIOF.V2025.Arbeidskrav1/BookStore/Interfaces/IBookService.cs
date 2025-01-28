using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Interfaces
{
    public interface IBookService
    {
        // Books CRUD
        public void AddBook(Book book);
        public void RemoveBook(Book book);
        public void UpdateBook(Book book);
        Book GetBookByIsbn(string isbn);
        Book GetBookByTitle(string title);
        List<Book> GetAllBooks();
        List<Book> GetBooksByAuthor(string author);
    }
}