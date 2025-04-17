using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsZZZ
{
    public class WriteBook
    {
        public int Id { get; set; }
        public string Имя { get; set; }
        public DateTime Дата_взятия { get; set; }
        public bool Факт_взятия { get; set; }
        public string Читатель { get; set; }
        public DateTime Дата_возврата { get; set; }
    }
}