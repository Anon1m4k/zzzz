using MyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsZZ
{
    public partial class MainForm : Form
    {
        private Library library = new Library();

        public MainForm()
        {
            InitializeComponent();

            library.Books.Add(new Book { Name = "Мастер и маргарита", Author = "Михаил Булгаков", YearOfPublication = 1800 });
            library.Books.Add(new Book { Name = "Война и мир", Author = "Лев Толстой", YearOfPublication = 1900 });
            library.Books.Add(new Book { Name = "Преступление и наказание", Author = "Фёдор Достоевский", YearOfPublication = 2000 });

            dataGridView1.DataSource = library.Books;
        }
        public void Sort()
        {
            string selectedAuthor = textBox1.Text;
            var sortedBooks = library.Books.Where(book => book.Author.Contains(selectedAuthor)).ToList();

            dataGridView1.DataSource = new BindingList<Book>(sortedBooks);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Sort();
        }
    }
}