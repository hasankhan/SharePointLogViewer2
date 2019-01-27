﻿using System.Windows;

namespace SharePointLogViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool RunInBackground { get; set; }

        public static string FileToOpen { get; set; }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            SharePointLogViewer.Properties.Settings.Default.Save();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length > 0)
                if (e.Args[0].Trim() == "/background")
                    RunInBackground = true;
                else
                    FileToOpen = e.Args[0];
        }
    }
}
