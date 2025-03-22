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
            dataGridView1.DataSource = library.Books;          
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string selectedAuthor = textBox1.Text;
            // Вызываем метод Sort из Library и получаем отфильтрованный список
            var sortedBooks = library.Sort(selectedAuthor);
            // Обновляем источник данных DataGridView
            dataGridView1.DataSource = sortedBooks;
        }        
    }
}