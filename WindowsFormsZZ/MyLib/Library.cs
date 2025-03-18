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
        BindingList<Book> Books = new BindingList<Book>();
        List<Book> Sort = new List<Book>();
        public MainForm()
        {
           
            Books.Add(new Book { Name = "Мастер и маргарита", Author = "Михаил Булгаков", YearOfPublication = 1800 });
            Books.Add(new Book { Name = "Война и мир", Author = "Лев Толстой", YearOfPublication = 1900 });
            Books.Add(new Book { Name = "Преступление и наказание", Author = "Фёдор Достоевский", YearOfPublication = 2000 });
            dataGridView1.DataSource = Books;
        }
        public BindingList<Book> Sort()
        {
            string SelectAvtor = textBox1.Text;
            var sort = Books.Where(Книга => Книга.Author.Contains(SelectAvtor)).ToList();
            dataGridView1.DataSource = sort;
            return Books;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Sort();
        }
    }
}

