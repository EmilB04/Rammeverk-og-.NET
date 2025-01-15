using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav1.BookStore;

namespace HIOF.V2025.Arbeidskrav1.BookStoreCLI
{


    // TODO!
    /*
        1. Implementer ordre-funksjonalitet i BookStoreManager
        2. Implementer funksjonalitet rundt beholdning, rabatter og bestillinger

        4. Se over dokument for mer


        Programmer skal kunne gjøre følgende:
            - legge til bøker i systemet
            - Søke etter bøker basert på tittel eller ISBN
            - Simulere et kjøp
    */
    public class Program
    {
        static void Main(string[] args)
        {
            BookStoreManager bookStoreManager = new BookStoreManager();

            // Ferdiglagde bøker og kunder
            bookStoreManager.AddBook(new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50));
            bookStoreManager.AddBook(new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "978-82-02-24352-4", 199.50));
            bookStoreManager.AddBook(new Book("Harry Potter and the Chamber of Secrets", "J.K. Rowling", "978-82-02-24353-1", 199.50));
            bookStoreManager.AddBook(new Book("Harry Potter and the Prisoner of Azkaban", "J.K. Rowling", "978-82-02-24354-8", 199.50));
            bookStoreManager.AddBook(new Book("Harry Potter and the Goblet of Fire", "J.K. Rowling", "978-82-02-24355-5", 199.50));
            bookStoreManager.AddBook(new Book("Harry Potter and the Order of the Phoenix", "J.K. Rowling", "978-82-02-24356-2", 199.50));
            bookStoreManager.AddBook(new Book("Harry Potter and the Half-Blood Prince", "J.K. Rowling", "978-82-02-24357-9", 199.50));

            bookStoreManager.AddCustomer((new Customer("Emil", "Berglund", "emilbe@hiof.no", 91234567)));
            bookStoreManager.AddCustomer((new Customer("Ola", "Nordmann", "olanordmann@hiof.no", 12345678)));
            bookStoreManager.AddCustomer((new Customer("Kari", "Nordmann", "karinordmann@hiof.no", 87654321)));

            Console.WriteLine("Welcome to the Book Store CLI!");
            while (true)
            {
                ShowMenu();
                GetInput();

            
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Add a customer");
            Console.WriteLine("3. Find a book by title");
            Console.WriteLine("4. Find a book by ISBN");
            Console.WriteLine("5. Create an order");
            Console.WriteLine("6. Show all books");
            Console.WriteLine("7. Show all customers");
            Console.WriteLine("8. Show all orders");
            Console.WriteLine("9. Exit");
        }
        private static void GetInput()
        {
            string input = Console.ReadLine();
            if (input == "1")
            {
                //AddBook();
            }
            else if (input == "2")
            {
                //AddCustomer();
            }
            else if (input == "3")
            {
                //FindBookByTitle();
            }
            else if (input == "4")
            {
                //FindBookByIsbn();
            }
            else if (input == "5")
            {
                //CreateOrder();
            }
            else if (input == "6")
            {
                //ShowAllBooks();
            }
            else if (input == "7")
            {
                //ShowAllCustomers();
            }
            else if (input == "8")
            {
                //ShowAllOrders();
            }
            else if (input == "9")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        }
    }
}