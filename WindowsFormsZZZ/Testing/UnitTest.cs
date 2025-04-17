using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WindowsFormsZZZ;

namespace Testing
{
    [TestClass]
    public class UnitTest
    {
        private BindingList<Book> _books;
        private Dictionary<string, List<WriteBook>> _bookCopies;

        [TestInitialize]
        public void Setup()
        {
            // Инициализация тестовых данных перед каждым тестом
            _books = new BindingList<Book>
        {
            new Book { Имя = "Book1", Автор = "Author1", Количество_доступных_книг = 2 },
            new Book { Имя = "Book2", Автор = "Author2", Количество_доступных_книг = 1 }
        };

            _bookCopies = new Dictionary<string, List<WriteBook>>
        {
            {
                "Book1",
                new List<WriteBook>
                {
                    new WriteBook  { Id = 1, Факт_взятия = false },
                    new WriteBook { Id = 2, Факт_взятия = false }
                }
            },
            {
                "Book2",
                new List<WriteBook> { new WriteBook { Id = 3, Факт_взятия = false } }
            }
        };
        }
        [TestMethod]
        [DataRow("Фёдор Достоевский", 2)]  // Ожидается 2 книги Author1
        [DataRow("Михаил Булгаков", 1)]  // Ожидается 1 книга Author2
        [DataRow("Unknown", 0)]  // Нет совпадений
        public void SearchByAuthor_ReturnsCorrectBooks(string author, int expectedCount)
        {
            // Arrange
           // var library = new Library(_books, _bookCopies);
            var library = new Library();

            // Act
            var result = library.SearchByAuthor(author);

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
            Assert.IsTrue(result.All(b => b.Автор.Contains(author)));
        }
        [TestMethod]
        [DataRow("Мастер и Маргарита", 1, "Reader1", true)]    // Успешная выдача
        //[DataRow("Book1", 1, "Reader2", false)]   // Копия уже выдана
        [DataRow("Мастер и Маргарита", 7, "Reader2", false)]   // Несуществующая книга
        public void IssueBook_ReturnsCorrectStatus(string bookName, int copyId, string readerName, bool expectedResult)
        {
            // Arrange
            //var library = new Library(_books, _bookCopies);
            var library = new Library();
            var initialAvailable = _books.First(b => b.Имя == bookName)?.Количество_доступных_книг ?? 0;

            // Act
            bool result = library.IssueBook(bookName, copyId, readerName);
            var updatedAvailable = _books.FirstOrDefault(b => b.Имя == bookName)?.Количество_доступных_книг ?? 0;

            // Assert
            Assert.AreEqual(expectedResult, result);

            if (expectedResult)
            {
                var copy = _bookCopies[bookName].First(c => c.Id == copyId);
                Assert.IsTrue(copy.Факт_взятия);
                Assert.AreEqual(readerName, copy.Читатель);
                Assert.AreEqual(initialAvailable - 1, updatedAvailable);
            }
        }
    }
}
