using System;
using System.Deployment.Application;
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
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version version = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                BuildLabel.Content = string.Format("Version {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            }
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
