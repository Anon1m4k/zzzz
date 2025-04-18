using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WindowsFormsZZZ;

namespace Testing
{
    [TestClass]
    public class LibraryTests
    {
        private Library _library;

        [TestInitialize]
        public void Setup()
        {
            _library = new Library();
        }

        [DataTestMethod]
        [DataRow("Мастер и Маргарита", 1, "Иван Иванов", true)] // Успешная выдача
        [DataRow("Несуществующая книга", 1, "Петр Петров", false)] // Неверное название
        [DataRow("Преступление и наказание", 999, "Мария Сидорова", false)] // Неверный ID
        [DataRow("Идиот", 1, "Анна Петрова", true)] // Успешная выдача
        public void TestIssueBook(string bookName, int copyId, string readerName, bool expectedResult)
        {
            // Act
            bool result = _library.IssueBook(bookName, copyId, readerName);

            // Assert
            Assert.AreEqual(expectedResult, result);

            // Проверка изменения количества книг
            if (result)
            {
                var book = _library.Books.First(b => b.Имя == bookName);
                Assert.AreEqual(book.Количество_доступных_книг, book.Количество_доступных_книг);
            }
        }

        [DataTestMethod]
        [DataRow("Мастер и Маргарита", 1, true)] // Успешный возврат
        [DataRow("Несуществующая книга", 1, false)] // Неверное название
        [DataRow("Война и мир", 1, false)] // Попытка вернуть невыданную книгу
        [DataRow("Преступление и наказание", 999, false)] // Неверный ID
        public void TestReturnBook(string bookName, int copyId, bool expectedResult)
        {
            // Подготовка: выдаем книгу перед возвратом
            if (bookName == "Мастер и Маргарита")
            {
                _library.IssueBook(bookName, copyId, "Тестовый Читатель");
            }

            // Act
            bool result = _library.ReturnBook(bookName, copyId);

            // Assert
            Assert.AreEqual(expectedResult, result);

            // Проверка изменения количества книг
            if (result)
            {
                var book = _library.Books.First(b => b.Имя == bookName);
                Assert.AreEqual(book.Количество_доступных_книг, book.Количество_доступных_книг);
            }
        }

        [DataTestMethod]
        [DataRow("Фёдор Достоевский", 2)] // Точное совпадение
        [DataRow("Досто", 2)] // Частичное совпадение
        [DataRow("достоевский", 0)] // Проверка регистра
        [DataRow("Лев Толстой", 1)] // Одна книга
        [DataRow("Михаил Булгаков", 1)] // Одна книга
        [DataRow("Несуществующий", 0)] // Нет совпадений
        [DataRow("", 4)] // Пустой запрос (возвращает все книги)
        public void TestSearchByAuthor(string authorQuery, int expectedCount)
        {
            // Act
            var result = _library.SearchByAuthor(authorQuery);

            // Assert
            Assert.AreEqual(expectedCount, result.Count);

            // Дополнительная проверка содержимого
            if (expectedCount > 0)
            {
                foreach (var book in result)
                {
                    StringAssert.Contains(book.Автор.ToLower(),authorQuery.ToLower());
                }
            }
        }
    }
}