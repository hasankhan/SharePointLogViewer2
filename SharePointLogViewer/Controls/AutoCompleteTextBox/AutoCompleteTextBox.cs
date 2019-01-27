﻿using System;
using System.Linq;
using System.Windows.Controls;

namespace SharePointLogViewer.Controls.AutoCompleteTextBox
{
    public class AutoCompleteTextBox : TextBox
    {
        private AutoCompleteManager _acm;

        public AutoCompleteManager AutoCompleteManager
        {
            get { return _acm; }
        }

        public AutoCompleteTextBox()
        {
            _acm = new AutoCompleteManager();
            _acm.DataProvider = new SimpleStaticDataProvider(Enumerable.Empty<String>());
            this.Loaded += AutoCompleteTextBox_Loaded;
        }

        void AutoCompleteTextBox_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                _acm.AttachTextBox(this);
        }
        
    }
}
