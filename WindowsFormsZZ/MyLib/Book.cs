using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Book
    {  
            public string Name { get; set; }
            public string Author { get; set; }
            public int YearOfPublication { get; set; }
            public bool IsIssued { get; set; } // Добавлено свойство для отслеживания статуса книги
            public string IssuedTo { get; set; } // Добавлено свойство для хранения имени читателя
            public int Quality { get; set; }
            public override bool Equals(object obj)
            {
                if (obj is Book other)
                {
                    return Name == other.Name && Author == other.Author && YearOfPublication == other.YearOfPublication;
                }
                return false;
            }
    }
} 