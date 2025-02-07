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
        [ExpectedException(typeof(ArgumentException))]
        public void CreateOrder_InvalidParameters_Null()
        {
            var customer = new Customer("Emil", "Berglund", "emil.berglund@example.com", 12345678);
            var book = new Book("1984", "George Orwell", "978-0-452-28423-4", 129.99, 5);
            var books = new List<Book> { book };
            new Order(1, null, customer, DateTime.Now, 129.99, 2);
            new Order(2, books, null, DateTime.Now, 129.99, 2);
            new Order(3, books, customer, DateTime.Now, 0, 2);
            new Order(4, books, customer, DateTime.Now, 129.99, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateOrder_InvalidParameters_WhiteSpace()
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
    }
}
