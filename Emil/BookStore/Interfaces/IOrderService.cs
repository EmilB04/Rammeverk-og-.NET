using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emil.BookStore.Interfaces
{
    /// <summary>
    /// Interface for order service operations.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <param name="titleOrIsbn">The title or ISBN of the book.</param>
        /// <param name="quantity">The quantity of the book ordered.</param>
        void NewOrder(string firstName, string lastName, string titleOrIsbn, int quantity);

        /// <summary>
        /// Removes an existing order.
        /// </summary>
        /// <param name="order">The order to be removed.</param>
        void RemoveOrder(Order order);

        /// <summary>
        /// Prints all orders.
        /// </summary>
        void PrintAllOrders();

        /// <summary>
        /// Gets an order by its order ID.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>The order with the specified ID.</returns>
        Order GetOrderByOrderId(int orderId);

        /// <summary>
        /// Gets orders by the customer's name.
        /// </summary>
        /// <param name="customer">The customer whose orders are to be retrieved.</param>
        /// <returns>A list of orders made by the specified customer.</returns>
        List<Order> GetOrdersByCustomerName(Customer customer);
    }
}