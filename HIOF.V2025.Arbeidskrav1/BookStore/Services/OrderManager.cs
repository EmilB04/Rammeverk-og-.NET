using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav1.BookStore.Interfaces;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Services
{
    public class OrderManager : IOrderService
    {
        private readonly BookStoreManager _bookStoreManager;
        private readonly CustomerManager _customerManager;
        private readonly List<Order> _orders = new();
        private int _orderIdCounter = 1;

        public OrderManager(BookStoreManager bookStoreManager, CustomerManager customerManager)
        {
            _bookStoreManager = bookStoreManager;
            _customerManager = customerManager;
        }
        public void NewOrder(string firstName, string lastName, string titleOrIsbn, int quantity)
        {
            // Find the customer
            var customer = _customerManager.GetCustomerByName(firstName, lastName);
            if (customer == null) throw new ArgumentException("Customer not found.");

            // Find the book
            var book = _bookStoreManager.GetBookByTitle(titleOrIsbn) ?? _bookStoreManager.GetBookByIsbn(titleOrIsbn);
            if (book == null) throw new ArgumentException("Book not found.");

            // Check stock
            if (book.Quantity < quantity) throw new ArgumentException("Not enough stock available.");

            // Create the order
            var order = new Order(_orderIdCounter++, new List<Book> { book }, customer, DateTime.Now, book.Price * quantity);
            _orders.Add(order);

            // Update inventory
            _bookStoreManager.UpdateBookStock(book.Isbn, -quantity);

            Console.WriteLine($"Order created successfully: {order}");
        }




        public void PrintAllOrders()
        {
            if (_orders.Count == 0)
            {
                Console.WriteLine("No orders in the store.");
            }
            else
            {
                Console.WriteLine("All orders:");
                foreach (var order in _orders)
                {
                    Console.WriteLine(order);
                }
            }
        }

        public void RemoveOrder(Order order)
        {
            _orders.Remove(order);
        }
        public Order GetOrderByOrderId(int orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId) ?? throw new ArgumentException("Order not found.", nameof(orderId));
        }
        public List<Order> GetOrdersByCustomerName(Customer customer)
        {
            return _orders.Where(o => o.Customer == customer).ToList();
        }
        public void CheckIfUserWantsToExit()
        {
            Console.WriteLine("Do you want to exit the program? (yes/no)");
            string input = Console.ReadLine() ?? string.Empty;
            if (input == "yes" || input == "y")
            {
                Environment.Exit(0);
            }
            else if (input == "no" || input == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                CheckIfUserWantsToExit();
            }
        }
    }
}