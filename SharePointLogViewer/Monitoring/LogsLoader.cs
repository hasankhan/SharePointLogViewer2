using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SharePointLogViewer.Monitoring
{
    class LoadCompletedEventArgs : EventArgs
    {
        public IEnumerable<LogEntry> LogEntries { get; set; }
    }

    class LogsLoader
    {
        public event EventHandler<LoadCompletedEventArgs> LoadCompleted = delegate { };
        List<LogEntry> logEntries = new List<LogEntry>();
        BackgroundWorker worker;

        public LogsLoader()
        {
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadCompleted(this, new LoadCompletedEventArgs() { LogEntries = logEntries });            
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            logEntries.Clear();
            if (e.Argument is string[] files)
                foreach (string file in files)
                    logEntries.AddRange(LogParser.PraseLog(file));
        }

        public void Start(string[] files)
        {
            worker.RunWorkerAsync(files);
        }
    }
}
