using System;
using SharePointLogViewer.Controls;

namespace SharePointLogViewer
{
    class LogFilterListView : FilterableListView
    {
        protected override Type ListItemType => typeof(LogEntryViewModel);
    }
}
