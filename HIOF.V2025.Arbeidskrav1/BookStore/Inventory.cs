using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore
{
    public class Inventory
    {
        private List<Book> _inventory;

        public Inventory()
        {
            _inventory = new List<Book>();
        }

        public void AddBookToInventory(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            }
            _inventory.Add(book);
        }

        public void RemoveBookFromInventory(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            }
            _inventory.Remove(book);
        }

        public List<Book> GetBooksFromInventory()
        {
            return _inventory;
        }

    }
}