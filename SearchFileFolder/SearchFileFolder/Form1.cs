using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchFileFolder
{
    public partial class Form1 : Form, ISearchView
    {
        public Form1()
        {
            InitializeComponent();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (var drive in allDrives)
                comboBox_Disk.Items.Add(drive.Name);
            comboBox_Disk.SelectedIndex = 0;
            SearchPresenter search_presenter = new SearchPresenter(this);
            SearchResult.SmallImageList = IconsAssociated;

              System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control)
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            controlProperty.SetValue(listView_SearchResults, true, null);
        }

        #region ISearchView Implementation

        public string File { get { return textBox_File.Text; } }
        public string Phrase { get { return textBox_Phrase.Text; } }
        public string Disk { get { return comboBox_Disk.Items[comboBox_Disk.SelectedIndex].ToString();} }
        public bool Subdirectoty { get { return checkBox_Subdirectory.Checked; } }
        public ListView SearchResult { get { return listView_SearchResults; } }
        public ImageList IconsAssociated { get { return imageList1; } }
        public void setInfoResults(int count_files)
        {
            string info = "Результаты поиска: количество найденных файлов - ";
            label_result.Text = info + count_files;
            button_Search.Enabled = true;
            button_Stop.Enabled = false;
        }
        public event EventHandler<EventArgs> Search_event;
        public event EventHandler<EventArgs> Stop_event;

        #endregion

        private void button_Search_Click(object sender, EventArgs e)
        {
            button_Search.Enabled = false;
            button_Stop.Enabled = true;
            label_result.Text = "";
            if (listView_SearchResults.Items.Count != 0)
                listView_SearchResults.Items.Clear();
            IconsAssociated.Images.Clear();
            if (Search_event != null)
            {
                Search_event(sender, EventArgs.Empty);
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            if (Stop_event != null)
            {
                Stop_event(sender, EventArgs.Empty);
            }
        }
    }
}
