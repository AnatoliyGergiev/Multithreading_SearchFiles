using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchFileFolder
{
    class SearchPresenter
    {
        private readonly ISearchView _searchview;
        private readonly Model _model = new Model();
        public SearchPresenter(ISearchView searchview)
        {
            _searchview = searchview;
            _searchview.Search_event += new EventHandler<EventArgs>(OnSearch);
            _searchview.Stop_event += new EventHandler<EventArgs>(OnStop);
            _model.Found_event += new EventHandler<List<System.IO.FileInfo>>(Display);
            _model.SearchFinished += new EventHandler<EventArgs>(OnFinished);
            //UpdateView();
        }

        //public SynchronizationContext uiContext;
        //Thread thread = null;
        private void OnSearch(object sender, EventArgs e)
        {
            index = 0;
            _model.File = _searchview.File;
            _model.Phrase = _searchview.Phrase;
            _model.Disk = _searchview.Disk;
            _model.Subdirectory = _searchview.Subdirectoty;

            //Thread th = new Thread(new ThreadStart(_model.Search));
            //th.IsBackground = true;
            //th.Start();
            //Thread.Sleep(2000);
            _model.Search();
            
        }
        delegate ListViewItem AddItemDelegate(ListViewItem item);
        delegate void AddIconDelegate(Icon icon);
        int index = 0;
        public void Display(object sender, List<FileInfo> files)
        {
            foreach (var file in files)
            {
                string[] columns = { file.Name, file.FullName, (file.Length / 1024).ToString() + "байт", file.CreationTime.ToString() };
                //var item = new System.Windows.Forms.ListViewItem(columns);
                var item = new ListViewItem(columns, index++);
                AddItemDelegate additem = new AddItemDelegate(_searchview.SearchResult.Items.Add);
                _searchview.SearchResult.Invoke(additem, item);
                AddIconDelegate addicon = new AddIconDelegate(_searchview.IconsAssociated.Images.Add);
               _searchview.SearchResult.Invoke(addicon, Icon.ExtractAssociatedIcon(file.FullName));

                //_searchview.GetMethod()
                //_searchview.addSearchResult.Invoke(add, item);
                
            }
        }
        private void OnStop(object sender, EventArgs e)
        {
            _model.stop_search = true;
        }
        delegate void SetInfoDelegate(int count);
        private void OnFinished(object sender, EventArgs e)
        {
            if (_searchview.SearchResult.InvokeRequired)
            {
                SetInfoDelegate setinfo = new SetInfoDelegate(_searchview.setInfoResults);
                _searchview.SearchResult.Invoke(setinfo, _model.files.Count);
            }
            else
                _searchview.setInfoResults(_model.files.Count);
            _model.stop_search = false;
        }
        
    }
}
