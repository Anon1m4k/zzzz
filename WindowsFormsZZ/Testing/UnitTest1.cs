using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;
using WindowsFormsZZ;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        BindingList<Book> expected = new BindingList<Book>(); //правильный

        private Library library = new Library();

        [TestMethod]
        public void TestMethodSort()
        {
            library.Books.Add(new Book { Name = "Мастер и маргарита", Author = "Михаил Булгаков", YearOfPublication = 1800 });
            //library.Books.Add(new Book { Name = "Война и мир", Author = "Лев Толстой", YearOfPublication = 1900 });
            //library.Books.Add(new Book { Name = "Преступление и наказание", Author = "Фёдор Достоевский", YearOfPublication = 2000 });

            expected.Add(new Book { Name = "Мастер и маргарита", Author = "Михаил Булгаков", YearOfPublication = 1800 });
            //expected.Add(new Book { Name = "Война и мир", Author = "Лев Толстой", YearOfPublication = 1900 });
            //expected.Add(new Book { Name = "Преступление и наказание", Author = "Фёдор Достоевский", YearOfPublication = 2000 });

            BindingList<Book> actual = library.Books; //наш
            CollectionAssert.AreEqual(expected, actual);
            //CollectionAssert.AreEquivalent(expected,actual);
        }
    }
}