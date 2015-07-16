using System.Diagnostics;
using System.Windows;

namespace Shikashi
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            BuildLabel.Content = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
        }

        private void Button_Click_GitHub(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/martinmine/Shikashi-Uploader");
        }

        private void Button_Click_Hyperdesktop(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/TheTarkus/Hyperdesktop2/");
        }
    }
}
