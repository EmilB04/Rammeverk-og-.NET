using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void CreateOrder_ValidParameters()
        {
            var customer = new Customer("John", "Doe", "john.doe@example.com", 12345678);
            var book = new Book("1984", "George Orwell", "978-0-452-28423-4", 129.99, 5);
            var books = new List<Book> { book };
            var order = new Order(1, books, customer, DateTime.Now, 129.99, 2);

            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateOrder_ThrowsException_WhenCustomerIsNull()
        {
            var book = new Book("1984", "George Orwell", "978-0-452-28423-4", 129.99, 5);
            var books = new List<Book> { book };
            var order = new Order(1, books, null, DateTime.Now, 129.99, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateOrder_ThrowsException_WhenBookListIsEmpty()
        {
            var customer = new Customer("John", "Doe", "john.doe@example.com", 12345678);
            var order = new Order(1, new List<Book>(), customer, DateTime.Now, 129.99, 2);
        }


    }
}
