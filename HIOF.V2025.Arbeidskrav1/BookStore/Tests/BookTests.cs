using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void CreateBook_ValidParameters()
        {
            // Arrange & Act
            var book = new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, 2);

            // Assert
            Assert.AreEqual("The Hobbit", book.Title);
            Assert.AreEqual("J.R.R. Tolkien", book.Author);
            Assert.AreEqual("978-0-395-07122-1", book.Isbn);
            Assert.AreEqual(149.50, book.Price);
            Assert.AreEqual(2, book.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateBook_ThrowsException_WhenTitleIsNull()
        {
            var book = new Book(null, "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBook_ThrowsException_WhenPriceIsNegative()
        {
            var book = new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", -149.50, 2);
        }

        [TestMethod]
        public void UpdateBookPrice_ChangesPriceCorrectly()
        {
            var book = new Book("Dune", "Frank Herbert", "978-0-441-17271-9", 199.99, 3);
            book.Price = 179.99;
            
            Assert.AreEqual(179.99, book.Price);
        }


    }
}