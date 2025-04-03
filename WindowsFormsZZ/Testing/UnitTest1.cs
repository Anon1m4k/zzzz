using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;
using WindowsFormsZZ;

namespace Testing
{   
    [TestClass]
    public class LibraryTests
    {
        private Library library;

        [TestInitialize]
        public void Setup()
        {
            library = new Library();
        }

        [TestMethod]
        public void Sort_Returns_Correct_Books_By_Author()
        {
                // Arrange
                string author = "Михаил Булгаков";

                // Act
                BindingList<Book> result = library.Sort(author);

                // Assert
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual("Мастер и маргарита", result[0].Name);
        }
        [TestMethod]
        public void Sort_Returns_Empty_When_No_Books_By_Author()
        {
            // Arrange
            string author = "Некто";

            // Act
            BindingList<Book> result = library.Sort(author);

            // Assert
            Assert.AreEqual(0, result.Count);
        }


        [TestMethod]
            public void IssueBook_Successfully_Issues_Book()
            {
                // Arrange
                string bookName = "Мастер и маргарита";
                string readerName = "Иван";

                // Act
                bool result = library.IssueBook(bookName, readerName);

                // Assert
                Assert.IsTrue(result);
                Assert.IsTrue(library.Books.First(b => b.Name == bookName).IsIssued);
                Assert.AreEqual(readerName, library.Books.First(b => b.Name == bookName).IssuedTo);
            }

        
        public void IssueBook_Returns_False_When_Book_Is_Already_Issued()
        {
            // Arrange
            string bookName = "Мастер и маргарита";
            string readerName = "Иван";

            // Issue the book first
            library.IssueBook(bookName, readerName);

            // Act
            bool result = library.IssueBook(bookName, "Петр");

            // Assert
            Assert.IsFalse(result);
        }

       
        public void IssueBook_Returns_False_When_Book_Quality_Is_Zero()
        {
            // Arrange
            string bookName = "Мастер и маргарита";
            string readerName = "Иван";

            // Issue the book multiple times to reduce quality to 0
            library.IssueBook(bookName, readerName);
            library.ReturnBook(bookName);
            library.IssueBook(bookName, readerName); // Reduce quality to 9
            for (int i = 0; i < 9; i++)
            {
                library.IssueBook(bookName, readerName); // Reducing quality to 0
            }

            // Act
            bool result = library.IssueBook(bookName, "Петр");

            // Assert
            Assert.IsFalse(result);
        }

       
        public void ReturnBook_Successfully_Returns_Book()
        {
            // Arrange
            string bookName = "Мастер и маргарита";
            library.IssueBook(bookName, "Иван");

            // Act
            bool result = library.ReturnBook(bookName);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(library.Books.First(b => b.Name == bookName).IsIssued);
            Assert.IsNull(library.Books.First(b => b.Name == bookName).IssuedTo);
        }

       
        public void ReturnBook_Returns_False_When_Book_Is_Not_Issued()
        {
            // Arrange
            string bookName = "Мастер и маргарита";

            // Act
            bool result = library.ReturnBook(bookName);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
