using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CreateCustomer_ValidParameters()
        {
            var customer = new Customer("John", "Doe", "john.doe@example.com", 1234567890);
            Assert.AreEqual("John", customer.FirstName);
            Assert.AreEqual("Doe", customer.LastName);
            Assert.AreEqual("john.doe@example.com", customer.Email);
            Assert.AreEqual(12345678, customer.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateCustomer_ThrowsException_WhenFirstNameIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Customer(null, "Doe", "john.doe@example.com", 1234567890));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCustomer_ThrowsException_WhenEmailIsInvalid()
        {
            Assert.ThrowsException<ArgumentException>(() => new Customer("John", "Doe", "not-an-email", 1234567890));
        }
    }
}
