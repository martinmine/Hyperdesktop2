using Microsoft.Win32;
using ModernWPF;
using Shikashi.API;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace Shikashi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IUploadStatusListener
    {
        //private ObservableCollection<UploadedContent> userContent = new ObservableCollection<UploadedContent>();
        internal bool WindowClosed { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            WindowClosed = false;

            if (Properties.Settings.Default.UseDarkTheme)
                ModernTheme.ApplyTheme(ModernTheme.Theme.Dark, ModernTheme.CurrentAccent);

            ModernTheme.ApplyTheme(ModernTheme.CurrentTheme.GetValueOrDefault(), Accent.Orange);

            if (!string.IsNullOrEmpty(Properties.Settings.Default.CurrentUser))
                PasswordField.Password = "*********";

            UploadList.ItemsSource = AppServices.UserContent;

            SetButtonsEnabled();
            LoadUserImages();

            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            AppServices.CloseMainWindow();
        }
        
        private void PreferencesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Preferences prefs = new Preferences();
            prefs.ShowDialog();
        }

        #region Button event handlers
        private void Capture(object sender, RoutedEventArgs e)
        {
            AppServices.Uploader.CaptureScreen("screen");
        }

        private void CaptureRegion(object sender, RoutedEventArgs e)
        {
            AppServices.Uploader.CaptureScreen("region");
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.AuthKey = string.Empty;
            Properties.Settings.Default.AuthExpirationTime = 0;
            Properties.Settings.Default.Save();

            AppServices.UserContent.Clear();
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
            AppServices.CloseMainWindow();
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            AppServices.Exit();
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
                AppServices.UserContent.Add(item);
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


        private async void UploadFiles(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;

            bool? result = dialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                foreach (string fileName in dialog.FileNames)
                {
                    await AppServices.Uploader.UploadFile(fileName);
                }
            }
        }
        
        #region Right-click handlers
        private void OpenSelectedUpload(object sender, RoutedEventArgs e)
        {
            if (UploadList.SelectedIndex < 0)
                return;

            UploadedContent selectedItem = AppServices.UserContent[UploadList.SelectedIndex];
            Process.Start(string.Format("{0}/{1}", APIConfig.HostURL, selectedItem.Key));
        }

        private void CopySelectedUpload(object sender, RoutedEventArgs e)
        {
            UploadedContent selectedItem = AppServices.UserContent[UploadList.SelectedIndex];
            string link = string.Format("{0}/{1}", APIConfig.HostURL, selectedItem.Key);
            Clipboard.SetText(link);
        }

        private async void DeleteSelectedUpload(object sender, RoutedEventArgs e)
        {
            UploadedContent selectedItem = AppServices.UserContent[UploadList.SelectedIndex];

            if (await DeleteImageRequest.RequestDeletion(selectedItem.Key))
            {
                AppServices.UserContent.RemoveAt(UploadList.SelectedIndex);
            }
            else
            {
                GlobalFunctions.PlaySound(Properties.Resources.error);

                if (Properties.Settings.Default.BalloonMessages)
                    AppServices.ShowBalloonTip("Could not delete file!", "Error", 2000, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Error);
            }
        }
        #endregion

        private async void GroupBox_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                await AppServices.Uploader.UploadFile(file);
            }
        }

        private void UploadList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenSelectedUpload(sender, null);
        }

        private void UpdateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AppServices.UpdateHelper.CheckForUpdates(true);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            WindowClosed = true;
            base.OnClosing(e);
        }

        private void MinimizeToTray(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OpenDashboard(object sender, RoutedEventArgs e)
        {
            Process.Start("https://panel.shikashi.me/login");
        }

        private void UploadFromClipboard(object sender, RoutedEventArgs e)
        {

        }

        private void Options(object sender, RoutedEventArgs e)
        {
            new Preferences().Show();
        }
    }
}
