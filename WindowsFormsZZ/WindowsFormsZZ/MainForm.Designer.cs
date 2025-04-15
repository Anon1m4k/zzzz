namespace WindowsFormsZZ
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.ButtonSerch = new System.Windows.Forms.Button();
            this.SortTextbox = new System.Windows.Forms.TextBox();
            this.ButtonTake = new System.Windows.Forms.Button();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.DataGridViewTakeBooks = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTakeBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewBooks
            // 
            this.DataGridViewBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridViewBooks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewBooks.Location = new System.Drawing.Point(33, 78);
            this.DataGridViewBooks.Name = "DataGridViewBooks";
            this.DataGridViewBooks.ReadOnly = true;
            this.DataGridViewBooks.RowHeadersWidth = 51;
            this.DataGridViewBooks.Size = new System.Drawing.Size(647, 150);
            this.DataGridViewBooks.TabIndex = 0;
            this.DataGridViewBooks.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // ButtonSerch
            // 
            this.ButtonSerch.Location = new System.Drawing.Point(454, 27);
            this.ButtonSerch.Name = "ButtonSerch";
            this.ButtonSerch.Size = new System.Drawing.Size(110, 23);
            this.ButtonSerch.TabIndex = 1;
            this.ButtonSerch.Text = "Найти";
            this.ButtonSerch.UseVisualStyleBackColor = true;
            this.ButtonSerch.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SortTextbox
            // 
            this.SortTextbox.Location = new System.Drawing.Point(188, 28);
            this.SortTextbox.Name = "SortTextbox";
            this.SortTextbox.Size = new System.Drawing.Size(260, 20);
            this.SortTextbox.TabIndex = 2;
            // 
            // ButtonTake
            // 
            this.ButtonTake.Location = new System.Drawing.Point(454, 259);
            this.ButtonTake.Name = "ButtonTake";
            this.ButtonTake.Size = new System.Drawing.Size(110, 23);
            this.ButtonTake.TabIndex = 3;
            this.ButtonTake.Text = "Выдача";
            this.ButtonTake.UseVisualStyleBackColor = true;
            this.ButtonTake.Click += new System.EventHandler(this.button2_Click);
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.Location = new System.Drawing.Point(570, 259);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(110, 23);
            this.ButtonReturn.TabIndex = 4;
            this.ButtonReturn.Text = "Возврат";
            this.ButtonReturn.UseVisualStyleBackColor = true;
            this.ButtonReturn.Click += new System.EventHandler(this.button3_Click);
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Location = new System.Drawing.Point(188, 261);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(260, 20);
            this.FullNameTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введите ФИО читателя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Введите автора ";
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(570, 27);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(110, 23);
            this.ButtonReset.TabIndex = 8;
            this.ButtonReset.Text = "Сброс";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.button4_Click);
            // 
            // DataGridViewTakeBooks
            // 
            this.DataGridViewTakeBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewTakeBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridViewTakeBooks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridViewTakeBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewTakeBooks.Location = new System.Drawing.Point(33, 314);
            this.DataGridViewTakeBooks.Name = "DataGridViewTakeBooks";
            this.DataGridViewTakeBooks.ReadOnly = true;
            this.DataGridViewTakeBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewTakeBooks.Size = new System.Drawing.Size(647, 150);
            this.DataGridViewTakeBooks.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Список экземпляров книг";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 504);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DataGridViewTakeBooks);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FullNameTextBox);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.ButtonTake);
            this.Controls.Add(this.SortTextbox);
            this.Controls.Add(this.ButtonSerch);
            this.Controls.Add(this.DataGridViewBooks);
            this.Name = "MainForm";
            this.Text = "Библиотека";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTakeBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewBooks;
        private System.Windows.Forms.Button ButtonSerch;
        private System.Windows.Forms.TextBox SortTextbox;
        private System.Windows.Forms.Button ButtonTake;
        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.DataGridView DataGridViewTakeBooks;
        private System.Windows.Forms.Label label3;
    }
}

