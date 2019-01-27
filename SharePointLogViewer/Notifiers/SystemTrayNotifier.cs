﻿using System;
using System.IO;

namespace SharePointLogViewer.Notifiers
{
    class SystemTrayNotifier : INotifier, IDisposable
    {
        private System.Windows.Forms.NotifyIcon notifier;

        public event EventHandler Click = delegate { };

        public SystemTrayNotifier()
        {
            notifier = new System.Windows.Forms.NotifyIcon();
            using (Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,/Images/SPLV.ico")).Stream)
                notifier.Icon = new System.Drawing.Icon(iconStream);
            notifier.Click += notifyIcon_Click;
            notifier.BalloonTipClicked += notifyIcon_Click;
        }

        public void Notify(LogEntryViewModel logEntry)
        {
            Notify(logEntry.Message);
        }

        public void Notify(string message)
        {
            if (notifier != null && notifier.Visible)
            {
                notifier.BalloonTipText = message;
                notifier.BalloonTipTitle = "SharePoint LogViewer";
                notifier.Text = "SharePoint LogViewer";
                notifier.ShowBalloonTip(2000);
            }
        }

        public void Show(bool show)
        {
            if (notifier != null)
                notifier.Visible = show;
        }

        void notifyIcon_Click(object sender, EventArgs e)
        {
            Click(sender, e);
        }

        #region IDisposable Members

        public void Dispose()
        {
            notifier.Dispose();
            notifier = null;
        }

        #endregion
    }
}
