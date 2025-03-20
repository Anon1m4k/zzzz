using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Library
    {
        public BindingList<Book> Books { get; private set; } = new BindingList<Book>();

        //List<Book> Sort = new List<Book>();  
    }
}