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
            - legge til bøker i systemet                        - OK
            - Søke etter bøker basert på tittel eller ISBN      - OK
            - Simulere et kjøp
    */
    public class Program
    {
        static void Main(string[] args)
        {
            BookStoreManager bookStoreManager = new BookStoreManager();

            // Ferdiglagde bøker og kunder
            bookStoreManager.AddBook(new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, 2));
            bookStoreManager.AddBook(new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "978-82-02-24352-4", 199.50, 5));
            bookStoreManager.AddBook(new Book("Harry Potter and the Chamber of Secrets", "J.K. Rowling", "978-82-02-24353-1", 199.50, 5));
            bookStoreManager.AddBook(new Book("Harry Potter and the Prisoner of Azkaban", "J.K. Rowling", "978-82-02-24354-8", 199.50, 5));
            bookStoreManager.AddBook(new Book("Harry Potter and the Goblet of Fire", "J.K. Rowling", "978-82-02-24355-5", 199.50, 5));
            bookStoreManager.AddBook(new Book("Harry Potter and the Order of the Phoenix", "J.K. Rowling", "978-82-02-24356-2", 199.50, 5));
            bookStoreManager.AddBook(new Book("Harry Potter and the Half-Blood Prince", "J.K. Rowling", "978-82-02-24357-9", 199.50, 5));

            bookStoreManager.AddCustomer((new Customer("Emil", "Berglund", "emilbe@hiof.no", 91234567)));
            bookStoreManager.AddCustomer((new Customer("Ola", "Nordmann", "olanordmann@hiof.no", 12345678)));
            bookStoreManager.AddCustomer((new Customer("Kari", "Nordmann", "karinordmann@hiof.no", 87654321)));

            /*
            // Show books
            Console.WriteLine();
            Console.WriteLine("Books in store:");
            bookStoreManager.PrintAllBooks();

            // Show customers
            Console.WriteLine();
            Console.WriteLine("Customers in store:");
            bookStoreManager.PrintAllCustomers();

            // Search after books
            Console.WriteLine();
            Console.WriteLine("Search for book by title:");
            Book book = bookStoreManager.FindBookByTitle("Harry Potter and the Philosopher's Stone");
            Console.WriteLine(book);

            Console.WriteLine("Search for book by ISBN:");
            book = bookStoreManager.FindBookByIsbn("978-82-02-24357-9");
            Console.WriteLine(book);

            // Search after customers
            Console.WriteLine();
            Console.WriteLine("Search for customer by name:");
            Customer customer = bookStoreManager.FindCustomerByName("Emil", "Berglund");
            Console.WriteLine(customer);
            Console.WriteLine("Search for a non-existing person:");
            Customer nonExistingCustomer = bookStoreManager.FindCustomerByName("Emil", "Nordmann");
            Console.WriteLine(nonExistingCustomer);
            */




            
            Console.WriteLine("Welcome to the Book Store CLI!");
            while (true)
            {
                ShowMenu();
                GetInput(bookStoreManager);

            
            }
            
        }

        private static void ShowMenu()
        {
            Console.WriteLine();
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
        private static void GetInput(BookStoreManager BookStoreManager)
        {
            string input = Console.ReadLine();
            Console.WriteLine();
            if (input == "1") // OK
            {
                Console.WriteLine("Provide the following information to add a book:");
                Console.WriteLine("Title:");
                string title = Console.ReadLine();
                Console.WriteLine("Author:");
                string author = Console.ReadLine();
                Console.WriteLine("ISBN:");
                string isbn = Console.ReadLine();
                Console.WriteLine("Price:");
                double price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Quantity:");
                double quantity = Convert.ToDouble(Console.ReadLine());
                Book book = new Book(title, author, isbn, price, quantity);
                BookStoreManager.AddBook(book);
                Console.WriteLine("Book added: " + book);
            }
            else if (input == "2") // OK (Tar ikke høyde for feilskriving av tlfnummer)
            {
                Console.WriteLine("Provide the following information to add a customer:");
                Console.WriteLine("First name:");
                string firstName = Console.ReadLine();
                Console.WriteLine("Last name:");
                string lastName = Console.ReadLine();
                Console.WriteLine("Email:");
                string email = Console.ReadLine();
                Console.WriteLine("Phone number:");
                int phoneNumber = Convert.ToInt32(Console.ReadLine());
                Customer customer = new Customer(firstName, lastName, email, phoneNumber);
                BookStoreManager.AddCustomer(customer);
                Console.WriteLine("Customer added: " + customer);
            }
            else if (input == "3") // OK
            {
                Console.WriteLine("Enter the title of the book you are looking for:");
                string titleInput = Console.ReadLine();
                Book book = BookStoreManager.FindBookByTitle(titleInput);
                Console.WriteLine(book);
            }
            else if (input == "4") // OK
            {
                Console.WriteLine("Enter the ISBN of the book you are looking for:");
                string isbnInput = Console.ReadLine();
                Book book = BookStoreManager.FindBookByIsbn(isbnInput);
                Console.WriteLine(book);
            }
            else if (input == "5") // OK
            {
                BookStoreManager.CreateOrder();
            }
            else if (input == "6") // OK
            {
                BookStoreManager.PrintAllBooks();
            }
            else if (input == "7") // OK
            {
                BookStoreManager.PrintAllCustomers();
            }
            else if (input == "8")
            {
                BookStoreManager.PrintAllOrders();
            }
            else if (input == "9") // OK
            {
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            }
            else                   // OK 
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        }
    
    
    
    
    }
}