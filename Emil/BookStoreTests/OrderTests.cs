using Emil.BookStore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Emil.BookStore.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void CreateOrder_WithValidParameters_ShouldSucceed()
        {
            var customer = new Customer("John", "Doe", "john.doe@example.com", 12345678);
            var book = new Book("1984", "George Orwell", "978-0-452-28423-4", 129.99, 5);
            var books = new List<Book> { book };
            new Order(1, books, customer, DateTime.Now, 129.99, 2);
        }

        [TestMethod]
        public void CreateOrder_WithNullParameters_ShouldThrowArgumentNullException()
        {
            var customer = new Customer("Emil", "Berglund", "emil.berglund@example.com", 12345678);
            var book = new Book("1984", "George Orwell", "978-0-452-28423-4", 129.99, 5);
            var books = new List<Book> { book };

            Assert.ThrowsException<ArgumentNullException>(() => new Order(1, null!, customer, DateTime.Now, 129.99, 2));
            Assert.ThrowsException<ArgumentNullException>(() => new Order(2, books, null!, DateTime.Now, 129.99, 2));
            Assert.ThrowsException<ArgumentNullException>(() => new Order(3, books, customer, DateTime.Now, 0, 2));
            Assert.ThrowsException<ArgumentNullException>(() => new Order(4, books, customer, DateTime.Now, 129.99, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateOrder_WithWhiteSpaceParameters_ShouldThrowArgumentNullException()
        {
            var customer = new Customer("Emil", "Berglund", "", 12345678);
            var book = new Book("1984", "George Orwell", "978-0-452-28423-4", 129.99, 5);
            var books = new List<Book> { book };
            new Order(1, books, customer, DateTime.Now, 129.99, 2);

            var customer2 = new Customer("Emil", "Berglund", "emil.berglund@example.com", 12345678);
            var book2 = new Book("1984", "", "978-0-452-28423-4", 129.99, 5);
            var books2 = new List<Book> { book2 };
            new Order(2, books2, customer2, DateTime.Now, 129.99, 2);
        }

        [TestMethod]
        public void SimulatePurchase_ValidOrder_ShouldUpdateOrderCount()
        {
            // Arrange
            var bookStoreManager = new BookStoreManager();
            var customerManager = new CustomerManager();
            var orderManager = new OrderManager(bookStoreManager, customerManager);

            var book = new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, 2);
            bookStoreManager.AddBook(book);
            var customer = new Customer("Emil", "Berglund", "emil.berglund@example.com", 12345678);
            customerManager.AddCustomer(customer);
            new Order(1, new List<Book> { book }, customer, DateTime.Now, book.Price, 1);

            // Act
            orderManager.NewOrder(customer.FirstName, customer.LastName, book.Title, 1);

            // Assert
            var orders = orderManager.GetOrdersByCustomerName(customer);
            Assert.IsNotNull(orders);
            Assert.AreEqual(1, orders.Count);
        }
    }
}
