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
        public Book selectedBook;
        public DicBook dic = new DicBook();

        public MainForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = library.Books;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // dataGridView2.DataSource = 
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string selectedAuthor = textBox1.Text;
            var sortedBooks = library.Sort(selectedAuthor);
            dataGridView1.DataSource = sortedBooks;
        }       
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedBook = (Book)dataGridView1.SelectedRows[0].DataBoundItem;
            }

            if (selectedBook == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу из списка");
                return;
            }        
            string readerName = textBox2.Text; // Get text from the TextBox

            if (string.IsNullOrEmpty(readerName))
            {
                MessageBox.Show("Пожалуйста, введите имя читателя.");
                return; // Exit if no name is entered
            }

            if (library.IssueBook(selectedBook.Name, readerName))
            {
                MessageBox.Show($"Книга '{selectedBook.Name}' выдана читателю {readerName}");
                textBox2.Clear(); // Clear the TextBox after successful issue
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Книга не найдена или уже выдана");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            selectedBook = (Book)dataGridView1.SelectedRows[0].DataBoundItem;
            if (selectedBook == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу из списка");
                return;
            }
            if (library.ReturnBook(selectedBook.Name))
            {
                MessageBox.Show($"Книга '{selectedBook.Name}' возвращена в библиотеку");
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Книга не найдена или не была выдана");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string selectedAuthor = "";
            var sortedBooks = library.Sort(selectedAuthor);
            dataGridView1.DataSource = sortedBooks;
        } 
        
        public void HandleDataGridView1SelectionChanged()
        {
           
                // Получаем выбранный элемент
                var selectedBook = (Book)dataGridView1.SelectedRows[0].DataBoundItem;
                List<WriteBook> L = dic.GetBooksByKey(selectedBook.Name);

                // Создаём новый список
               /* List<Book> newList = new List<Book>();

                // Добавляем элемент в список в количестве Quality
                for (int i = 0; i < selectedBook.Quality; i++)
                {
                    newList.Add(selectedBook);
                }*/

                // Можно теперь делать что-то с новым списком, например, выводить его в другой DataGridView
                // Привяжем новый список к DataGridView2
                dataGridView2.DataSource = L;
                dataGridView2.Refresh();
            
        }
    }   
}
