using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav1.BookStore;
namespace HIOF.V2025.Arbeidskrav1.BookStoreCLI
{
    public class Program
    {
        static void Main(string[] args) 
        {
            BookStoreManager bookStoreManager = new BookStoreManager();
            Book book1 = new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50);
            Book book2 = new Book("The Lord of the Rings", "J.R.R. Tolkien", "978-0-395-19395-7", 199.50);
            Customer customer1 = new Customer("Emil", "Berglund", "emilbe@hiof.no", 98189601);

            bookStoreManager.AddBook(book1);
            bookStoreManager.AddBook(book2);
            bookStoreManager.AddCustomer(customer1);

            Book foundBook = bookStoreManager.FindBook("The Hobbit");
            Console.Writeline(foundBook);

            Book foundBook = bookStoreManager.FindBook("978-0-395-07122-1");
            Console.Writeline(foundBook);

            Customer foundCustomer = bookStoreManager.FindCustomer("frodo");
            Console.Writeline(foundCustomer);
        }
    }
};