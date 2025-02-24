using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emil.BookStore;
using Emil.BookStore.Services;
using Emil.BookStore.Models;

namespace Emil.BookStoreCLI
{
    /// <summary>
    /// Class for the menu of the BookStoreCLI.
    /// Contains methods for showing the menu and adding books, customers, and orders.
    /// The menu is used to interact with the BookStoreManager, OrderManager, and CustomerManager.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var bookStoreManager = new BookStoreManager();
            var customerManager = new CustomerManager();
            var DiscountManager = new DiscountManager();
            var orderManager = new OrderManager(bookStoreManager, customerManager);
            var menu = new Menu(bookStoreManager, orderManager, customerManager, DiscountManager);

            // Ferdiglagde bøker og kunder
            // Copilot prompt: "Add some example books and customers"
            // Copilot-result : Added some books and customers
            bookStoreManager.AddBook(new PhysicalBook("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, 2));
            bookStoreManager.AddBook(new PhysicalBook("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "978-82-02-24352-4", 199.50, 5));
            bookStoreManager.AddBook(new PhysicalBook("Harry Potter and the Chamber of Secrets", "J.K. Rowling", "978-82-02-24353-1", 199.50, 5));
            bookStoreManager.AddBook(new PhysicalBook("Harry Potter and the Prisoner of Azkaban", "J.K. Rowling", "978-82-02-24354-8", 199.50, 5));
            bookStoreManager.AddBook(new PhysicalBook("Harry Potter and the Goblet of Fire", "J.K. Rowling", "978-82-02-24355-5", 199.50, 5));
            bookStoreManager.AddBook(new PhysicalBook("Harry Potter and the Order of the Phoenix", "J.K. Rowling", "978-82-02-24356-2", 199.50, 5));
            bookStoreManager.AddBook(new PhysicalBook("Harry Potter and the Half-Blood Prince", "J.K. Rowling", "978-82-02-24357-9", 199.50, 5));

            customerManager.AddCustomer(new Customer("Emil", "Berglund", "emilbe@hiof.no", 91234567));
            customerManager.AddCustomer(new Customer("Ola", "Nordmann", "olanordmann@hiof.no", 12345678));
            customerManager.AddCustomer(new Customer("Kari", "Nordmann", "karinordmann@hiof.no", 87654321));

            orderManager.NewOrder("Emil", "Berglund", "Harry Potter and the Half-Blood Prince", 3);

            DiscountManager.AddDiscountToInventory(new Discount("25OFF", 25, DateTime.Parse("2024-06-01"), DateTime.Parse("2026-08-31")));
            var discount = DiscountManager.GetDiscountByCode("25OFF");
            var book = bookStoreManager.GetBookByTitle("Harry Potter and the Half-Blood Prince");

            if (discount != null && book != null)
                DiscountManager.AddDiscountToBook(discount, book);

            Console.WriteLine("---------------------------------");
            Console.WriteLine("\nWelcome to the Book Store CLI!");
            menu.Show();

        }
    }
}