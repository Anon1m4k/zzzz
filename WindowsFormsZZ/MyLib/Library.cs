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
            new Book { Name = "Мастер и маргарита", Author = "Михаил Булгаков", YearOfPublication = 1800 },
            new Book { Name = "Война и мир", Author = "Лев Толстой", YearOfPublication = 1900 },
            new Book { Name = "Преступление и наказание", Author = "Фёдор Достоевский", YearOfPublication = 2000 }
        };
        public BindingList<Book> Sort(string selectedAuthor)
        {
            var sortedBooks = Books.Where(book => book.Author.Contains(selectedAuthor)).ToList();
            return new BindingList<Book>(sortedBooks);
        }
    }
}