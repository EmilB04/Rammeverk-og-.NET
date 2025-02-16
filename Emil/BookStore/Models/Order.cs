using System;
using System.Collections.Generic;

namespace Emil.BookStore
{
    public class Order
    {
        /// <summary>
        /// Gets or sets the ID of the order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the list of books in the order.
        /// </summary>
        public List<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets the customer who placed the order.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the date the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the total price of the order.
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity of books purchased.
        /// </summary>
        public int QuantityPurchased { get; set; }

        /// <summary>
        /// Constructor for Order.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <param name="books">The list of books in the order.</param>
        /// <param name="customer">The customer who placed the order.</param>
        /// <param name="orderDate">The date the order was placed.</param>
        /// <param name="totalPrice">The total price of the order.</param>
        /// <param name="quantityPurchased">The quantity of books purchased.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when orderId is less than or equal to zero, totalPrice is negative, or quantityPurchased is negative.</exception>
        /// <exception cref="ArgumentNullException">Thrown when books list or customer is null.</exception>
        /// <exception cref="ArgumentException">Thrown when books list is empty or orderDate is not a valid date.</exception>
        public Order(int orderId, List<Book> books, Customer customer, DateTime orderDate, double totalPrice, int quantityPurchased)
        {
            // Copilot-prompt: "How can this be shortned, while still following the .NET guidelines?"
            if (orderId <= 0)
                throw new ArgumentOutOfRangeException(nameof(orderId), "Order id cannot be zero or negative. Please enter a positive id.");
            if (books == null)
                throw new ArgumentNullException(nameof(books), "Books list cannot be null. Please enter a valid list of books.");
            if (customer == null)
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null. Please enter a valid customer.");
            if (orderDate == default)
                throw new ArgumentException(nameof(orderDate), "Order date is not valid. Please enter a valid date.");
            if (totalPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(totalPrice), "Total price cannot be negative. Please enter a positive price.");
            if (quantityPurchased < 0)
                throw new ArgumentOutOfRangeException(nameof(quantityPurchased), "Quantity purchased cannot be negative. Please enter a positive quantity.");

            OrderId = orderId;
            Books = books;
            Customer = customer;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            QuantityPurchased = quantityPurchased;
        }

        /// <summary>
        /// Returns a string that represents the current order.
        /// </summary>
        /// <returns>A string that represents the current order.</returns>
        public override string ToString()
        {
            var bookTitle = string.Join(", ", Books.Select(b => b.Title));
            return $"Order ID: {OrderId}, Customer: {Customer.FirstName} {Customer.LastName}, Order Date: {OrderDate}, Total Price: {TotalPrice:C}, Book: {bookTitle}, Quantity: {QuantityPurchased}";
        }
    }
}
