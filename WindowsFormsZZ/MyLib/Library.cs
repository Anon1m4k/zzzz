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
            new Book { Name = "Мастер и Маргарита", Author = "Михаил Булгаков", YearOfPublication = 1800, IsIssued = false, Quality = 10},
            new Book { Name = "Война и мир", Author = "Лев Толстой", YearOfPublication = 1900, IsIssued = false,  Quality = 10},
            new Book { Name = "Преступление и наказание", Author = "Фёдор Достоевский", YearOfPublication = 2000, IsIssued = false,  Quality = 10}
        };
        public List<Book> IssuedBooks { get; set; } = new List<Book>();
        public BindingList<Book> Sort(string selectedAuthor)
        {
            var sortedBooks = Books.Where(book => book.Author.Contains(selectedAuthor)).ToList();
            return new BindingList<Book>(sortedBooks);
        }

        // Метод для выдачи книги
        /* public bool IssueBook(string bookName, string readerName)
         {
             var book = Books.FirstOrDefault(b => b.Name == bookName && !b.IsIssued);
             if (book != null)
             {
                 book.IsIssued = true;
                 book.IssuedTo = readerName;
                 return true;
             }
             return false;
         }*/

        public bool IssueBook(string bookName, string readerName) //Метод для выдачи книги
        {
            var book = Books.FirstOrDefault(b => b.Name == bookName && !b.IsIssued && b.Quality > 0);
            if (book != null)
            {
                book.Quality--;
                book.IsIssued = true;
                book.IssuedTo = readerName;
                return true;
            }
            return false;
        }
        public bool ReturnBook(string bookName) //Метод для возврата книги
        {
            var book = Books.FirstOrDefault(b => b.Name == bookName && b.IsIssued);
            if (book != null)
            {
                book.Quality++;
                book.IsIssued = false;
                book.IssuedTo = null;
                return true;
            }
            return false;
        }
    }
}