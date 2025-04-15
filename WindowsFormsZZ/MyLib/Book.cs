﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Book
    {  
        public string Имя { get; set; }
        public string Автор { get; set; }
        public int Год_публикации { get; set; }
        public int Всего_книг { get; set; }
        public int Количество_доступных { get; set; }
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