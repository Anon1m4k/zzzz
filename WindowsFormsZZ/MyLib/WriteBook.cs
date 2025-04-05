using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class WriteBook
    {
        public string Name { get; set; }
        public DateTime DateTake { get; set; }
        public bool IsIssued { get; set; } = false; // Добавлено свойство для отслеживания статуса книги
        public string IssuedTo { get; set; } // Добавлено свойство для хранения имени читателя
        public DateTime DateReturn { get; set; }
    }
}