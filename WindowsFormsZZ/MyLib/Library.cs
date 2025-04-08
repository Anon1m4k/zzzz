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
            new Book { Name = "Мастер и Маргарита", Author = "Михаил Булгаков", YearOfPublication = 1800, Quality = 10},
            new Book { Name = "Морфий", Author = "Михаил Булгаков", YearOfPublication = 1855, Quality = 10},
            new Book { Name = "Война и мир", Author = "Лев Толстой", YearOfPublication = 1900,  Quality = 10},
            new Book { Name = "Преступление и наказание", Author = "Фёдор Достоевский", YearOfPublication = 2000, Quality = 2}
        };
        public void FillDictionary(Dictionary<string, BindingList<WriteBook>> dicBooks)
        {
            foreach (var book in Books)
            {
                var writeBook = new WriteBook
                {
                    Name = book.Name,
                };
                if (!dicBooks.ContainsKey(book.Name))
                {
                    dicBooks.Add(book.Name, new BindingList<WriteBook>());
                }
                for (int i = 0; i < book.Quality; i++)
                {
                    dicBooks[book.Name].Add(new WriteBook { Name = book.Name });
                }
            }
        }
        public BindingList<Book> Search(string selectedAuthor)
        {
            var sortedBooks = Books.Where(book => book.Author.Contains(selectedAuthor)).ToList();
            return new BindingList<Book>(sortedBooks);
        }
    }
}

// public List<Book> IssuedBooks { get; set; } = new List<Book>();