using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace MyLib
{
    public class Library
    {
        public BindingList<Book> Books = new BindingList<Book>()
        {
            new Book { Name = "Мастер и маргарита", Author = "Михаил Булгаков", YearOfPublication = 1800, IsIssued = false },
            new Book { Name = "Война и мир", Author = "Лев Толстой", YearOfPublication = 1900, IsIssued = false },
            new Book { Name = "Преступление и наказание", Author = "Фёдор Достоевский", YearOfPublication = 2000, IsIssued = false }
        };
        public BindingList<Book> Sort(string selectedAuthor)
        {
            var sortedBooks = Books.Where(book => book.Author.Contains(selectedAuthor)).ToList();
            return new BindingList<Book>(sortedBooks);
        }
        // Метод для выдачи книги
        public bool IssueBook(string bookName, string readerName)
        {
            var book = Books.FirstOrDefault(b => b.Name == bookName && !b.IsIssued);
            if (book != null)
            {
                book.IsIssued = true;
                book.IssuedTo = readerName;
                return true;
            }
            return false;
        }
        // Метод для возврата книги
        public bool ReturnBook(string bookName)
        {
            var book = Books.FirstOrDefault(b => b.Name == bookName && b.IsIssued);
            if (book != null)
            {
                book.IsIssued = false;
                book.IssuedTo = null;
                return true;
            }
            return false;
        }
    }
}