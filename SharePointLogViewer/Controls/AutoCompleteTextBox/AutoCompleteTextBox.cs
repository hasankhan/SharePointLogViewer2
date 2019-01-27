using System;
using System.Linq;
using System.Windows.Controls;

namespace SharePointLogViewer.Controls.AutoCompleteTextBox
{
    public class AutoCompleteTextBox : TextBox
    {
        public AutoCompleteManager AutoCompleteManager { get; }

        public AutoCompleteTextBox()
        {
            AutoCompleteManager = new AutoCompleteManager();
            AutoCompleteManager.DataProvider = new SimpleStaticDataProvider(Enumerable.Empty<String>());
            Loaded += AutoCompleteTextBox_Loaded;
        }

        void AutoCompleteTextBox_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                AutoCompleteManager.AttachTextBox(this);
        }
        
    }
}
