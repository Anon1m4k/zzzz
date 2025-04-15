using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsZZZ
{
    public class Library
    {
        public BindingList<Book> Books = new BindingList<Book>()
        {
            new Book { Имя = "Мастер и Маргарита", Автор = "Михаил Булгаков", Год_публикации = 1967, Количество_доступных_книг = 5 },
            new Book { Имя = "Преступление и наказание", Автор = "Фёдор Достоевский", Год_публикации = 1866, Количество_доступных_книг = 3 },
            new Book { Имя = "Война и мир", Автор = "Лев Толстой", Год_публикации = 1869, Количество_доступных_книг = 4 }
        };

        public Dictionary<string, BindingList<WriteBook>> BookCopies = new Dictionary<string, BindingList<WriteBook>>();

        public Library()
        {
            InitializeBookCopies();
        }

        private void InitializeBookCopies()
        {
            foreach (var book in Books)
            {
                var copies = new BindingList<WriteBook>();
                for (int i = 0; i < book.Количество_доступных_книг; i++)
                {
                    copies.Add(new WriteBook
                    {
                        Id = i + 1,
                        Имя = book.Имя,
                        Факт_взятия = false,
                        Читатель = null,
                        Дата_взятия = DateTime.MinValue,
                        Дата_возврата = DateTime.MinValue
                    });
                }
                BookCopies.Add(book.Имя, copies);
            }
        }

        public BindingList<Book> SearchByAuthor(string author)
        {
            var result = Books.Where(b => b.Автор.Contains(author)).ToList();
            return new BindingList<Book>(result);
        }

        public bool IssueBook(string bookName, int copyId, string readerName)
        {
            if (BookCopies.TryGetValue(bookName, out var copies))
            {
                var copy = copies.FirstOrDefault(c => c.Id == copyId && !c.Факт_взятия);
                if (copy != null)
                {
                    copy.Факт_взятия = true;
                    copy.Читатель = readerName;
                    copy.Дата_взятия = DateTime.Now;
                    copy.Дата_возврата = DateTime.Now.AddDays(14);

                    var book = Books.First(b => b.Имя == bookName);
                    book.Количество_доступных_книг--;
                    return true;
                }
            }
            return false;
        }

        public bool ReturnBook(string bookName, int copyId)
        {
            if (BookCopies.TryGetValue(bookName, out var copies))
            {
                var copy = copies.FirstOrDefault(c => c.Id == copyId && c.Факт_взятия);
                if (copy != null)
                {
                    copy.Факт_взятия = false;
                    copy.Читатель = null;
                    copy.Дата_взятия = DateTime.MinValue;
                    copy.Дата_возврата = DateTime.MinValue;

                    var book = Books.First(b => b.Имя == bookName);
                    book.Количество_доступных_книг++;
                    return true;
                }
            }
            return false;
        }
    }
}
