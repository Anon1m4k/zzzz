using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyLib
{
    public class DicBook
    { 
        Dictionary<string, List<WriteBook>> DicBooks = new Dictionary<string, List<WriteBook>>();
        public DicBook()
        {
            DicBooks.Add( "Мастер_и_Маргарита", new List<WriteBook> { new WriteBook {  Name = "Мастер и Маргарита",
                DateTake = DateTime.Now,
                IssuedTo = "Иван",
                DateReturn = DateTime.Now.AddDays(14)}});
        }
        public List<WriteBook> GetBooksByKey(string NameBook)
        {
            if (DicBooks.TryGetValue(NameBook, out List<WriteBook> result))
            {
                return result;
            }
            return new List<WriteBook>();
        }
    }
}