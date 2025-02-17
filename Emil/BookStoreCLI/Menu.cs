using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Emil.BookStore;
using Emil.BookStore.Models;
using Emil.BookStore.Services;

namespace Emil.BookStoreCLI
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
        private readonly DiscountManager _discountManager;


        public Menu(BookStoreManager bookStoreManager, OrderManager orderManager, CustomerManager customerManager, DiscountManager discountManager)
        {
            _bookStoreManager = bookStoreManager;
            _orderManager = orderManager;
            _customerManager = customerManager;
            _discountManager = discountManager;
        }
        public void Show()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Book options");
                Console.WriteLine("2. Customer options");
                Console.WriteLine("3. Order options");
                Console.WriteLine("4. Print options");
                Console.WriteLine("5. Discount options");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose an option:");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1": ShowBookOptions(); break;
                    case "2": ShowCustomerOptions(); break;
                    case "3": ShowOrderOptions(); break;
                    case "4": ShowPrintOptions(); break;
                    case "5": ShowDiscountOptions(); break;
                    case "6": Console.WriteLine("Goodbye!"); return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        // Additional menu options
        private void ShowBookOptions()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Remove a book");
                Console.WriteLine("3. Go back");
                Console.WriteLine("Choose an option:");
                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1": AddBook(); break;
                    case "2": RemoveBook(); break;
                    case "3": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }
        private void ShowCustomerOptions()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add a customer");
                Console.WriteLine("2. Remove a customer");
                Console.WriteLine("3. Go back");
                Console.WriteLine("Choose an option:");
                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1": AddCustomer(); break;
                    case "2": RemoveCustomer(); break;
                    case "3": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }
        private void ShowOrderOptions()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Create a new order");
                Console.WriteLine("2. Remove an order");
                Console.WriteLine("3. Go back");
                Console.WriteLine("Choose an option:");
                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1": NewOrder(); break;
                    case "2": RemoveOrder(); break;
                    case "3": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }
        private void ShowPrintOptions()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Print all books");
                Console.WriteLine("2. Print all customers");
                Console.WriteLine("3. Print all orders");
                Console.WriteLine("4. Print all discounts");
                Console.WriteLine("5. Go back");
                Console.WriteLine("Choose an option:");
                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1": _bookStoreManager.PrintAllBooks(); break;
                    case "2": _customerManager.PrintAllCustomers(); break;
                    case "3": _orderManager.PrintAllOrders(); break;
                    case "4": _discountManager.PrintAllDiscounts(); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }
        private void ShowDiscountOptions()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add a discount to inventory");
                Console.WriteLine("2. Apply discount to book");
                Console.WriteLine("3. Remove a discount from inventory");
                Console.WriteLine("4. Remove a discount from a book");
                Console.WriteLine("5. Get discount by code");
                Console.WriteLine("6. Get discount by percentage");
                Console.WriteLine("7. Get discount by amount");
                Console.WriteLine("8. Go back");
                Console.WriteLine("Choose an option:");
                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1": AddDiscountToInventoryOptions(); break;
                    case "2": AddDiscountToBook(); break;
                    case "3": RemoveDiscountFromInventory(); break;
                    case "4": RemoveDiscountFromBook(); break;
                    case "5": GetDiscountByCode(); break;
                    case "6": GetDiscountByPercentage(); break;
                    case "7": GetDiscountByAmount(); break;
                    case "8": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }
        private void AddDiscountToInventoryOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Choose a discount type:");
            Console.WriteLine("1. Percentage");
            Console.WriteLine("2. Amount");
            Console.WriteLine("3. Go back");
            Console.WriteLine("Choose an option:");
            var input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1": AddDiscountWithPercentage(); break;
                case "2": AddDiscountWithAmount(); break;
                case "3": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }

        // Book Options
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
        private void RemoveBook()
        {
            Console.WriteLine("Provide the following information to remove a book:");
            string titleOrIsbn;
            while (true)
            {
                Console.Write("Title or ISBN: ");
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

            try
            {
                Book? book = _bookStoreManager.GetBookByTitle(titleOrIsbn) ?? _bookStoreManager.GetBookByIsbn(titleOrIsbn);
                if (book != null)
                {
                    _bookStoreManager.RemoveBook(book);
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
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

        // Customer Options
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
        private void RemoveCustomer()
        {
            Console.WriteLine("Provide the following information to remove a customer:");
            try
            {
                _customerManager.RemoveCustomer(GetCustomer() ?? throw new ArgumentNullException("Customer not found."));
            }
            
            catch (ArgumentNullException)
            {
                Console.WriteLine($"Error: Customer not found");
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

        // Order Options
        private void NewOrder()
        {
            Console.WriteLine("Provide the following information to create an order:");
            Customer? customer = GetCustomer();
            if (customer == null)
            {
                return;
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
                _orderManager.NewOrder(customer.FirstName, customer.LastName, titleOrIsbn, quantity);
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
        private void RemoveOrder()
        {
            Console.WriteLine("Provide the following information to remove an order:");
            Console.WriteLine("Do you want a list of your orders? (y/n)");
            string? input = Console.ReadLine();
            while (true)
            {
                if (input == "y")
                {
                    Customer? customer = GetCustomer();
                    if (customer == null)
                    {
                        return;
                    }
                    if (_orderManager.GetCustomerOrders(customer).Count == 0)
                    {
                        Console.WriteLine("No orders found.");
                        break;
                    }
                    Console.WriteLine("Orders:");
                    _orderManager.GetCustomerOrders(customer).ForEach(Console.WriteLine);
                    break;
                }
                else if (input == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    break;
                }
            }

            int orderId;
            while (true)
            {
                Console.Write("Order ID: ");
                string orderIdInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(orderId));
                if (int.TryParse(orderIdInput, out orderId) && orderId > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid order ID. Please enter a valid ID.");
                    break;
                }
            }

            try
            {
                Order? order = _orderManager.GetOrderByOrderId(orderId);
                if (order != null)
                {
                    _orderManager.RemoveOrder(order);
                }
                else
                {
                    Console.WriteLine("Order not found.");
                }
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


        // Add discount to inventory or book
        private void AddDiscountWithPercentage()
        {
            Console.WriteLine("Enter the necessary information to add the discount.");

            string code;
            while (true)
            {
                Console.Write("Code: ");
                code = Console.ReadLine() ?? throw new ArgumentNullException(nameof(code));
                if (string.IsNullOrWhiteSpace(code))
                {
                    Console.WriteLine("Code cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            int percentage;
            while (true)
            {
                Console.Write("Percentage: ");
                string percentageInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(percentage));
                if (int.TryParse(percentageInput, out percentage) && percentage > 0 && percentage <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid percentage. Please enter a positive number between 1 and 100.");
                }
            }

            DateTime startDate;
            while (true)
            {
                Console.Write("Start date (dd-mm-yyyy): ");
                string startDateInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(startDate));
                if (DateTime.TryParseExact(startDateInput, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out startDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date. Please enter a valid date.");
                }
            }

            DateTime endDate;
            while (true)
            {
                Console.Write("End date (dd-mm-yyyy): ");
                string endDateInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(endDate));
                if (DateTime.TryParseExact(endDateInput, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out endDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date. Please enter a valid date.");
                }
            }

            try
            {
                _discountManager.AddDiscountToInventory(new Discount(code, percentage, startDate, endDate));
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
        private void AddDiscountWithAmount()
        {
            Console.WriteLine("Enter the necessary information to add the discount.");

            string code;
            while (true)
            {
                Console.Write("Code: ");
                code = Console.ReadLine() ?? throw new ArgumentNullException(nameof(code));
                if (string.IsNullOrWhiteSpace(code))
                {
                    Console.WriteLine("Code cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            double amount;
            while (true)
            {
                Console.Write("Amount: ");
                string amountInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(amount));
                if (double.TryParse(amountInput, out amount) && amount > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a positive number.");
                }
            }

            DateTime startDate;
            while (true)
            {
                Console.Write("Start date (dd-mm-yyyy): ");
                string startDateInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(startDate));
                if (DateTime.TryParseExact(startDateInput, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out startDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date. Please enter a valid date.");
                }
            }

            DateTime endDate;
            while (true)
            {
                Console.Write("End date (dd-mm-yyyy): ");
                string endDateInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(endDate));
                if (DateTime.TryParseExact(endDateInput, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out endDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date. Please enter a valid date.");
                }
            }

            try
            {
                _discountManager.AddDiscountToInventory(new Discount(code, amount, startDate, endDate));
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
        private void AddDiscountToBook()
        {
            Console.WriteLine("Enter the necessary information to apply a discount to a book.");

            Book? book;
            while (true)
            {
                Console.Write("Enter the title or ISBN of the book: ");
                string titleOrIsbn = Console.ReadLine() ?? throw new ArgumentNullException(nameof(titleOrIsbn));
                book = _bookStoreManager.GetBookByTitle(titleOrIsbn) ?? _bookStoreManager.GetBookByIsbn(titleOrIsbn);
                if (book == null)
                {
                    Console.WriteLine("Book not found.");
                }
                else
                {
                    break;
                }
            }

            Discount? discount;
            while (true)
            {
                Console.Write("Enter the code of the discount: ");
                string code = Console.ReadLine() ?? throw new ArgumentNullException(nameof(code));
                discount = _discountManager.GetDiscountByCode(code);
                if (discount == null)
                {
                    Console.WriteLine("Discount not found.");
                }
                else
                {
                    break;
                }
            }

            try
            {
                _discountManager.AddDiscountToBook(discount, book);
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

        // Remove discount from inventory or book
        private void RemoveDiscountFromBook()
        {
            Console.WriteLine("Enter the necessary information to remove a discount from a book.");

            Book? book;
            while (true)
            {
                Console.Write("Enter the title or ISBN of the book: ");
                string titleOrIsbn = Console.ReadLine() ?? throw new ArgumentNullException(nameof(titleOrIsbn));
                if (string.IsNullOrWhiteSpace(titleOrIsbn))
                {
                    Console.WriteLine("Title or ISBN cannot be empty.");
                }
                else
                {
                    book = _bookStoreManager.GetBookByTitle(titleOrIsbn) ?? _bookStoreManager.GetBookByIsbn(titleOrIsbn);
                    break;
                }
            }
            Discount? discount;
            while (true)
            {
                Console.Write("Enter the code of the discount: ");
                string code = Console.ReadLine() ?? throw new ArgumentNullException(nameof(code));
                if (string.IsNullOrWhiteSpace(code))
                {
                    Console.WriteLine("Code cannot be empty.");
                }
                else
                {
                    discount = _discountManager.GetDiscountByCode(code);
                    break;
                }
            }

            try
            {
                if (book != null && discount != null)
                {
                    _discountManager.RemoveDiscountFromBook(discount, book);
                }
                else
                {
                    Console.WriteLine("Book or discount not found.");
                }
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
        private void RemoveDiscountFromInventory()
        {
            // With code
            Console.WriteLine("Enter the code of the discount you want to remove:");
            string code;
            while (true)
            {
                Console.Write("Code: ");
                code = Console.ReadLine() ?? throw new ArgumentNullException(nameof(code));
                if (string.IsNullOrWhiteSpace(code))
                {
                    Console.WriteLine("Code cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            try
            {
                var discount = _discountManager.GetDiscountByCode(code);
                if (discount != null)
                {
                    _discountManager.RemoveDiscountFromInventory(discount);
                }
                else
                {
                    Console.WriteLine("Discount not found.");
                }
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

        // Get discount by code, percentage, or amount
        private void GetDiscountByCode()
        {
            // With code
            Console.WriteLine("Enter the code of the discount you want to get:");
            string code;
            while (true)
            {
                Console.Write("Code: ");
                code = Console.ReadLine() ?? throw new ArgumentNullException(nameof(code));
                if (string.IsNullOrWhiteSpace(code))
                {
                    Console.WriteLine("Code cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            try
            {
                Console.WriteLine(_discountManager.GetDiscountByCode(code));
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
        private void GetDiscountByPercentage()
        {
            Console.WriteLine("Enter the percentage of the discount you want to get:");
            int percentage;
            while (true)
            {
                Console.Write("Percentage: ");
                string percentageInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(percentage));
                if (int.TryParse(percentageInput, out percentage) && percentage > 0 && percentage <= 100)
                {
                    break;
                }
                var discounts = _discountManager.GetAllDiscounts();
                if (discounts == null || !discounts.Any(d => d.Percentage == percentage))
                {
                    Console.WriteLine("Percentage not found in discounts.");
                }
                else
                {
                    Console.WriteLine("Invalid percentage. Please enter a positive number between 1 and 100.");
                }
            }

            try
            {
                Console.WriteLine(_discountManager.GetDiscountByPercentage(percentage));
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
        private void GetDiscountByAmount()
        {
            Console.WriteLine("Enter the amount of the discount you want to get:");
            double amount;
            while (true)
            {
                Console.Write("Amount: ");
                string amountInput = Console.ReadLine() ?? throw new ArgumentNullException(nameof(amount));
                if (double.TryParse(amountInput, out amount) && amount > 0)
                {
                    break;
                }
                var discounts = _discountManager.GetAllDiscounts();
                if (discounts == null || !discounts.Any(d => d.Amount == amount))
                {
                    Console.WriteLine("Amount not found in discounts.");
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a positive number.");
                }
            }

            try
            {
                Console.WriteLine(_discountManager.GetDiscountByAmount(amount));
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

        // Helper methods
        private Customer? GetCustomer()
        {
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
            try
            {
                return _customerManager.GetCustomerByName(firstName, lastName);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: Missing input. {e.Message}");
                return null;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
                return null;
            }
        }
    }
}