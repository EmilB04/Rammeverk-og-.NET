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
            string input = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();
            if (input == "1") // OK
            {
                string title = string.Empty;
                string author = string.Empty;
                string isbn = string.Empty;
                double price = 0;
                int quantity = 0;

                while (true)
                {
                    Console.WriteLine("Provide the following information to add a book:");
                    while (true) // Title
                    {
                        Console.Write("Title: ");
                        title = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine("Title cannot be empty.");
                        }
                        else
                        {
                            try
                            {
                                int number = Convert.ToInt32(title);
                                Console.WriteLine("Title cannot be a number.");
                            }
                            catch (Exception)
                            {
                                break;
                            }
                        }
                    }
                    while (true) // Author
                    {
                        Console.Write("Author: ");
                        author = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(author))
                        {
                            Console.WriteLine("Author cannot be empty.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    while (true) // ISBN
                    {
                        Console.Write("ISBN: ");
                        isbn = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(isbn))
                        {
                            Console.WriteLine("ISBN cannot be empty.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    while (true) // Price
                    {
                        Console.Write("Price: ");
                        string priceInput = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(priceInput))
                        {
                            Console.WriteLine("Price cannot be empty.");
                        }
                        else
                        {
                            try
                            {
                                price = Convert.ToDouble(priceInput);
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Price must be a number.");
                            }
                        }
                    }
                    while (true) // Quantity
                    {
                        Console.Write("Quantity: ");
                        string quantityInput = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(quantityInput))
                        {
                            Console.WriteLine("Quantity cannot be empty.");
                        }
                        else
                        {
                            try
                            {
                                quantity = Convert.ToInt32(quantityInput);
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Quantity must be a number.");
                            }
                        }
                    }
                    break;
                }
                var book = new Book(title, author, isbn, price, quantity);
                BookStoreManager.AddBook(book);
                Console.WriteLine("Book added: " + book);
            }
            else if (input == "2") // OK
            {
                string firstName = string.Empty;
                string lastName = string.Empty;
                string email = string.Empty;
                int phoneNumber = 0;

                while (true)
                {
                    Console.WriteLine("Provide the following information to add a customer:");
                    while (true) // First name
                    {
                        Console.Write("First name: ");
                        firstName = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(firstName))
                        {
                            Console.WriteLine("First name cannot be empty.");
                        }
                        else
                        {
                            try
                            {
                                int number = Convert.ToInt32(firstName);
                                Console.WriteLine("First name cannot be a number.");
                            }
                            catch (Exception)
                            {
                                break;
                            }
                        }
                    }
                    while (true) // Last name
                    {
                        Console.Write("Last name: ");
                        lastName = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(lastName))
                        {
                            Console.WriteLine("Last name cannot be empty.");
                        }
                        else
                        {
                            try
                            {
                                int number = Convert.ToInt32(lastName);
                                Console.WriteLine("Last name cannot be a number.");
                            }
                            catch (Exception)
                            {
                                break;
                            }
                        }
                    }
                    while (true) // Email
                    {
                        Console.Write("Email: ");
                        email = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(email))
                        {
                            Console.WriteLine("Email cannot be empty.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    while (true) // Phone number
                    {
                        Console.Write("Phone number: ");
                        string phoneNumberInput = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(phoneNumberInput))
                        {
                            Console.WriteLine("Phone number cannot be empty.");
                        }
                        else
                        {
                            try
                            {
                                phoneNumber = Convert.ToInt32(phoneNumberInput);
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Phone number must be a number.");
                            }
                        }
                    }
                    break;
                }
                var customer = new Customer(firstName, lastName, email, phoneNumber);
                BookStoreManager.AddCustomer(customer);
                Console.WriteLine("Customer added: " + customer);
            }
            else if (input == "3") // OK
            {
                string titleInput = string.Empty;
                while (true)
                {
                    Console.WriteLine("Enter the title of the book you are looking for:");
                    try
                    {
                        titleInput = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(titleInput))
                        {
                            Console.WriteLine("Title cannot be empty.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Title cannot be a number.");
                    }
                }
                Book book = BookStoreManager.FindBookByTitle(titleInput);
                Console.WriteLine(book);
            }
            else if (input == "4") // OK
            {
                string isbnInput = string.Empty;
                while (true)
                {
                    Console.WriteLine("Enter the ISBN of the book you are looking for:");
                    isbnInput = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(isbnInput))
                    {
                        Console.WriteLine("ISBN cannot be empty.");
                    }
                    else
                    {
                        break;
                    }
                }
                Book book = BookStoreManager.FindBookByIsbn(isbnInput);
                Console.WriteLine(book);
            }
            else if (input == "5") // OK
            {
                BookStoreManager.PurchaseBook();
            }
            else if (input == "6") // OK
            {
                BookStoreManager.PrintAllBooks();
            }
            else if (input == "7") // OK
            {
                BookStoreManager.PrintAllCustomers();
            }
            else if (input == "8") // OK
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