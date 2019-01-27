namespace SharePointLogViewer.Filters
{
    interface IFilter
    {
        bool Accept(LogEntryViewModel logEntry);
    }
}
