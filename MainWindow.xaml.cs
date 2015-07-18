using Microsoft.Win32;
using ModernWPF;
using ModernWPF.Controls;
using Shikashi.API;
using Shikashi.Screenshotting;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Shikashi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IHotkeyListener, IUploadStatusListener
    {
        private bool snipperOpen;
        private ObservableCollection<UploadedContent> userContent = new ObservableCollection<UploadedContent>();

        public MainWindow()
        {
            InitializeComponent();

            if (Properties.Settings.Default.UseDarkTheme)
                ModernTheme.ApplyTheme(ModernTheme.Theme.Dark, ModernTheme.CurrentAccent);

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

            HotkeyManager.GetInstance().SetListener(this);
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
            CaptureScreen("screen");
        }

        private void CaptureRegion(object sender, RoutedEventArgs e)
        {
            CaptureScreen("region");
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
                    MessageBox.Show("Login successfull", "Login success", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        private void HideWindow(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
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
            Array.Reverse(items, 0, items.Length);

            foreach (UploadedContent item in items) 
            {
                userContent.Add(item);
            }
        }


        #region Image processing

        private Bitmap EditScreenshot(Bitmap bmp)
        {
            if (!Properties.Settings.Default.EditScreenshot)
                return null;

            Edit edit = new Edit(bmp);
            edit.ShowDialog();

            return edit.Result;
        }

        private void CaptureScreen(string type)
        {
            Bitmap bmp = null;

            switch (type)
            {
                case "screen":
                    bmp = ScreenCapture.CaptureScreen(Properties.Settings.Default.ShowCursor);
                    break;

                case "window":
                    bmp = ScreenCapture.Window(Properties.Settings.Default.ShowCursor);
                    break;

                default:
                    if (snipperOpen)
                        return;

                    snipperOpen = true;

                    try
                    {
                         System.Drawing.Rectangle rect = Snipper.GetRegion();

                         if (rect == new System.Drawing.Rectangle(0, 0, 0, 0))
                             return;

                         bmp = ScreenCapture.CaptureRegion(rect);
                    }
                    finally
                    {
                        snipperOpen = false;
                    }

                    break;
            }
            WorkImage(bmp, true);
        }

        private async void WorkImage(Bitmap bmp, bool edit = false)
        {
            try
            {
                StartAnimation();
                GlobalFunctions.PlaySound(Properties.Resources.capture);

                if (Properties.Settings.Default.EditScreenshot && edit)
                    bmp = EditScreenshot(bmp);

                if (bmp == null)
                {
                    StopAnimation();
                    return;
                }


                using (MemoryStream memoryStream = new MemoryStream())
                {
                    bmp.Save(memoryStream, ImageFormat.Png);
                    FileUpload upload = new FileUpload(this);
                    string nameSuffix = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
                    using (StreamReader reader = new StreamReader(memoryStream))
                    {
                        memoryStream.Position = 0;
                        reader.DiscardBufferedData();

                        FileUploadResult result = await upload.UploadFile(memoryStream, string.Format("Screenshot {0}.png", nameSuffix), "image/png");
                        HandleFileUploadResult(result);
                    }
                }
            }
            finally
            {
                if (bmp != null)
                    bmp.Dispose();
                GC.Collect();
            }
        }

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

            StopAnimation();
        }
        #endregion

        private void BalloonTip(string text, string title, int duration, Hardcodet.Wpf.TaskbarNotification.BalloonIcon icon = Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Info, string link = null)
        {
            ApplicationTrayIcon.ShowBalloonTip(title, text, icon);

            if (!string.IsNullOrEmpty(link))
            {
                ApplicationTrayIcon.TrayBalloonTipClicked += (sender, e) =>
                {
                    Process.Start(link);
                };
            }
        }

        private Thread animationThread;
        private bool animateIcon;

        private void StartAnimation()
        {
            animateIcon = false;

            if (animationThread != null && animationThread.IsAlive)
                animationThread.Abort();

            animateIcon = true;
            animationThread = new Thread(() =>
            {
                try
                {
                    int iconNum = 0;

                    while (animateIcon)
                    {
                        iconNum = (iconNum++ % 19) + 1;
                        SetTaskbarIcon("pack://application:,,,/Shikashi;component/Icons/" + iconNum + ".ico");

                        Thread.Sleep(260);
                    }
                }
                catch (ThreadInterruptedException) { }
            });

            animationThread.Start();
        }

        private void StopAnimation()
        {
            new Thread(() =>
            {
                animateIcon = false;
                animationThread.Join();
                SetTaskbarIcon("pack://application:,,,/Shikashi;component/icon.ico");
            }).Start();
        }

        private void SetTaskbarIcon(string imageUri)
        {
            Dispatcher.Invoke(() => {
                this.Icon = new BitmapImage(new Uri(imageUri));
            });
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

        public void OnKeyPress(Key key)
        {
            Debug.WriteLine("Keypress: " + key.ToString());
            if (key == (Key)Properties.Settings.Default.WindowedScreenshotHotkeyValue)
            {
                CaptureScreen("window");
            }
            else if (key == (Key)Properties.Settings.Default.RegionalScreenshotHotkeyValue)
            {
                CaptureScreen("region");
            }
            else if (key == (Key)Properties.Settings.Default.FullScreenshotHotkeyValue)
            {
                CaptureScreen("screen");
            }
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
                StartAnimation();
                System.Drawing.Image image = System.Windows.Forms.Clipboard.GetImage();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, ImageFormat.Png);

                    FileUpload upload = new FileUpload(this);
                    string nameSuffix = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
                    using (StreamReader reader = new StreamReader(memoryStream))
                    {
                        memoryStream.Position = 0;
                        reader.DiscardBufferedData();

                        FileUploadResult result = await upload.UploadFile(memoryStream, string.Format("Copied image {0}.png", nameSuffix), "image/png");
                        HandleFileUploadResult(result);
                    }
                }
            }
            else if (Clipboard.ContainsFileDropList())
            {
                foreach (string path in Clipboard.GetFileDropList())
                {
                    await UploadFile(path);
                }
            }
        }

        private async Task UploadFile(string path)
        {
            StartAnimation();
            GlobalFunctions.PlaySound(Properties.Resources.capture);
            string extension = System.IO.Path.GetExtension(path);
            FileUpload upload = new FileUpload(this);
            Stream fileStream = File.OpenRead(path);
            string mimeType = MimeMapping.Instance.GetMimeType(extension);

            FileUploadResult result = await upload.UploadFile(File.OpenRead(path), System.IO.Path.GetFileName(path), mimeType);
            HandleFileUploadResult(result);
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
                    await UploadFile(fileName);
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
            {
                Hide();
            }
        }

        #region Right-click handlers
        private void OpenSelectedUpload(object sender, RoutedEventArgs e)
        {
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
    }
}
