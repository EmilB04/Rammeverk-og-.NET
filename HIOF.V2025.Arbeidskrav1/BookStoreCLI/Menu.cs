using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav1.BookStore;
using HIOF.V2025.Arbeidskrav1.BookStore.Interfaces;

namespace HIOF.V2025.Arbeidskrav1.BookStoreCLI
{
    public class Menu
    {
        private readonly IBookStoreManager _bookStoreManager;

        public Menu(IBookStoreManager bookStoreManager)
        {
            _bookStoreManager = bookStoreManager;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Add a customer");
                Console.WriteLine("3. Add an order");
                Console.WriteLine("4. Print all books");
                Console.WriteLine("5. Print all customers");
                Console.WriteLine("6. Print all orders");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Choose an option:");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1": AddBook(); break;
                    case "2": AddCustomer(); break;
                    case "3": AddOrder(); break;
                    case "4": _bookStoreManager.PrintAllBooks(); break;
                    case "5": _bookStoreManager.PrintAllCustomers(); break;
                    case "6": _bookStoreManager.PrintAllOrders(); break;
                    case "7": return;
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
                Console.WriteLine("Book added successfully.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}