using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class WriteBook
    {
        public int Id { get; set; }
        public string Имя { get; set; }
        public DateTime Дата_взятия { get; set; }
        public bool Факт_взятия { get; set; } = false; // Добавлено свойство для отслеживания статуса книги
        public string Читатель { get; set; } // Добавлено свойство для хранения имени читателя
        public DateTime Дата_возврата { get; set; }
    }
}