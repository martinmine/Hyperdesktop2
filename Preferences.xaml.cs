using ModernWPF;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace Shikashi
{
    /// <summary>
    /// Interaction logic for Preferences.xaml
    /// </summary>
    public partial class Preferences : Window
    {
        internal string RegionalHotkeyDescription { get; set; }
        internal string WindowedHotkeyDescription { get; set; }
        internal string FullHotkeyDescription { get; set; }

        private int hotkeyContext = -1;
        private int keyCounter = 0;

        public Preferences()
        {
            InitializeComponent();

            if (Properties.Settings.Default.RegionalScreenshotHotkeyFirst > 0)
                RegionalScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.RegionalScreenshotHotkeyFirst).ToString() + " ";

            if (Properties.Settings.Default.RegionalScreenshotHotkeySecond > 0)
                RegionalScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.RegionalScreenshotHotkeySecond).ToString() + " ";

            if (Properties.Settings.Default.RegionalScreenshotHotkeyThird > 0)
                RegionalScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.RegionalScreenshotHotkeyThird).ToString() + " ";

            if (Properties.Settings.Default.RegionalScreenshotHotkeyValue > 0)
                RegionalScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.RegionalScreenshotHotkeyValue).ToString() + " ";


            if (Properties.Settings.Default.WindowedScreenshotHotkeyFirst > 0)
                WindowedScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.WindowedScreenshotHotkeyFirst).ToString() + " ";

            if (Properties.Settings.Default.WindowedScreenshotHotkeySecond > 0)
                WindowedScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.WindowedScreenshotHotkeySecond).ToString() + " ";

            if (Properties.Settings.Default.WindowedScreenshotHotkeyThird > 0)
                WindowedScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.WindowedScreenshotHotkeyThird).ToString() + " ";

            if (Properties.Settings.Default.WindowedScreenshotHotkeyValue > 0)
                WindowedScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.WindowedScreenshotHotkeyValue).ToString() + " ";


            if (Properties.Settings.Default.FullScreenshotHotkeyFirst > 0)
                FullscreenScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.FullScreenshotHotkeyFirst).ToString() + " ";

            if (Properties.Settings.Default.FullScreenshotHotkeySecond > 0)
                FullscreenScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.FullScreenshotHotkeySecond).ToString() + " ";

            if (Properties.Settings.Default.FullScreenshotHotkeyThird > 0)
                FullscreenScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.FullScreenshotHotkeyThird).ToString() + " ";

            if (Properties.Settings.Default.FullScreenshotHotkeyValue > 0)
                FullscreenScreenshotHotkeyBtn.Content += ((Key)Properties.Settings.Default.FullScreenshotHotkeyValue).ToString() + " ";

            HotkeyManager.GetInstance().UnregisterHotkeys();

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version version = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                BuildLabel.Content = string.Format("Version {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.UseDarkTheme)
                ModernTheme.ApplyTheme(ModernTheme.Theme.Dark, ModernTheme.CurrentAccent);
            else
                ModernTheme.ApplyTheme(ModernTheme.Theme.Light, ModernTheme.CurrentAccent);

            HotkeyManager.GetInstance().RegisterHotkeys();
            base.OnClosing(e);
        }

        private void SelectSaveFolder(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browseFolder = new FolderBrowserDialog();
            if (browseFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Properties.Settings.Default.SaveFolder = browseFolder.SelectedPath;
        }

        private void SetRegionalScreenshotHotkeys(object sender, RoutedEventArgs e)
        {
            hotkeyContext = 0;
            keyCounter = 0;

            RegionalScreenshotHotkeyBtn.Content = string.Empty;
            pressedKeys.Clear();

            Properties.Settings.Default.RegionalScreenshotHotkeyFirst = 0;
            Properties.Settings.Default.RegionalScreenshotHotkeySecond = 0;
            Properties.Settings.Default.RegionalScreenshotHotkeyThird = 0;
            Properties.Settings.Default.RegionalScreenshotHotkeyValue = 0;
        }

        private void SetWindowedScreenshotHotkeys(object sender, RoutedEventArgs e)
        {
            hotkeyContext = 1;
            keyCounter = 0;
            pressedKeys.Clear();
            WindowedScreenshotHotkeyBtn.Content = string.Empty;

            Properties.Settings.Default.WindowedScreenshotHotkeyFirst = 0;
            Properties.Settings.Default.WindowedScreenshotHotkeySecond = 0;
            Properties.Settings.Default.WindowedScreenshotHotkeyThird = 0;
            Properties.Settings.Default.WindowedScreenshotHotkeyValue = 0;
        }

        private void SetFullScreenshotHotkeys(object sender, RoutedEventArgs e)
        {
            hotkeyContext = 2;
            keyCounter = 0;
            pressedKeys.Clear();
            
            FullscreenScreenshotHotkeyBtn.Content = string.Empty;
            Properties.Settings.Default.FullScreenshotHotkeyFirst = 0;
            Properties.Settings.Default.FullScreenshotHotkeySecond = 0;
            Properties.Settings.Default.FullScreenshotHotkeyThird = 0;
            Properties.Settings.Default.FullScreenshotHotkeyValue = 0;
        }

        private List<Key> pressedKeys = new List<Key>();

        #region Ugly code
        // This code should be generalized somehow
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (pressedKeys.Contains(e.Key))
                return;

            switch (hotkeyContext)
            {
                case 0:
                    {
                        if (KeyUtil.IsModifierKeys(e.Key) && keyCounter <= 2)
                        {
                            if (keyCounter == 0)
                            {
                                Properties.Settings.Default.RegionalScreenshotHotkeyFirst = (int)e.Key;
                                RegionalScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                                pressedKeys.Add(e.Key);
                                keyCounter++;
                            }
                            else if (keyCounter == 1)
                            {
                                Properties.Settings.Default.RegionalScreenshotHotkeySecond = (int)e.Key;
                                RegionalScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                                pressedKeys.Add(e.Key);
                                keyCounter++;
                            }
                            else if (keyCounter == 2)
                            {
                                Properties.Settings.Default.RegionalScreenshotHotkeyThird = (int)e.Key;
                                RegionalScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                                pressedKeys.Add(e.Key);
                                keyCounter++;
                            }
                        }
                        else if (keyCounter > 1 && !KeyUtil.IsModifierKeys(e.Key))
                        { 
                            Properties.Settings.Default.RegionalScreenshotHotkeyValue = (int)e.Key;
                            RegionalScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                            pressedKeys.Add(e.Key);
                            hotkeyContext = -1;
                        }
                        break;
                    }
                case 1:
                    {
                        if (KeyUtil.IsModifierKeys(e.Key) && keyCounter <= 2)
                        {
                            if (keyCounter == 0)
                            {
                                Properties.Settings.Default.WindowedScreenshotHotkeyFirst = (int)e.Key;
                                WindowedScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                                pressedKeys.Add(e.Key);
                                keyCounter++;
                            }
                            else if (keyCounter == 1)
                            {
                                Properties.Settings.Default.WindowedScreenshotHotkeySecond = (int)e.Key;
                                WindowedScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                                pressedKeys.Add(e.Key);
                                keyCounter++;
                            }
                            else if (keyCounter == 2)
                            {
                                Properties.Settings.Default.WindowedScreenshotHotkeyThird = (int)e.Key;
                                WindowedScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                                pressedKeys.Add(e.Key);
                                keyCounter++;
                            }
                        }
                        else if (keyCounter > 1 && !KeyUtil.IsModifierKeys(e.Key))
                        {
                            Properties.Settings.Default.WindowedScreenshotHotkeyValue = (int)e.Key;
                            WindowedScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                            pressedKeys.Add(e.Key);
                            hotkeyContext = -1;
                        }
                        break;
                    }

                case 2:
                    {
                        if (KeyUtil.IsModifierKeys(e.Key) && keyCounter <= 2)
                        {
                            if (keyCounter == 0)
                            {
                                Properties.Settings.Default.FullScreenshotHotkeyFirst = (int)e.Key;
                                FullscreenScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                                pressedKeys.Add(e.Key);
                                keyCounter++;
                            }
                            else if (keyCounter == 1)
                            {
                                Properties.Settings.Default.FullScreenshotHotkeySecond = (int)e.Key;
                                FullscreenScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                                pressedKeys.Add(e.Key);
                                keyCounter++;
                            }
                            else if (keyCounter == 2)
                            {
                                Properties.Settings.Default.FullScreenshotHotkeyThird = (int)e.Key;
                                FullscreenScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                                pressedKeys.Add(e.Key);
                                keyCounter++;
                            }
                        }
                        else if (keyCounter > 1 && !KeyUtil.IsModifierKeys(e.Key))
                        {
                            Properties.Settings.Default.FullScreenshotHotkeyValue = (int)e.Key;
                            FullscreenScreenshotHotkeyBtn.Content += e.Key.ToString() + " ";
                            pressedKeys.Add(e.Key);
                            hotkeyContext = -1;
                        }
                        break;
                    }
            }
        }
        #endregion

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HotkeysTab == null || !HotkeysTab.IsSelected)
            {
                hotkeyContext = -1;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception("foobar");
            AppServices.UpdateHelper.CheckForUpdates(true);
        }

        private void Button_Click_Hyperdesktop(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/TheTarkus/Hyperdesktop2/");
        }

        private void Button_Click_GitHub(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/martinmine/Shikashi-Uploader");
        }
    }
}
