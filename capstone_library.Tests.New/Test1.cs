using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

// This is the namespace block. All of the classes must be within these curly braces.
namespace capstone_library.tests.new
{
    // A simple mock Book class for our tests.
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsOnLoan { get; set; }
    }

    // A mock service to simulate library business logic.
    public class LibraryService
    {
        private readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "The Giver", IsOnLoan = false },
            new Book { Id = 2, Title = "Dune", IsOnLoan = true }, // Pre-loaned for testing.
            new Book { Id = 3, Title = "The Hitchhiker's Guide to the Galaxy", IsOnLoan = false }
        };

        public bool LoanBook(int bookId)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);

            // Edge case: book not found.
            if (book == null)
            {
                return false;
            }

            // Business logic: check if the book is already on loan.
            if (book.IsOnLoan)
            {
                return false;
            }

            book.IsOnLoan = true;
            return true;
        }

        public bool ReturnBook(int bookId)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);

            // Edge case: book not found.
            if (book == null)
            {
                return false;
            }

            // Business logic: check if the book is not on loan.
            if (!book.IsOnLoan)
            {
                return false;
            }

            book.IsOnLoan = false;
            return true;
        }
    }

    // This is the class that contains all of our unit tests.
    [TestClass]
    public class LibraryServiceTests
    {
        // Test 1: Successful Loan (Business Logic)
        [TestMethod]
        public void LoanBook_WithAvailableBook_ReturnsTrue()
        {
            // Arrange
            var service = new LibraryService();
            int bookId = 1;

            // Act
            bool result = service.LoanBook(bookId);

            // Assert
            Assert.IsTrue(result, "The loan should have been successful.");
        }

        // Test 2: No Double Loans (Business Logic)
        [TestMethod]
        public void LoanBook_WithBookAlreadyOnLoan_ReturnsFalse()
        {
            // Arrange
            var service = new LibraryService();
            int bookId = 2; // This book is pre-loaned.

            // Act
            bool result = service.LoanBook(bookId);

            // Assert
            Assert.IsFalse(result, "The loan should have failed as the book was already on loan.");
        }

        // Test 3: Book Not Found (Edge Case)
        [TestMethod]
        public void LoanBook_WithNonExistentBook_ReturnsFalse()
        {
            // Arrange
            var service = new LibraryService();
            int bookId = 99; // An ID that doesn't exist.

            // Act
            bool result = service.LoanBook(bookId);

            // Assert
            Assert.IsFalse(result, "The loan should have failed because the book ID does not exist.");
        }

        // Test 4: Successful Return (Business Logic)
        [TestMethod]
        public void ReturnBook_WithLoanedBook_ReturnsTrue()
        {
            // Arrange
            var service = new LibraryService();
            int bookId = 2; // A book that is currently on loan.

            // Act
            bool result = service.ReturnBook(bookId);

            // Assert
            Assert.IsTrue(result, "The return should have been successful.");
        }
        
        // Test 5: Return of Non-Loaned Book (Edge Case)
        [TestMethod]
        public void ReturnBook_WithBookNotOnLoan_ReturnsFalse()
        {
            // Arrange
            var service = new LibraryService();
            int bookId = 1; // A book that is not on loan.

            // Act
            bool result = service.ReturnBook(bookId);

            // Assert
            Assert.IsFalse(result, "The return should have failed as the book was not on loan.");
        }
    }
}
