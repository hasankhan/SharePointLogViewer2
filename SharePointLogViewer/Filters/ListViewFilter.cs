using System.Windows.Controls;

namespace SharePointLogViewer.Filters
{
    class ListViewFilter: IFilter
    {
        ListView lstLog;

        public ListViewFilter(ListView lstLog)
        {
            this.lstLog = lstLog;
        }

        #region ILogEntryFilter Members

        public bool Accept(LogEntryViewModel logEntry)
        {
            bool accept = (lstLog.Items.Filter == null || lstLog.Items.Filter(logEntry));
            return accept;
        }

        #endregion
    }
}
