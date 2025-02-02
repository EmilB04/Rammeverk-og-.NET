using System;
using System.Collections.Generic;

namespace HIOF.V2025.Arbeidskrav1.BookStore
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Book> Books { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }

        /// <summary>
        /// Constructor for Order.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <param name="books">The list of books in the order.</param>
        /// <param name="customer">The customer who placed the order.</param>
        /// <param name="orderDate">The date the order was placed.</param>
        /// <param name="totalPrice">The total price of the order.</param>
        /// <exception cref="ArgumentException">Thrown when orderId is less than or equal to zero, books list is null or empty, orderDate is not a valid date, or totalPrice is negative.</exception>
        /// <exception cref="ArgumentNullException">Thrown when customer is null.</exception>
        public Order(int orderId, List<Book> books, Customer customer, DateTime orderDate, double totalPrice)
        {
            if (orderId <= 0) throw new ArgumentException("Order id must be greater than zero.", nameof(orderId));
            if (books == null || books.Count == 0) throw new ArgumentException("Books list cannot be null or empty.", nameof(books));
            if (customer == null) throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
            if (orderDate == default) throw new ArgumentException("Order date must be a valid date.", nameof(orderDate));
            if (totalPrice < 0) throw new ArgumentException("Total price cannot be negative.", nameof(totalPrice));

            OrderId = orderId;
            Books = books;
            Customer = customer;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
        }

        /// <summary>
        /// Returns a string that represents the current order.
        /// </summary>
        /// <returns>A string that represents the current order.</returns>
        public override string ToString()
        {
            return $"Order ID: {OrderId}, Customer: {Customer.FirstName} {Customer.LastName}, Order Date: {OrderDate}, Total Price: {TotalPrice:C}";
        }
    }
}
