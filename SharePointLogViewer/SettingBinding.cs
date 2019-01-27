using System.Windows.Data;

namespace SharePointLogViewer
{
    public class SettingBinding : Binding
    {
        public SettingBinding(string path): base(path)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.Source = SharePointLogViewer.Properties.Settings.Default;
            this.Mode = BindingMode.TwoWay;
        }
    }
}
