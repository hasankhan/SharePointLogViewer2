using System;
using System.Windows;
using System.Windows.Controls;

namespace SharePointLogViewer.Controls
{
    /// <summary>
    /// Interaction logic for LoadingAnimation.xaml
    /// </summary>
    public partial class LoadingAnimation : UserControl
    {
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(LoadingAnimation), new PropertyMetadata("Loading..."));

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public LoadingAnimation()
        {
            InitializeComponent();
        }
    }
}
