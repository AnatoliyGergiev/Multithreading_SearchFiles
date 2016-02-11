namespace SearchFileFolder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_File = new System.Windows.Forms.TextBox();
            this.comboBox_Disk = new System.Windows.Forms.ComboBox();
            this.textBox_Phrase = new System.Windows.Forms.TextBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.listView_SearchResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBox_Subdirectory = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_result = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // textBox_File
            // 
            this.textBox_File.Location = new System.Drawing.Point(23, 41);
            this.textBox_File.Name = "textBox_File";
            this.textBox_File.Size = new System.Drawing.Size(147, 22);
            this.textBox_File.TabIndex = 0;
            // 
            // comboBox_Disk
            // 
            this.comboBox_Disk.FormattingEnabled = true;
            this.comboBox_Disk.Location = new System.Drawing.Point(476, 39);
            this.comboBox_Disk.Name = "comboBox_Disk";
            this.comboBox_Disk.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Disk.TabIndex = 1;
            // 
            // textBox_Phrase
            // 
            this.textBox_Phrase.Location = new System.Drawing.Point(176, 41);
            this.textBox_Phrase.Name = "textBox_Phrase";
            this.textBox_Phrase.Size = new System.Drawing.Size(294, 22);
            this.textBox_Phrase.TabIndex = 2;
            // 
            // button_Search
            // 
            this.button_Search.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Search.Location = new System.Drawing.Point(603, 39);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 24);
            this.button_Search.TabIndex = 3;
            this.button_Search.Text = "Найти";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Enabled = false;
            this.button_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Stop.Location = new System.Drawing.Point(684, 39);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(102, 24);
            this.button_Stop.TabIndex = 4;
            this.button_Stop.Text = "Остановить";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // listView_SearchResults
            // 
            this.listView_SearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView_SearchResults.FullRowSelect = true;
            this.listView_SearchResults.GridLines = true;
            this.listView_SearchResults.Location = new System.Drawing.Point(23, 116);
            this.listView_SearchResults.Name = "listView_SearchResults";
            this.listView_SearchResults.Size = new System.Drawing.Size(884, 460);
            this.listView_SearchResults.TabIndex = 5;
            this.listView_SearchResults.UseCompatibleStateImageBehavior = false;
            this.listView_SearchResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 121;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Папка";
            this.columnHeader2.Width = 261;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Размер";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 134;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Дата модификации";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 150;
            // 
            // checkBox_Subdirectory
            // 
            this.checkBox_Subdirectory.AutoSize = true;
            this.checkBox_Subdirectory.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.checkBox_Subdirectory.Checked = true;
            this.checkBox_Subdirectory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Subdirectory.Location = new System.Drawing.Point(792, 41);
            this.checkBox_Subdirectory.Name = "checkBox_Subdirectory";
            this.checkBox_Subdirectory.Size = new System.Drawing.Size(115, 21);
            this.checkBox_Subdirectory.TabIndex = 6;
            this.checkBox_Subdirectory.Text = "Подкаталоги";
            this.checkBox_Subdirectory.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Файл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Слово или фраза в файле";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(512, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Диски";
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Location = new System.Drawing.Point(263, 84);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(0, 17);
            this.label_result.TabIndex = 7;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 602);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Subdirectory);
            this.Controls.Add(this.listView_SearchResults);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.textBox_Phrase);
            this.Controls.Add(this.comboBox_Disk);
            this.Controls.Add(this.textBox_File);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Поиск файлов и папок";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_File;
        private System.Windows.Forms.ComboBox comboBox_Disk;
        private System.Windows.Forms.TextBox textBox_Phrase;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.ListView listView_SearchResults;
        private System.Windows.Forms.CheckBox checkBox_Subdirectory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.ImageList imageList1;
    }
}

