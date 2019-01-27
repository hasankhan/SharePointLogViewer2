namespace SharePointLogViewer.Notifiers
{
    interface INotifier
    {
        void Notify(LogEntryViewModel logEntry);
    }
}
