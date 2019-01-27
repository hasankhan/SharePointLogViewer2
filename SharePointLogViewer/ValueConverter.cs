using System;
using System.Windows.Data;

using System.Windows.Controls;
using System.Windows.Media;


namespace SharePointLogViewer
{
    public sealed class BackgroundStripe : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            ListViewItem item = (ListViewItem)value;

            // Get the index of a ListViewItem
            if (ItemsControl.ItemsControlFromItemContainer(item) is ListView listView)
            {
                int index = listView.ItemContainerGenerator.IndexFromContainer(item ?? throw new InvalidOperationException());

                if (index % 2 == 0)
                {
                    return new SolidColorBrush(Colors.LightGray);
                }
                else
                {
                    return new SolidColorBrush(Colors.White);
                }
            }

            return null;
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

    }
}
