using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsZZZ
{
    public class Book
    {
        public string Имя { get; set; }
        public string Автор { get; set; }
        [DisplayName("Год публикации")]
        public int Год_публикации { get; set; }
        [DisplayName("Количество доступных книг")]
        public int Количество_доступных_книг { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Book other)
            {
                return Имя == other.Имя && Автор == other.Автор && Год_публикации == other.Год_публикации;
            }
            return false;
        }
    }
}
