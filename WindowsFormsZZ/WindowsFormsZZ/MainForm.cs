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
        public WriteBook selectedWriteBook;
        public DicBook dic = new DicBook();   
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = library.Books;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string selectedAuthor = textBox1.Text;
            var sortedBooks = library.Search(selectedAuthor);
            dataGridView1.DataSource = sortedBooks;
        }       
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                selectedWriteBook = (WriteBook)dataGridView2.SelectedRows[0].DataBoundItem;
            }
            if (selectedWriteBook == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу из списка");
                return;
            }        
            string readerName = textBox2.Text;
            if (string.IsNullOrEmpty(readerName))
            {
                MessageBox.Show("Пожалуйста, введите имя читателя.");
                return;
            }
            if (dic.IssueBook(selectedWriteBook, readerName))
            {
                MessageBox.Show($"Книга '{selectedWriteBook.Name}' выдана читателю {readerName}");
                textBox2.Clear();
                dataGridView2.Refresh();
            }
            else
            {
                MessageBox.Show("Книга не найдена или уже выдана");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                selectedWriteBook = (WriteBook)dataGridView2.SelectedRows[0].DataBoundItem;
            }
            if (selectedWriteBook == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу из списка");
                return;
            }
            if (dic.ReturnBook(selectedWriteBook))
            {
                MessageBox.Show($"Книга '{selectedWriteBook.Name}' возвращена в библиотеку");
                dataGridView2.Refresh();
            }
            else
            {
                MessageBox.Show("Книга не найдена или не была выдана");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string selectedAuthor = "";
            var sortedBooks = library.Search(selectedAuthor);
            dataGridView1.DataSource = sortedBooks;
        }          
       /* private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            { 
                selectedBook = (Book)dataGridView1.SelectedRows[0].DataBoundItem; //Получаем выделенную строку

                if (selectedBook != null)
                {
                    dic.DicBooks.Clear(); //Очистка предыдущего содержания словаря
                    library.FillDictionary(dic.DicBooks); //Заполнение словаря на основе выделенной строки
                    BindingList<WriteBook> L = dic.GetWriteBookByKey(selectedBook.Name);
                    dataGridView2.DataSource = L; // Вывод словаря в dataGridView2
                    dataGridView2.Refresh();
                }
                else
                {  
                    MessageBox.Show("Выберите строку!");
                }
            }
        }*/

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedBook = (Book)dataGridView1.SelectedRows[0].DataBoundItem;

                if (selectedBook != null)
                {
                    dic.DicBooks.Clear(); // Очистка предыдущего содержания словаря
                    library.FillDictionary(dic.DicBooks); // Заполнение словаря на основе выделенной строки

                    // Восстановление статуса книг из словаря bookStatus
                    foreach (var key in dic.DicBooks.Keys)
                    {
                        if (dic.bookStatus.ContainsKey(key))
                        {
                            var status = dic.bookStatus[key];
                            foreach (var book in dic.DicBooks[key])
                            {
                                if (book.Name == status.Name)
                                {
                                    book.IsIssued = status.IsIssued;
                                    book.DateTake = status.DateTake;
                                    book.DateReturn = status.DateReturn;
                                    book.IssuedTo = status.IssuedTo;
                                }
                            }
                        }
                    }

                    BindingList<WriteBook> L = dic.GetWriteBookByKey(selectedBook.Name);
                    dataGridView2.DataSource = L; // Вывод словаря в dataGridView2
                    dataGridView2.Refresh();
                }
                else
                {
                    MessageBox.Show("Выберите строку!");
                }
            }
        }
    }   
}

/*private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedBook = (Book)dataGridView1.SelectedRows[0].DataBoundItem;

                dic.DicBooks.Clear();

                // Заполнение словаря на основе выделенной строки
                library.FillDictionary(dic.DicBooks);

                // Вывод словаря в dataGridView2
                //dataGridView2.DataSource = dic.DicBooks.Values.SelectMany(x => x).ToList();
               // dataGridView2.Refresh();

                BindingList<WriteBook> L = dic.GetBooksByKey(selectedBook.Name);
                dataGridView2.DataSource = L;
                dataGridView2.Refresh();


                    // Заполнение словаря только выделенной книгой
                    if (!dic.DicBooks.ContainsKey(selectedBook.Name))
                    {
                        dic.DicBooks.Add(selectedBook.Name, new BindingList<WriteBook>());
                    }
                    // Добавляем нужное количество экземпляров книги в словарь
                    for (int i = 0; i < selectedBook.Quality; i++)
                    {
                        dic.DicBooks[selectedBook.Name].Add(new WriteBook { Name = selectedBook.Name });
                    }
                    // Вывод словаря в dataGridView2
                    dataGridView2.DataSource = dic.DicBooks.Values.SelectMany(x => x).ToList();
                    dataGridView2.Refresh();
            }
        }*/