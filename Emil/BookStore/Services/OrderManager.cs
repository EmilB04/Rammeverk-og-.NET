using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emil.BookStore.Interfaces;

namespace Emil.BookStore.Services
{
    public class OrderManager : IOrderService
    {
        private readonly BookStoreManager _bookStoreManager;
        private readonly CustomerManager _customerManager;
        private readonly List<Order> _orders = new();
        private int _orderIdCounter = 1;

        /// <summary>
        /// Constructor for OrderManager.
        /// </summary>
        /// <param name="bookStoreManager">The BookStoreManager instance.</param>
        /// <param name="customerManager">The CustomerManager instance.</param>
        public OrderManager(BookStoreManager bookStoreManager, CustomerManager customerManager)
        {
            _bookStoreManager = bookStoreManager;
            _customerManager = customerManager;
        }

        /// <summary>
        /// Creates a new order.
        /// Throws ArgumentException if customer is not found.
        /// Throws ArgumentException if book is not found.
        /// Throws ArgumentException if not enough stock is available.
        /// </summary>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <param name="titleOrIsbn">The title or ISBN of the book.</param>
        /// <param name="quantity">The quantity of the book to order.</param>
        /// <exception cref="ArgumentException">Thrown when the customer is not found, the book is not found, or not enough stock is available.</exception>
        public void NewOrder(string firstName, string lastName, string titleOrIsbn, int quantity)
        {
            var customer = _customerManager.GetCustomerByName(firstName, lastName);
            if (customer == null) throw new ArgumentException("Customer not found.");

            var book = _bookStoreManager.GetBookByTitle(titleOrIsbn) ?? _bookStoreManager.GetBookByIsbn(titleOrIsbn);
            if (book == null) throw new ArgumentException("Book not found.");

            if (book.Quantity < quantity) throw new ArgumentException("Not enough stock available.");

            var order = new Order(_orderIdCounter++, new List<Book> { book }, customer, DateTime.Now, book.Price * quantity, quantity);
            _orders.Add(order);

            _bookStoreManager.UpdateBookStock(book.Isbn, -quantity);

            Console.WriteLine($"Order created successfully: {order}");
        }

        /// <summary>
        /// Prints all orders in the store.
        /// Prints "No orders in the store." if there are no orders in the store.
        /// </summary>
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

        /// <summary>
        /// Gets the total number of orders in the store.
        /// </summary>
        /// <returns>The total number of orders in the store.</returns>
        public int OrderCount()
        {
            return _orders.Count;
        }

        /// <summary>
        /// Removes an order from the store.
        /// NOT IMPLEMENTED YET.
        /// </summary>
        /// <param name="order">The order to be removed.</param>
        public void RemoveOrder(Order order)
        {
            _orders.Remove(order);
        }

        /// <summary>
        /// Gets an order by order ID.
        /// Throws ArgumentException if the order is not found.
        /// NOT IMPLEMENTED YET.
        /// </summary>
        /// <param name="orderId">The ID of the order to be retrieved.</param>
        /// <returns>The order with the specified ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the order is not found.</exception>
        public Order GetOrderByOrderId(int orderId)
        {
            return null;
        }

        /// <summary>
        /// Gets orders by customer.
        /// NOT IMPLEMENTED YET.
        /// </summary>
        /// <param name="customer">The customer whose orders are to be retrieved.</param>
        /// <returns>A list of orders by the specified customer.</returns>
        public List<Order> GetOrdersByCustomerName(Customer customer)
        {
            return new List<Order>();
        }
    }
}