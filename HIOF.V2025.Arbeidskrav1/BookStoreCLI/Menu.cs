using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav1.BookStore;
using HIOF.V2025.Arbeidskrav1.BookStore.Interfaces;
using HIOF.V2025.Arbeidskrav1.BookStore.Services;

namespace HIOF.V2025.Arbeidskrav1.BookStoreCLI
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
            Console.WriteLine("Enter the nessesary information to add a book to the store.");
            Console.Write("Title: ");
            string title = Console.ReadLine() ?? throw new ArgumentNullException(nameof(title));
            Console.Write("Author: ");
            string author = Console.ReadLine() ?? throw new ArgumentNullException(nameof(author));
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine() ?? throw new ArgumentNullException(nameof(isbn));
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(price)));
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(quantity)));

            try
            {
                _bookStoreManager.AddBook(new Book(title, author, isbn, price, quantity));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        private void AddCustomer()
        {
            Console.WriteLine("Enter the necessary information to add a customer to the store.");
            Console.Write("First name: ");
            string firstName = Console.ReadLine() ?? throw new ArgumentNullException(nameof(firstName));
            Console.Write("Last name: ");
            string lastName = Console.ReadLine() ?? throw new ArgumentNullException(nameof(lastName));
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? throw new ArgumentNullException(nameof(email));
            Console.Write("Phone number: ");
            int phoneNumber = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(phoneNumber)));

            try
            {
                _customerManager.AddCustomer(new Customer(firstName, lastName, email, phoneNumber));
                Console.WriteLine("Customer added successfully.");
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
            Console.Write("Customer first name: ");
            string firstName = Console.ReadLine() ?? throw new ArgumentNullException(nameof(firstName));
            Console.Write("Customer last name: ");
            string lastName = Console.ReadLine() ?? throw new ArgumentNullException(nameof(lastName));
            Console.Write("Book title or ISBN: ");
            string titleOrIsbn = Console.ReadLine() ?? throw new ArgumentNullException(nameof(titleOrIsbn));
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(quantity)));

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