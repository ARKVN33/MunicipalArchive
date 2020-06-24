using System.Windows.Media;

namespace MunicipalArchive
{
    /// <summary>
    /// Interaction logic for CustomControl.xaml
    /// </summary>
    public partial class CustomControl1
    {
        public CustomControl1()
        {
            InitializeComponent();
        }

        public ImageSource SettingImageSource
        {
            get { return ImgSetting.Source; }
            set { ImgSetting.Source = value; }
        }

        public string SettingText
        {
            get { return LblSetting.Content.ToString(); }
            set { LblSetting.Content = value; }
        }
    }
}
