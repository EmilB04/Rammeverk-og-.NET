using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav2.BookStore;
using HIOF.V2025.Arbeidskrav2.BookStore.Interfaces;
using HIOF.V2025.Arbeidskrav2.BookStore.Services;

namespace HIOF.V2025.Arbeidskrav2.BookStoreCLI
{
    /// <summary>
    /// Class for the menu of the BookStoreCLI.
    /// Contains methods for showing the menu and adding books, customers, and orders.
    /// The menu is used to interact with the BookStoreManager, OrderManager, and CustomerManager.
    /// </summary>
    public class Menu
    {
        private readonly BookStoreManager _bookStoreManager;
        private readonly OrderManager _orderManager;
        private readonly CustomerManager _customerManager;


        public Menu(BookStoreManager bookStoreManager, OrderManager orderManager, CustomerManager customerManager)
        {
            _bookStoreManager = bookStoreManager;
            _orderManager = orderManager;
            _customerManager = customerManager;
        }
        public void Show()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Add a customer");
                Console.WriteLine("3. New order");
                Console.WriteLine("4. Print all books");
                Console.WriteLine("5. Print all customers");
                Console.WriteLine("6. Print all orders");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Choose an option:");
                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1": AddBook(); break;
                    case "2": AddCustomer(); break;
                    case "3": NewOrder(); break;
                    case "4": _bookStoreManager.PrintAllBooks(); break;
                    case "5": _customerManager.PrintAllCustomers(); break;
                    case "6": _orderManager.PrintAllOrders(); break;
                    case "7": Console.WriteLine("Goodbye!"); return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }





        private void AddBook()
        {
            Console.WriteLine("Enter the necessary information to add a book to the store.");

            string title;
            while (true)
            {
                Console.Write("Title: ");
                title = Console.ReadLine() ?? throw new ArgumentNullException(nameof(title));
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Title cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            string author;
            while (true)
            {
                Console.Write("Author: ");
                author = Console.ReadLine() ?? throw new ArgumentNullException(nameof(author));
                if (string.IsNullOrWhiteSpace(author))
                {
                    Console.WriteLine("Author cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            string isbn;
            while (true)
            {
                Console.Write("ISBN: ");
                isbn = Console.ReadLine() ?? throw new ArgumentNullException(nameof(isbn));
                if (string.IsNullOrWhiteSpace(isbn))
                {
                    Console.WriteLine("ISBN cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            double price;
            while (true)
            {
                Console.Write("Price: ");
                string priceInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(price));
                if (double.TryParse(priceInput, out price) && price > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid price. Please enter a positive number.");
                }
            }

            int quantity;
            while (true)
            {
                Console.Write("Quantity: ");
                string quantityInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(quantity));
                if (int.TryParse(quantityInput, out quantity) && quantity >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please enter a positive number.");
                }
            }

            try
            {
                _bookStoreManager.AddBook(new Book(title, author, isbn, price, quantity));
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: Missing input. {e.Message}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
        }
        private void AddCustomer()
        {
            Console.WriteLine("Enter the necessary information to add a customer to the store.");

            string firstName;
            while (true)
            {
                Console.Write("First name: ");
                firstName = Console.ReadLine() ?? throw new ArgumentNullException(nameof(firstName));
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("First name cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            string lastName;
            while (true)
            {
                Console.Write("Last name: ");
                lastName = Console.ReadLine() ?? throw new ArgumentNullException(nameof(lastName));
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Last name cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            string email;
            while (true)
            {
                Console.Write("Email: ");
                email = Console.ReadLine() ?? throw new ArgumentNullException(nameof(email));
                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Email cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            int phoneNumber;
            while (true)
            {
                Console.Write("Phone number: ");
                string phoneNumberInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(phoneNumber));
                if (int.TryParse(phoneNumberInput, out phoneNumber) && phoneNumber > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid phone number. Please enter a positive integer.");
                }
            }

            try
            {
                _customerManager.AddCustomer(new Customer(firstName, lastName, email, phoneNumber));
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: Missing input. {e.Message}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
        }
        private void NewOrder()
        {
            Console.WriteLine("Provide the following information to create an order:");

            string firstName;
            while (true) // firstName
            {
                Console.Write("Customer first name: ");
                firstName = Console.ReadLine() ?? throw new ArgumentNullException(nameof(firstName));
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("First name cannot be empty.");
                }
                else
                {
                    break;
                }
            }
            
            string lastName;
            while (true) // lastName
            {
                Console.Write("Customer last name: ");
                lastName = Console.ReadLine() ?? throw new ArgumentNullException(nameof(lastName));
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Last name cannot be empty.");
                }
                else
                {
                    break;
                }
            }
            
            string titleOrIsbn;
            while (true) // titleOrIsbn
            {
                Console.Write("Book title or ISBN: ");
                titleOrIsbn = Console.ReadLine() ?? throw new ArgumentNullException(nameof(titleOrIsbn));
                if (string.IsNullOrWhiteSpace(titleOrIsbn))
                {
                    Console.WriteLine("Title or ISBN cannot be empty.");
                    
                }
                else
                {
                    break;
                }
            }

            int quantity = 0;
            while (true) // quantity
            {
                Console.Write("Quantity: ");
                quantity = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(quantity)));
                if (quantity <= 0)
                {
                    Console.WriteLine("Quantity must be greater than 0.");
                    
                }
                else
                {
                    break;
                }
            }

            try
            {
                _orderManager.NewOrder(firstName, lastName, titleOrIsbn, quantity);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: Missing input. {e.Message}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
        }
    }
}