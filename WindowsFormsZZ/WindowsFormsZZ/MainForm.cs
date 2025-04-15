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
            DataGridViewBooks.DataSource = library.Books;
            DataGridViewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewTakeBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

           // dataGridView1.Columns["Всего_книг"].Visible = false;
            //dataGridView1.Columns["Количество_доступных"].HeaderText = "Доступно";
            //   dataGridView1.Columns["Колличество"].Visible = false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string selectedAuthor = SortTextbox.Text;
            var sortedBooks = library.Search(selectedAuthor);
            DataGridViewBooks.DataSource = sortedBooks;
        }       
        private void button2_Click(object sender, EventArgs e)
        {
            if (DataGridViewTakeBooks.SelectedRows.Count > 0)
            {
                selectedWriteBook = (WriteBook)DataGridViewTakeBooks.SelectedRows[0].DataBoundItem;
                selectedBook = (Book)DataGridViewBooks.SelectedRows[0].DataBoundItem;
            }
            if (selectedWriteBook == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу из списка");
                return;
            }        
            string readerName = FullNameTextBox.Text;
            if (string.IsNullOrEmpty(readerName))
            {
                MessageBox.Show("Пожалуйста, введите имя читателя.");
                return;
            }




           /* int currentQuantity = selectedBook.Количество_книг;
            if (currentQuantity > 0)
            {
                selectedBook.Количество_книг--;
                dataGridView1.Refresh();
            }*/


           /* int currentQuantity = selectedBook.Количество_доступных;
            if (currentQuantity > 0)
            {
                selectedBook.Количество_доступных--;
                dataGridView1.Refresh();
            }*/



           /* if (dic.IssueBook(selectedWriteBook, readerName))
            {   
               
                MessageBox.Show($"Книга '{selectedWriteBook.Имя}' выдана читателю {readerName}");
                textBox2.Clear();
                dataGridView2.Refresh();
            }*/
            if (dic.IssueBook(selectedWriteBook, readerName))
            {
                selectedBook.Количество_доступных--; // Уменьшаем доступные
                DataGridViewBooks.Refresh();
                DataGridViewTakeBooks.Refresh(); // Обновляем статус в dataGridView2
            }
            else
            {
                MessageBox.Show("Книга не найдена или уже выдана");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (DataGridViewTakeBooks.SelectedRows.Count > 0)
            {
                selectedWriteBook = (WriteBook)DataGridViewTakeBooks.SelectedRows[0].DataBoundItem;
            }
            if (selectedWriteBook == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу из списка");
                return;
            }




            /* int currentQuantity = selectedBook.Количество_книг;
             if (currentQuantity > 0)
             {
                 selectedBook.Количество_книг++;
                 dataGridView1.Refresh();
             }*/

            /* int currentQuantity = selectedBook.Количество_доступных;
             if (currentQuantity > 0)
             {
                 selectedBook.Количество_доступных++;
                 dataGridView1.Refresh();
             }*/


            /*if (dic.ReturnBook(selectedWriteBook))
            {
                MessageBox.Show($"Книга '{selectedWriteBook.Имя}' возвращена в библиотеку");
                dataGridView2.Refresh();
            }*/
            if (dic.ReturnBook(selectedWriteBook))
            {
                selectedBook.Количество_доступных++; // Увеличиваем доступные
                DataGridViewBooks.Refresh();
                DataGridViewTakeBooks.Refresh(); // Обновляем статус в dataGridView2
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
            DataGridViewBooks.DataSource = sortedBooks;
            SortTextbox.Clear();
        }          
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridViewBooks.SelectedRows.Count > 0)
            {
                selectedBook = (Book)DataGridViewBooks.SelectedRows[0].DataBoundItem;

                if (selectedBook != null)
                {
                    dic.DicBooks.Clear(); // Очистка предыдущего содержания словаря
                    library.FillDictionary(dic.DicBooks); // Заполнение словаря на основе выделенной строки

                    // Восстановление статуса книг из словаря bookStatus
                    foreach (var key in dic.DicBooks.Keys)
                    {
                        if (dic._bookStatus.ContainsKey(key))
                        {
                            var status = dic._bookStatus[key];
                            foreach (var book in dic.DicBooks[key])
                            {
                                if (book.Имя == status.Имя)
                                {
                                    book.Факт_взятия = status.Факт_взятия;
                                    book.Дата_взятия = status.Дата_взятия;
                                    book.Дата_возврата = status.Дата_возврата;
                                    book.Читатель = status.Читатель;
                                }
                            }
                        }
                    }
                    BindingList<WriteBook> L = dic.GetWriteBookByKey(selectedBook.Имя);
                    DataGridViewTakeBooks.DataSource = L; // Вывод словаря в dataGridView2
                    DataGridViewTakeBooks.Refresh();
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