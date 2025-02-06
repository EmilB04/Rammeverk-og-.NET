using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CreateCustomer_ValidParameters()
        {
            var customer = new Customer("Emil", "Berglund", "emil.berglund@example.com", 12345678);
            Assert.AreEqual("Emil", customer.FirstName);
            Assert.AreEqual("Berglund", customer.LastName);
            Assert.AreEqual("emil.berglund@example.com", customer.Email);
            Assert.AreEqual(12345678, customer.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateCustomer_InvalidParameters_NullOrWhiteSpace()
        {
            new Customer(null, "Berglund", "emil.berglund@example.com", 12345678);
            new Customer("", "Berglund", "emil.berglund@example.com", 12345678); 

            new Customer("Emil", null, "emil.berglund@example.com", 12345678);
            new Customer("Emil", "", "emil.berglund@example.com", 12345678);

            new Customer("Emil", "Berglund", null, 12345678);
            new Customer("Emil", "Berglund", "", 12345678);

            new Customer("Emil", "Berglund", "emil.berglund@example.com", 0);
            new Customer("Emil", "Berglund", "emil.berglund@example.com", -1);
        }
        
    }
}
