using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HIOF.V2025.Arbeidskrav2.BookStore;
using HIOF.V2025.Arbeidskrav2.BookStore.Services;

namespace HIOF.V2025.Arbeidskrav2.BookStore.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void CreateBook_ValidParameters_ShouldCreateBook()
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
        public void CreateBook_InvalidParameters_ShouldThrowArgumentNullException()
        {
            new Book(null, "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, 2);
            new Book(" ", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, 2);
            new Book("The Hobbit", null, "978-0-395-07122-1", 149.50, 2);
            new Book("The Hobbit", " ", "978-0-395-07122-1", 149.50, 2);
            new Book("The Hobbit", "J.R.R. Tolkien", null, 149.50, 2);
            new Book("The Hobbit", "J.R.R. Tolkien", " ", 149.50, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateBook_InvalidNumbers_ShouldThrowArgumentOutOfRangeException()
        {
            new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", -149.50, 2);
            new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, -2);
        }

        [TestMethod]
        public void UpdateBook_ValidValue_ShouldChangePrice()
        {
            var book = new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, 2);
            book.Price = 179.99;
            
            Assert.AreEqual(179.99, book.Price);
        }

        [TestMethod]
        public void CreateBook_ValidParameters_ShouldNotBeNullOrWhiteSpace()
        {
            var book = new Book("Dune", "Frank Herbert", "978-0-441-17271-9", 199.99, 3);
            Assert.IsFalse(string.IsNullOrWhiteSpace(book.Title));
            Assert.IsFalse(string.IsNullOrWhiteSpace(book.Author));
            Assert.IsFalse(string.IsNullOrWhiteSpace(book.Isbn));
        }

        [TestMethod]
        public void AddBookToStore_ValidBook_ShouldIncreaseQuantity()
        {
            // Arrange
            var bookStoreManager = new BookStoreManager();
            var book = new Book("Test Book", "J.R.R. Tolkien", "123-456-78-9", 149.50, 1);

            // Act
            bookStoreManager.AddBook(book);

            // Assert
            Assert.AreEqual(1, bookStoreManager.GetAllQuantity());
        }

        [TestMethod]
        public void SearchForBookByIsbn_ValidIsbn_ShouldFindBook()
        {
            // Arrange
            var bookStoreManager = new BookStoreManager();
            var book = new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, 2);
            bookStoreManager.AddBook(book);

            // Act
            var foundBook = bookStoreManager.GetBookByIsbn("978-0-395-07122-1");

            // Assert
            Assert.AreEqual(book, foundBook);
        }

        [TestMethod]
        public void SearchForBookByTitle_ValidTitle_ShouldFindBook()
        {
            // Arrange
            var bookStoreManager = new BookStoreManager();
            var book = new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50, 2);
            bookStoreManager.AddBook(book);

            // Act
            var foundBook = bookStoreManager.GetBookByTitle("The Hobbit");

            // Assert
            Assert.AreEqual(book, foundBook);
        }
    }
}
