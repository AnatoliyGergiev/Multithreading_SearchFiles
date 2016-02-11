using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchFileFolder
{
    interface ISearchView
    {
        string File { get; }
        string Phrase { get; }
        string Disk { get; }
        bool Subdirectoty { get; }
        ListView SearchResult { get; }
        ImageList IconsAssociated { get; }
        void setInfoResults(int count_files);
        event EventHandler<EventArgs> Search_event;
        event EventHandler<EventArgs> Stop_event;
    }
}
