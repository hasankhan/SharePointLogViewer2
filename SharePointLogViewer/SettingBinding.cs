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
            Source = Properties.Settings.Default;
            Mode = BindingMode.TwoWay;
        }
    }
}
