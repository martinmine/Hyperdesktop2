using Microsoft.Win32;
using ModernWPF;
using Shikashi.API;
using Shikashi.Uploading;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace Shikashi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IUploadStatusListener
    {
        private ObservableCollection<UploadedContent> userContent = new ObservableCollection<UploadedContent>();
        private Uploader uploader;

        public MainWindow()
        {
            InitializeComponent();

            ApplicationTrayIcon.TrayBalloonTipClicked += ApplicationTrayIcon_TrayBalloonTipClicked;
            this.uploader = new Uploader(this, new AnimatedTaskbarIcon(Dispatcher, Icon));
            uploader.OnUploadCompleted += HandleFileUploadResult;

            if (Properties.Settings.Default.UseDarkTheme)
                ModernTheme.ApplyTheme(ModernTheme.Theme.Dark, ModernTheme.CurrentAccent);

            ModernTheme.ApplyTheme(ModernTheme.CurrentTheme.GetValueOrDefault(), new Accent("Shikashi Theme", System.Windows.Media.Color.FromRgb(255 ,255 ,255)));

            if (!Properties.Settings.Default.AskedForStartup)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show(
                    "Do you want to run Shikashi Uploader at Windows startup?",
                    "First time run",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes
                );

                if (result == MessageBoxResult.Yes)
                {
                    GlobalFunctions.SetRunAtStartup(true);
                    Properties.Settings.Default.RunAtStartup = true;
                }
                Properties.Settings.Default.AskedForStartup = true;
                Properties.Settings.Default.SaveFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Captures";
                Properties.Settings.Default.Save();
            }

            GlobalFunctions.CheckStartupPath();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.CurrentUser))
                PasswordField.Password = "*********";

            UploadList.ItemsSource = userContent;

            HotkeyManager.GetInstance().SetListener(uploader);
            HotkeyManager.GetInstance().RegisterHotkeys();
            SetButtonsEnabled();
            LoadUserImages();
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }

        private void PreferencesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Preferences prefs = new Preferences();
            prefs.ShowDialog();
        }

        #region Button event handlers
        private void Capture(object sender, RoutedEventArgs e)
        {
            uploader.CaptureScreen("screen");
        }

        private void CaptureRegion(object sender, RoutedEventArgs e)
        {
            uploader.CaptureScreen("region");
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.AuthKey = string.Empty;
            Properties.Settings.Default.AuthExpirationTime = 0;
            Properties.Settings.Default.Save();

            userContent.Clear();
            SetButtonsEnabled();
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            LoginProvider loginProvider = new LoginProvider(EmailField.Text, PasswordField.Password);
            LoginResult loginResult = await loginProvider.PerformLogin();

            switch (loginResult)
            {
                case LoginResult.InvalidCredentials:
                    MessageBox.Show("Unknown username/password", "Login error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case LoginResult.UnknownError:
                    MessageBox.Show("Unable to connect to Shikashi", "Login error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case LoginResult.Success:
                    SetButtonsEnabled();
                    Properties.Settings.Default.CurrentUser = EmailField.Text;
                    Properties.Settings.Default.Save();
                    LoadUserImages();
                    MessageBox.Show("Login Successful", "Login success", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        private void HideWindow(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            ApplicationTrayIcon.Dispose();
            Environment.Exit(0);
        }

        private void RegisterHotkeys(object sender, RoutedEventArgs e)
        {
            HotkeyManager.GetInstance().UnregisterHotkeys();
            HotkeyManager.GetInstance().RegisterHotkeys();
        }
        #endregion

        private async void LoadUserImages()
        {
            UploadedContent[] items = await ListUploadedImagesRequest.GetImages();

            if (items == null)
            {
                Logout(null, null);
                return;
            }

            Array.Reverse(items, 0, items.Length);

            foreach (UploadedContent item in items) 
            {
                userContent.Add(item);
            }
        }

        #region Image processing

        private void HandleFileUploadResult(FileUploadResult result)
        {
            switch (result)
            {
                case FileUploadResult.Failed:
                    GlobalFunctions.PlaySound(Properties.Resources.error);
                    BalloonTip("Error uploading file!", "Error", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Error);
                    break;

                case FileUploadResult.InvalidCredentials:
                    GlobalFunctions.PlaySound(Properties.Resources.error);
                    BalloonTip("Your credentials were invalid, please sign in again", "Error", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Error);
                    break;

                case FileUploadResult.NotAuthorized:
                    GlobalFunctions.PlaySound(Properties.Resources.error);
                    BalloonTip("You need to sign in before uploading", "Error", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Error);
                    break;

                case FileUploadResult.FileTooLarge:
                    GlobalFunctions.PlaySound(Properties.Resources.error);
                    BalloonTip("This file was too large to be uploaded", "Error", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Error);
                    break;
            }
        }
        #endregion

        private string lastViewedLink;

        private void BalloonTip(string text, string title, int duration, Hardcodet.Wpf.TaskbarNotification.BalloonIcon icon = Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Info, string link = null)
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

        private void SetButtonsEnabled()
        {
            bool loggedIn = (AuthKey.LoadKey() != null);

            EmailField.IsEnabled = !loggedIn;
            PasswordField.IsEnabled = !loggedIn;
            LoginBtn.IsEnabled = !loggedIn;
            LogoutBtn.IsEnabled = loggedIn;

            if (PasswordField.IsEnabled)
                PasswordField.Password = string.Empty;
        }

        #region Callbacks from interfaces
        public void ContentUplaoded(UploadedContent content)
        {
            ProgressGroupBox.Header = "Upload Progress";
            UploadProgressBar.Value = 0;

            userContent.Insert(0, content);

            string link = string.Format("{0}/{1}", APIConfig.BaseURL, content.Key);

            if (Properties.Settings.Default.CopyLinksToClipboard)
                Clipboard.SetText(link);

            if (Properties.Settings.Default.BalloonMessages)
                BalloonTip("Link copied to clipboard:" + Environment.NewLine + link, "Upload Completed!", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Info, link);

            if (Properties.Settings.Default.LaunchBrowser)
                Process.Start(link);

            GlobalFunctions.PlaySound(Properties.Resources.success);
        }

        private DateTime lastUpdate;

        public void OnProgress(long uploaded, long total)
        {
            if (lastUpdate != null && (DateTime.Now - lastUpdate).Milliseconds < 100)
                return;
            lastUpdate = DateTime.Now;

            int percent = (int)((uploaded / (double)total) * 100);

            Dispatcher.Invoke(() =>
            {
                ProgressGroupBox.Header = string.Format("Upload Progress - {0}% ({1}kb/{2}kb)", percent, uploaded / 1024, total / 1024);
                UploadProgressBar.Value = percent;
            });
        }
        #endregion

        private void MinimizeToTray(object sender, RoutedEventArgs e)
        {
            this.Hide();
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
                await uploader.UploadImage(image);
            }
            else if (Clipboard.ContainsFileDropList())
            {
                foreach (string path in Clipboard.GetFileDropList())
                {
                    await uploader.UploadFile(path);
                }
            }
        }

        private async void UploadFiles(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;

            bool? result = dialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                foreach (string fileName in dialog.FileNames)
                {
                    await uploader.UploadFile(fileName);
                }
            }
        }

        private void TrayIconClicked(object sender, RoutedEventArgs e)
        {
            this.Show();
            WindowState = System.Windows.WindowState.Normal;
            Activate();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            WindowState = System.Windows.WindowState.Minimized;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Minimized)
                Hide();
        }

        #region Right-click handlers
        private void OpenSelectedUpload(object sender, RoutedEventArgs e)
        {
            if (UploadList.SelectedIndex < 0)
                return;

            UploadedContent selectedItem = userContent[UploadList.SelectedIndex];
            Process.Start(string.Format("{0}/{1}", APIConfig.BaseURL, selectedItem.Key));
        }

        private void CopySelectedUpload(object sender, RoutedEventArgs e)
        {
            UploadedContent selectedItem = userContent[UploadList.SelectedIndex];
            string link = string.Format("{0}/{1}", APIConfig.BaseURL, selectedItem.Key);
            Clipboard.SetText(link);
        }

        private async void DeleteSelectedUpload(object sender, RoutedEventArgs e)
        {
            UploadedContent selectedItem = userContent[UploadList.SelectedIndex];

            if (await DeleteImageRequest.RequestDeletion(selectedItem.Key))
            {
                userContent.RemoveAt(UploadList.SelectedIndex);
            }
            else
            {
                GlobalFunctions.PlaySound(Properties.Resources.error);

                if (Properties.Settings.Default.BalloonMessages)
                    BalloonTip("Could not delete file!", "Error", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Error);
            }
        }
        #endregion

        private async void GroupBox_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                await uploader.UploadFile(file);
            }
        }

        private void UploadList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenSelectedUpload(sender, null);
        }
    }
}
