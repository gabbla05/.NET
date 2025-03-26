using NUnit.Framework;
using System.Reflection.PortableExecutable;
using LibraryApp;

namespace LibraryApp.Tests
{
    public class LibraryTests
    {
        private Library library;
        private Reader reader;

        [SetUp]
        public void Setup()
        {
            library = new Library();
            reader = new Reader(1, "Test User", "test@example.com");
            library.RegisterReader(reader);
        }

        [Test]
        public void BorrowBook_ShouldMarkBookAsUnavailable()
        {
            // Arrange
            var book = new Book("Sample", "Author", "101");
            library.AddBook(book);

            // Act
            var result = library.BorrowBook("101", reader);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(book.IsAvailable);
        }

        [Test]
        public void ReturnBook_ShouldMarkBookAsAvailable()
        {
            // Arrange
            var book = new Book("Sample", "Author", "101");
            library.AddBook(book);
            library.BorrowBook("101", reader);

            // Act
            var result = library.ReturnBook("101", reader);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(book.IsAvailable);
        }

        [Test]
        public void BorrowingAlreadyBorrowedBook_ShouldFail()
        {
            // Arrange
            var book = new Book("Sample", "Author", "101");
            library.AddBook(book);
            library.BorrowBook("101", reader);

            // Act
            var result = library.BorrowBook("101", reader);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturningNonBorrowedBook_ShouldFail()
        {
            // Arrange
            var book = new Book("Sample", "Author", "101");
            library.AddBook(book);

            // Act
            var result = library.ReturnBook("101", reader);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
