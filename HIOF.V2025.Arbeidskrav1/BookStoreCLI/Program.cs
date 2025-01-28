using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav1.BookStore;
using HIOF.V2025.Arbeidskrav1.BookStore.Services;

namespace HIOF.V2025.Arbeidskrav1.BookStoreCLI
{
    public class Program
    {
        static void Main()
        {
            var bookStoreManager = new BookStoreManager();
            var customerManager = new CustomerManager();
            var orderManager = new OrderManager(bookStoreManager, customerManager);
            var menu = new Menu(bookStoreManager, orderManager, customerManager);

            // Ferdiglagde bøker og kunder
            bookStoreManager.AddBook(new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, 2));
            bookStoreManager.AddBook(new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "978-82-02-24352-4", 199.50, 5));
            bookStoreManager.AddBook(new Book("Harry Potter and the Chamber of Secrets", "J.K. Rowling", "978-82-02-24353-1", 199.50, 5));
            bookStoreManager.AddBook(new Book("Harry Potter and the Prisoner of Azkaban", "J.K. Rowling", "978-82-02-24354-8", 199.50, 5));
            bookStoreManager.AddBook(new Book("Harry Potter and the Goblet of Fire", "J.K. Rowling", "978-82-02-24355-5", 199.50, 5));
            bookStoreManager.AddBook(new Book("Harry Potter and the Order of the Phoenix", "J.K. Rowling", "978-82-02-24356-2", 199.50, 5));
            bookStoreManager.AddBook(new Book("Harry Potter and the Half-Blood Prince", "J.K. Rowling", "978-82-02-24357-9", 199.50, 5));

            customerManager.AddCustomer(new Customer("Emil", "Berglund", "emilbe@hiof.no", 91234567));
            customerManager.AddCustomer(new Customer("Ola", "Nordmann", "olanordmann@hiof.no", 12345678));
            customerManager.AddCustomer(new Customer("Kari", "Nordmann", "karinordmann@hiof.no", 87654321));

            Console.WriteLine("Welcome to the Book Store CLI!");
            menu.Show();

        }
    }
}