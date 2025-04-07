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
        public Dictionary<string, WriteBook> bookStatus { get; set; }
        public Dictionary<string, BindingList<WriteBook>> DicBooks { get; private set; }
        public DicBook()
        {
            DicBooks = new Dictionary<string, BindingList<WriteBook>>();
            bookStatus = new Dictionary<string, WriteBook>();
        }
        public BindingList<WriteBook> GetWriteBookByKey(string NameBook)
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
        }
    }
}