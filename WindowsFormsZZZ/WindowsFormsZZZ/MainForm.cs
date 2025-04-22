using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsZZZ
{
    public partial class MainForm : Form
    {
        private Library library = new Library();
        private Book selectedBook;
        public MainForm()
        {
            InitializeComponent();
            dataGridViewBooks.DataSource = library.Books;
            dataGridViewBooks.SelectionChanged += DataGridViewBooks_SelectionChanged;
        }
        private void DataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                selectedBook = (Book)dataGridViewBooks.SelectedRows[0].DataBoundItem;
                if (selectedBook != null)
                {
                    if (library.BookCopies.TryGetValue(selectedBook.Имя, out var copies))
                    {
                        dataGridViewCopies.DataSource = copies;
                    }
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string author = txtAuthor.Text.Trim(); // Удаляем лишние пробелы

            // Проверка на пустую строку
            if (string.IsNullOrWhiteSpace(author))
            {
                MessageBox.Show("Пожалуйста, введите автора для поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridViewBooks.DataSource = library.SearchByAuthor(author);

            // Если ничего не найдено
            if (dataGridViewBooks.Rows.Count == 0)
            {
                MessageBox.Show("Книги данного автора не найдены", "Информация",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (selectedBook == null || dataGridViewCopies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу и конкретный экземпляр");
                return;
            }

            string readerName = txtReader.Text;
            if (string.IsNullOrWhiteSpace(readerName))
            {
                MessageBox.Show("Введите ФИО читателя");
                return;
            }

            var selectedCopy = (WriteBook)dataGridViewCopies.SelectedRows[0].DataBoundItem;

            if (library.IssueBook(selectedBook.Имя, selectedCopy.Id, readerName))
            {
                MessageBox.Show("Книга успешно выдана");
                dataGridViewBooks.Refresh();
                dataGridViewCopies.Refresh();
                txtReader.Clear();
            }
            else
            {
                MessageBox.Show("Не удалось выдать книгу (возможно, она уже выдана)");
            }
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (selectedBook == null || dataGridViewCopies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу и конкретный экземпляр");
                txtAuthor.Clear();
                return;
            }

            var selectedCopy = (WriteBook)dataGridViewCopies.SelectedRows[0].DataBoundItem;
            if (library.ReturnBook(selectedBook.Имя, selectedCopy.Id))
            {
                MessageBox.Show("Книга успешно возвращена");
                dataGridViewBooks.Refresh();
                dataGridViewCopies.Refresh();
                txtReader.Clear();
            }
            else
            {
                MessageBox.Show("Не удалось вернуть книгу (возможно, она не была выдана)");
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAuthor.Clear();
            dataGridViewBooks.DataSource = library.Books;
        }
    }
}

/*private void btnSearch_Click(object sender, EventArgs e)
{
    string author = txtAuthor.Text;
    dataGridViewBooks.DataSource = library.SearchByAuthor(author);
}*/