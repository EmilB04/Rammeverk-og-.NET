using System;
using System.Collections.Generic;
using Emil.BookStore;
using Emil.BookStore.Models;
using Emil.BookStore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emil.BookStoreTests
{
    [TestClass]
    public class DiscountTests
    {
        [TestMethod]
        public void CreateOrderWithDiscount_Valid_ShouldChangePrice()
        {
            // Arrange
            DiscountManager discountManager = new DiscountManager();
            BookStoreManager bookStoreManager = new BookStoreManager();
            CustomerManager customerManager = new CustomerManager();
            var orderManager = new OrderManager(bookStoreManager, customerManager);
            double price = 200;
            var customer = new Customer("John", "Doe", "john.doe@example.com", 12345678);
            var book = new PhysicalBook("1984", "George Orwell", "978-0-452-28423-4", price, 5);
            bookStoreManager.AddBook(book);
            customerManager.AddCustomer(customer);
            
            // Add discount
            var discount = new Discount("50OFF", 50, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            discountManager.AddDiscountToInventory(discount);
            discountManager.AddDiscountToBook(discount, book);
            
            // Act
            var order = new Order(1, new List<Book> { book }, customer, DateTime.Now, book.Price, 2);

            // Assert
            Assert.AreEqual(1, order.Books.Count);
            Assert.AreEqual(100, order.TotalPrice);
        }

        [TestMethod]
        public void RemoveDiscountFromBook_Valid_ShouldChangePrice()
        {
            // Arrange
            DiscountManager discountManager = new DiscountManager();
            BookStoreManager bookStoreManager = new BookStoreManager();
            CustomerManager customerManager = new CustomerManager();
            var orderManager = new OrderManager(bookStoreManager, customerManager);
            double price = 200;
            var customer = new Customer("John", "Doe", "john.doe@example.com", 12345678);
            var book = new PhysicalBook("1984", "George Orwell", "978-0-452-28423-4", price, 5);
            bookStoreManager.AddBook(book);
            customerManager.AddCustomer(customer);
            
            // Add discount and order
            var discount = new Discount("50OFF", 50, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            discountManager.AddDiscountToInventory(discount);
            discountManager.AddDiscountToBook(discount, book);
            var order = new Order(1, new List<Book> { book }, customer, DateTime.Now, book.Price, 2);

            Assert.AreEqual(100, book.Price);

            // Act
            discountManager.RemoveDiscountFromBook(discount, book);

            // Assert
            Assert.AreEqual(1, order.Books.Count);
            Assert.AreEqual(200, book.Price);
        }

        [TestMethod]
        public void AddDiscountToInventory_Valid_ShouldIncreaseDiscountCount()
        {
            // Arrange
            DiscountManager discountManager = new DiscountManager();
            var discount = new Discount("50OFF", 50, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));

            // Act
            discountManager.AddDiscountToInventory(discount);

            // Assert
            var discounts = discountManager.GetAllDiscounts();
            Assert.IsNotNull(discounts);
            Assert.AreEqual(1, discounts.Count);
        }

        [TestMethod]
        public void RemoveDiscountFromInventory_Valid_ShouldDecreaseDiscountCount()
        {
            // Arrange
            DiscountManager discountManager = new DiscountManager();
            var discount = new Discount("50OFF", 50, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            var discount1 = new Discount("25OFF", 25, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            discountManager.AddDiscountToInventory(discount);
            discountManager.AddDiscountToInventory(discount1);

            // Act
            discountManager.RemoveDiscountFromInventory(discount);

            // Assert
            var discounts = discountManager.GetAllDiscounts();
            Assert.IsNotNull(discounts);
            Assert.AreEqual(1, discounts.Count);
        }

        [TestMethod]
        public void GetDiscountByCode_ValidCode_ShouldFindDiscount()
        {
            // Arrange
            DiscountManager discountManager = new DiscountManager();
            var discount = new Discount("50OFF", 50, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            discountManager.AddDiscountToInventory(discount);

            // Act
            var foundDiscount = discountManager.GetDiscountByCode("50OFF");

            // Assert
            Assert.AreEqual(discount, foundDiscount);
        }

        [TestMethod]
        public void GetDiscountByCode_InvalidCode_ShouldThrowException()
        {
            // Arrange
            DiscountManager discountManager = new DiscountManager();
            var discount = new Discount("50OFF", 50, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            discountManager.AddDiscountToInventory(discount);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => discountManager.GetDiscountByCode("25OFF"));
        }
    }
}