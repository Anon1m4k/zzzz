using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyLib
{
    public class DicBook
    {
        public Dictionary<string, WriteBook> _bookStatus = new Dictionary<string, WriteBook>();
        public Dictionary<string, BindingList<WriteBook>> DicBooks { get; private set; }
        public DicBook()
        {
            DicBooks = new Dictionary<string, BindingList<WriteBook>>();
        }
        public BindingList<WriteBook> GetWriteBookByKey(string NameBook)
        {
            if (DicBooks.TryGetValue(NameBook, out BindingList<WriteBook> result))
            {
                // Восстанавливаем статус для каждой книги при запросе
                foreach (var book in result)
                {
                    string key = $"{book.Имя}_{book.Id}";
                    if (_bookStatus.TryGetValue(key, out WriteBook status))
                    {
                        book.Факт_взятия = status.Факт_взятия;
                        book.Дата_взятия = status.Дата_взятия;
                        book.Дата_возврата = status.Дата_возврата;
                        book.Читатель = status.Читатель;
                    }
                }
                return result;
            }
            return new BindingList<WriteBook>();
        }
        /*public BindingList<WriteBook> GetWriteBookByKey(string NameBook)
        {
            if (DicBooks.TryGetValue(NameBook, out BindingList<WriteBook> result))
            {
                // Восстанавливаем статусы из _bookStatus
                foreach (var book in result)
                {
                    string key = $"{book.Имя}_{book.Id}";
                    if (_bookStatus.TryGetValue(key, out WriteBook status))
                    {
                        book.Факт_взятия = status.Факт_взятия;
                        book.Читатель = status.Читатель;
                        book.Дата_взятия = status.Дата_взятия;
                        book.Дата_возврата = status.Дата_возврата;
                    }
                }
                return result;
            }
            return new BindingList<WriteBook>();
        }*/
        public bool IssueBook(WriteBook selectedBook, string readerName)
        {
            if (selectedBook != null && !selectedBook.Факт_взятия)
            {
                selectedBook.Факт_взятия = true;
                selectedBook.Дата_взятия = DateTime.Now;
                selectedBook.Дата_возврата = DateTime.Now.AddDays(14);
                selectedBook.Читатель = readerName;

                // Сохраняем статус
                _bookStatus[$"{selectedBook.Имя}_{selectedBook.Id}"] = new WriteBook
                {
                    Id = selectedBook.Id,
                    Имя = selectedBook.Имя,
                    Факт_взятия = selectedBook.Факт_взятия,
                    Дата_взятия = selectedBook.Дата_взятия,
                    Дата_возврата = selectedBook.Дата_возврата,
                    Читатель = selectedBook.Читатель
                };
                return true;
            }
            return false;
        }
        public bool ReturnBook(WriteBook selectedBook)
        {
            if (selectedBook != null && selectedBook.Факт_взятия)
            {
                selectedBook.Факт_взятия = false;
                selectedBook.Дата_взятия = DateTime.MinValue;
                selectedBook.Дата_возврата = DateTime.MinValue;
                selectedBook.Читатель = null;

                // Удаляем статус или обновляем
                _bookStatus[$"{selectedBook.Имя}_{selectedBook.Id}"] = new WriteBook
                {
                    Id = selectedBook.Id,
                    Имя = selectedBook.Имя,
                    Факт_взятия = false,
                    Дата_взятия = DateTime.MinValue,
                    Дата_возврата = DateTime.MinValue,
                    Читатель = null
                };
                return true;
            }
            return false;
        }
    }
}

/*public BindingList<WriteBook> GetWriteBookByKey(string NameBook)
     {
         if (DicBooks.TryGetValue(NameBook, out BindingList<WriteBook> result))
         {
             return result;
         }
         return new BindingList<WriteBook>();
     }
     public bool IssueBook(WriteBook selectedBook, string readerName)
     {
         if (selectedBook != null && !selectedBook.IsIssued)
         { 
             selectedBook.IsIssued = true; //Устанавливаем статус книги как выданную
             selectedBook.DateTake = DateTime.Now;
             selectedBook.DateReturn = DateTime.Now.AddDays(14); //Устанавливаем срок возврата  
             selectedBook.IssuedTo = readerName; //Присваиваем фамилию читателя
             bookStatus[selectedBook.Name] = selectedBook;
             return true;
         }
         return false;
     }
     public bool ReturnBook(WriteBook selectedBook) //Метод для возврата книги
     {
         if (selectedBook != null && selectedBook.IsIssued)
         { 
             selectedBook.IsIssued = false;
             selectedBook.DateTake = DateTime.MinValue;
             selectedBook.DateReturn = DateTime.MinValue; 
             selectedBook.IssuedTo = null;
             bookStatus[selectedBook.Name] = selectedBook;
             return true;  
         }
         return false;      
     }*/