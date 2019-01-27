using System;
using SharePointLogViewer.Controls;

namespace SharePointLogViewer
{
    class LogFilterListView : FilterableListView
    {
        protected override Type ListItemType
        {
            get { return typeof(LogEntryViewModel); }
        }
    }
}
