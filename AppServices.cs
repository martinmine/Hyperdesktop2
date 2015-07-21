using Hardcodet.Wpf.TaskbarNotification;
using ModernWPF;
using Shikashi.API;
using Shikashi.Uploading;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Shikashi
{
    partial class AppServices : IUploadStatusListener
    {
        internal static Uploader Uploader { get; private set; }
        internal static UpdateHelper UpdateHelper { get; private set; }

        private static MainWindow mainWindow;
        private static string lastViewedLink;
        private static TaskbarIcon ApplicationTrayIcon;

        public void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            Uploader = new Uploader(this);
            UpdateHelper = new UpdateHelper();

            Uploader.OnUploadCompleted += Uploader_OnUploadCompleted;
            
            if (!Shikashi.Properties.Settings.Default.AskedForStartup)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show(
                    "Do you want to run Shikashi Uploader at Windows startup?",
                    "First time run",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes
                );

                if (result == MessageBoxResult.Yes)
                {
                    GlobalFunctions.SetRunAtStartup(true);
                    Shikashi.Properties.Settings.Default.RunAtStartup = true;
                }

                Shikashi.Properties.Settings.Default.AskedForStartup = true;
                Shikashi.Properties.Settings.Default.SaveFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Captures";
                Shikashi.Properties.Settings.Default.Save();
            }

            if (Shikashi.Properties.Settings.Default.UseDarkTheme)
                ModernTheme.ApplyTheme(ModernTheme.Theme.Dark, ModernTheme.CurrentAccent);

            GlobalFunctions.CheckStartupPath();
            HotkeyManager.GetInstance().SetListener(Uploader);
            HotkeyManager.GetInstance().RegisterHotkeys();
            UpdateHelper.CheckForUpdates();

            ShowTaskbarIcon();
        }

        private void Uploader_OnUploadCompleted(FileUploadResult result)
        {
            switch (result)
            {
                case FileUploadResult.Failed:
                    GlobalFunctions.PlaySound(Shikashi.Properties.Resources.error);
                    ShowBalloonTip("Error uploading file!", "Error", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Error);
                    break;

                case FileUploadResult.InvalidCredentials:
                    GlobalFunctions.PlaySound(Shikashi.Properties.Resources.error);
                    ShowBalloonTip("Your credentials were invalid, please sign in again", "Error", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Error);
                    break;

                case FileUploadResult.NotAuthorized:
                    GlobalFunctions.PlaySound(Shikashi.Properties.Resources.error);
                    ShowBalloonTip("You need to sign in before uploading", "Error", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Error);
                    break;

                case FileUploadResult.FileTooLarge:
                    GlobalFunctions.PlaySound(Shikashi.Properties.Resources.error);
                    ShowBalloonTip("This file was too large to be uploaded", "Error", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Error);
                    break;
            }
        }

        private void ApplicationTrayIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            ShowMainWindow();
        }

        private void ShowTaskbarIcon()
        {
            ApplicationTrayIcon = new TaskbarIcon()
            {
                ToolTipText = "Shikashi Uploader",
                Icon = Shikashi.Properties.Resources.icon,
            };

            ApplicationTrayIcon.TrayBalloonTipClicked += ApplicationTrayIcon_TrayBalloonTipClicked;
            ApplicationTrayIcon.TrayMouseDoubleClick += ApplicationTrayIcon_TrayMouseDoubleClick;

            MenuItem minimizeToTray = new MenuItem();
            minimizeToTray.Header = "Minimize to tray";
            minimizeToTray.Click += MinimizeToTray;

            MenuItem openDashboard = new MenuItem();
            openDashboard.Header = "Dashboard";
            openDashboard.Click += OpenDashboard;

            MenuItem regionalScreenshot = new MenuItem();
            regionalScreenshot.Header = "Take Region Screenshot";
            regionalScreenshot.Click += RegionalScreenshot_Click;

            MenuItem screenshot = new MenuItem();
            screenshot.Header = "Take Screenshot";
            screenshot.Click += Screenshot_Click;

            MenuItem clipboardUpload = new MenuItem();
            clipboardUpload.Header = "Upload from clipboard";
            clipboardUpload.Click += UploadFromClipboard;

            MenuItem about = new MenuItem();
            about.Header = "About";
            about.Click += About_Click;

            MenuItem exit = new MenuItem();
            exit.Header = "Exit";
            exit.Click += Exit_Click;

            ApplicationTrayIcon.ContextMenu = new ContextMenu();
            ApplicationTrayIcon.ContextMenu.Items.Add(minimizeToTray);
            ApplicationTrayIcon.ContextMenu.Items.Add(openDashboard);
            ApplicationTrayIcon.ContextMenu.Items.Add(regionalScreenshot);
            ApplicationTrayIcon.ContextMenu.Items.Add(screenshot);
            ApplicationTrayIcon.ContextMenu.Items.Add(new Separator());
            ApplicationTrayIcon.ContextMenu.Items.Add(clipboardUpload);
            ApplicationTrayIcon.ContextMenu.Items.Add(about);
            ApplicationTrayIcon.ContextMenu.Items.Add(exit);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Exit();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }

        private void Screenshot_Click(object sender, RoutedEventArgs e)
        {
            Uploader.CaptureScreen("screen");
        }

        private void RegionalScreenshot_Click(object sender, RoutedEventArgs e)
        {
            Uploader.CaptureScreen("regional");
        }
        #region Systray callbacks

        private void MinimizeToTray(object sender, RoutedEventArgs e)
        {
            CloseMainWindow();
        }

        private void OpenDashboard(object sender, RoutedEventArgs e)
        {
            Process.Start("https://panel.shikashi.me/login");
        }

        private async void UploadFromClipboard(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                System.Drawing.Image image = System.Windows.Forms.Clipboard.GetImage();
                await Uploader.UploadImage(image);
            }
            else if (Clipboard.ContainsFileDropList())
            {
                foreach (string path in Clipboard.GetFileDropList())
                {
                    await Uploader.UploadFile(path);
                }
            }
        }
        #endregion
       
        internal static new void Exit()
        {
            ApplicationTrayIcon.Dispose();
            Environment.Exit(0);
        }

        internal static void ShowBalloonTip(string text, string title, int duration, Hardcodet.Wpf.TaskbarNotification.BalloonIcon icon = Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Info, string link = null)
        {
            ApplicationTrayIcon.ShowBalloonTip(title, text, icon);
            lastViewedLink = link;
        }

        private void ApplicationTrayIcon_TrayBalloonTipClicked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(lastViewedLink))
            {
                Process.Start(lastViewedLink);
            }
        }

        public void ContentUplaoded(UploadedContent content)
        {
            string link = string.Format("{0}/{1}", APIConfig.BaseURL, content.Key);

            if (Shikashi.Properties.Settings.Default.CopyLinksToClipboard)
                Clipboard.SetText(link);

            if (Shikashi.Properties.Settings.Default.BalloonMessages)
                ShowBalloonTip("Link copied to clipboard:" + Environment.NewLine + link, "Upload Completed!", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Info, link);

            if (Shikashi.Properties.Settings.Default.LaunchBrowser)
                Process.Start(link);

            GlobalFunctions.PlaySound(Shikashi.Properties.Resources.success);

            if (mainWindow != null)
                mainWindow.ContentUplaoded(content);
        }

        public void OnProgress(long uploaded, long total)
        {
            if (mainWindow != null)
                mainWindow.OnProgress(uploaded, total);
        }

        internal static void ShowMainWindow()
        {
            if (mainWindow == null)
            {
                mainWindow = new Shikashi.MainWindow();
                mainWindow.Show();
            }
            else
            {
                mainWindow.Activate();
            }
        }

        internal static void CloseMainWindow()
        {
            if (mainWindow != null)
            {
                if (!mainWindow.WindowClosed)
                    mainWindow.Close();

                mainWindow = null;
            }
        }
    }
}
