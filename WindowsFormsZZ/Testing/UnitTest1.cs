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
        [DataRow("Михаил Булгаков", 1)]
        [DataRow("Некто", 0)]
        public void Sort_Returns_Correct_Result(string author, int expectedCount)
        {
            BindingList<Book> result = library.Sort(author);
            if (expectedCount == 1)
            {
                Assert.AreEqual("Мастер и Маргарита", result[0].Name);
            }
            else
            {
                Assert.AreEqual(expectedCount, result.Count);
            }
        }

        [TestMethod]
        public void IssueBook_Successfully_Issues_Book()
        {       
            string bookName = "Мастер и Маргарита";
            string readerName = "Иван";
       
            bool result = library.IssueBook(bookName, readerName);

            Assert.IsTrue(result);
            Assert.IsTrue(library.Books.First(b => b.Name == bookName).IsIssued);
            Assert.AreEqual(readerName, library.Books.First(b => b.Name == bookName).IssuedTo);
        }

        /*public void IssueBook_Returns_False_When_Book_Is_Already_Issued()
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
        }*/

        /*public void IssueBook_Returns_False_When_Book_Quality_Is_Zero()
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
        }*/

        /*public void ReturnBook_Successfully_Returns_Book()
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
        }*/
    }
}