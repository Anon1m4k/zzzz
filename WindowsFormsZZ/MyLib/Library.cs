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
            new Book { Имя = "Мастер и Маргарита", Автор = "Михаил Булгаков", Год_публикации = 1800, Колличество = 10, Колличество_книг = 10},
            new Book { Имя = "Морфий", Автор = "Михаил Булгаков", Год_публикации = 1855, Колличество = 10, Колличество_книг = 10},
            new Book { Имя = "Война и мир", Автор = "Лев Толстой", Год_публикации = 1900,  Колличество = 10, Колличество_книг = 10},
            new Book { Имя = "Преступление и наказание", Автор = "Фёдор Достоевский", Год_публикации = 2000, Колличество = 2, Колличество_книг = 2}
        };     
        public void FillDictionary(Dictionary<string, BindingList<WriteBook>> dicBooks)
        {
            foreach (var book in Books)
            {
                if (!dicBooks.ContainsKey(book.Имя))
                {
                    dicBooks.Add(book.Имя, new BindingList<WriteBook>());
                }
                for (int i = 0; i < book.Колличество; i++)
                {
                    dicBooks[book.Имя].Add(new WriteBook
                    {
                        Имя = book.Имя,
                        Id = i + 1, // Уникальный ID для каждого экземпляра
                        Факт_взятия = false,
                        Читатель = null,
                        Дата_взятия = DateTime.MinValue,
                        Дата_возврата = DateTime.MinValue
                    });
                }
            }
        } 
        public BindingList<Book> Search(string selectedAuthor)
        {
            var sortedBooks = Books.Where(book => book.Автор.Contains(selectedAuthor)).ToList();
            return new BindingList<Book>(sortedBooks);
        }
    }
}

// public List<Book> IssuedBooks { get; set; } = new List<Book>();

/*public void FillDictionary(Dictionary<string, BindingList<WriteBook>> dicBooks)
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
       }*/

// Очищаем список перед заполнением (если нужно)
// dicBooks[book.Name].Clear();