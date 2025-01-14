using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            _books.Add(book);
        }
        public findBook(string title)
        {
            foreach (var book in _books)
                {
                    if (book.Title == title)
                    {
                        return book;
                    }
                }
        }
        public findBook(double isbn)
        {
            foreach (var book in _books)
                {
                    if (book.Isbn == isbn)
                    {
                        return book;
                    }
                }
        }



    }


}