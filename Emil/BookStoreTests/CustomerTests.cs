using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emil.BookStore.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CreateCustomer_WithValidParameters_ShouldSetPropertiesCorrectly()
        {
            var customer = new Customer("Emil", "Berglund", "emil.berglund@example.com", 12345678);
            Assert.AreEqual("Emil", customer.FirstName);
            Assert.AreEqual("Berglund", customer.LastName);
            Assert.AreEqual("emil.berglund@example.com", customer.Email);
            Assert.AreEqual(12345678, customer.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateCustomer_WithNullOrEmptyParameters_ShouldThrowArgumentNullException()
        {
            var customer1 = new Customer(string.Empty, "Berglund", "emil.berglund@example.com", 12345678);
            var customer2 = new Customer("", "Berglund", "emil.berglund@example.com", 12345678); 

            var customer3 = new Customer("Emil", string.Empty, "emil.berglund@example.com", 12345678);
            var customer4 = new Customer("Emil", "", "emil.berglund@example.com", 12345678);

            var customer5 = new Customer("Emil", "Berglund", string.Empty, 12345678);
            var customer6 = new Customer("Emil", "Berglund", "", 12345678);

            var customer7 = new Customer("Emil", "Berglund", "emil.berglund@example.com", 0);
            var customer8 = new Customer("Emil", "Berglund", "emil.berglund@example.com", -1);
        }
        
        [TestMethod]
        public void CreateCustomer_WithValidParameters_ShouldNotHaveNullOrWhiteSpaceProperties()
        {
            var customer = new Customer("Emil", "Berglund", "emil.berglund@example.com", 12345678);
            Assert.IsFalse(string.IsNullOrWhiteSpace(customer.FirstName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(customer.LastName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(customer.Email));
        }
    }
}
