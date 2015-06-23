using hyperdesktop2.API;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace hyperdesktop2
{

    public partial class Main : Form, IUploadStatusListener
    {
        private Hotkeys hook;
        private bool snipperOpen;

        #region Main Form
        public Main()
        {
            InitializeComponent();
            SetButtonsEnabled();

            // Delete older executable on update
            try
            {
                if (Convert.ToInt32(Settings.Read("hyperdesktop2", "build")) < Settings.BuildVersion)
                {
                    File.Delete(Settings.ExePath);
                    Settings.Write("hyperdesktop2", "build", Settings.BuildVersion.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't delete old hyperdesktop2 executable.");
                Console.WriteLine(ex.Message);
            }

            GlobalFunctions.CreateAppDataFolder();
            GlobalFunctions.InstallApplicationData();

            WebClient web_client = new WebClient();
            int build = Convert.ToInt32(web_client.DownloadString(Settings.BuildUrl));

            // Confirm if user wants to add to system startup
            // on first run
            if (!File.Exists(Settings.IniPath))
            {
                DialogResult result = MessageBox.Show(
                    "Do you want to run Hyperdesktop2 at Windows startup?",
                    "First time run",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1
                );

                if (result == DialogResult.Yes)
                    GlobalFunctions.CheckRunAtStartup(true);
            }
            // Update notification
            else if (build > Settings.BuildVersion)
            {
                DialogResult result = MessageBox.Show(
                    "A new version of Hyperdesktop2 has been released. Would you like to download it?",
                    "Update available",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1
                );

                if (result == DialogResult.Yes)
                {
                    Process.Start(Settings.ReleaseUrl);
                    Process.GetCurrentProcess().Kill();
                }
            }

            RegisterHotkeys();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Settings.ReadSettings();
            tray_icon.Visible = true;

            ScreenBounds.Load();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            InverseTrayOption(sender, e);
            e.Cancel = true;
        }
        #endregion

        #region Tray Icon
        private void BalloonTip(string text, string title, Int32 duration, ToolTipIcon icon = ToolTipIcon.Info, string link = null)
        {
            tray_icon.BalloonTipText = text;
            tray_icon.BalloonTipTitle = title;
            tray_icon.BalloonTipIcon = icon;

            if (link != null)
            {
                tray_icon.BalloonTipClicked += (sender, e) =>
                {
                    System.Diagnostics.Process.Start(link);
                };
            }
            
            tray_icon.ShowBalloonTip(duration);
        }

        private void InverseTrayOption(object sender, EventArgs e)
        {
            minimizeToTrayToolStripMenuItem.Text = (minimizeToTrayToolStripMenuItem.Text == "Open Window") ? "Minimize to Tray" : "Open Window";

            ShowInTaskbar = !ShowInTaskbar;
            Opacity = Opacity < 1 ? 100 : 0;
        }
        #endregion

        #region Drag and Drop
        private void OnDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Move : DragDropEffects.None;
        }
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                WorkImage(new Bitmap(Image.FromFile(file)));
            }
        }
        #endregion

        #region Hotkeys
        public void RegisterHotkeys()
        {
            hook = new Hotkeys();
            hook.KeyPressed += OnHotkeyPressed;

            try
            {
                hook.RegisterHotKey(hyperdesktop2.ModifierKeys.Control | hyperdesktop2.ModifierKeys.Shift, Keys.D3);
                hook.RegisterHotKey(hyperdesktop2.ModifierKeys.Control | hyperdesktop2.ModifierKeys.Shift, Keys.D4);
                hook.RegisterHotKey(hyperdesktop2.ModifierKeys.Control | hyperdesktop2.ModifierKeys.Shift, Keys.D5);
            }
            catch
            {
                MessageBox.Show("Couldn't register hotkeys. Perhaps they are already in use or try running as an Administrator.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnHotkeyPressed(object sender, KeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case Keys.D3:
                    ScreenCapture("screen");
                    break;

                case Keys.D4:
                    ScreenCapture("region");
                    break;

                case Keys.D5:
                    ScreenCapture("window");
                    break;
            }
        }
        #endregion

        #region Image

        private Bitmap EditScreenshot(Bitmap bmp)
        {
            if (!Settings.EdiScreenshot)
                return null;

            Edit edit = new Edit(bmp);
            edit.ShowDialog();

            return edit.Result;
        }

        private void ScreenCapture(string type)
        {
            Bitmap bmp = null;

            switch (type)
            {
                case "screen":
                    bmp = Screen_Capture.screen(Settings.ShowCursor);
                    break;

                case "window":
                    bmp = Screen_Capture.window(Settings.ShowCursor);
                    break;

                default:
                    if (snipperOpen)
                        return;

                    snipperOpen = true;
                    var rect = Snipper.GetRegion();

                    if (rect == new Rectangle(0, 0, 0, 0))
                        return;

                    bmp = Screen_Capture.region(rect);
                    snipperOpen = false;
                    break;
            }
            WorkImage(bmp, true);
        }

        private async void WorkImage(Bitmap bmp, bool edit = false)
        {
            GlobalFunctions.PlaySound("capture.wav");

            if (edit)
                bmp = EditScreenshot(bmp);

            if (bmp == null)
                return;

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

        private void HandleFileUploadResult(FileUploadResult result)
        {
            switch (result)
            {
                case FileUploadResult.Failed:
                    GlobalFunctions.PlaySound("error.wav");
                    BalloonTip("Error uploading file!", "Error", 2000, ToolTipIcon.Error);
                    break;

                case FileUploadResult.InvalidCredentials:
                    GlobalFunctions.PlaySound("error.wav");
                    BalloonTip("Your credentials were invalid, please sign in again", "Error", 2000, ToolTipIcon.Error);
                    break;

                case FileUploadResult.NotAuthorized:
                    GlobalFunctions.PlaySound("error.wav");
                    BalloonTip("You need to sign in before uploading", "Error", 2000, ToolTipIcon.Error);
                    break;

                case FileUploadResult.FileTooLarge:
                    GlobalFunctions.PlaySound("error.wav");
                    BalloonTip("This file was too large to be uploaded", "Error", 2000, ToolTipIcon.Error);
                    break;
            }
        }
        #endregion

        #region Buttons
        private async void BtnBrowseClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                await UploadFile(dialog.FileName);
            }
        }

        private async Task UploadFile(string path)
        {
            string extension = Path.GetExtension(path);
            FileUpload upload = new FileUpload(this);
            Stream fileStream = File.OpenRead(path);
            string contentType = MimeMapping.GetMimeMapping(path);

            FileUploadResult result = await upload.UploadFile(File.OpenRead(path), path, contentType);
            HandleFileUploadResult(result);
        }

        private void BtnCaptureClick(object sender, EventArgs e) { ScreenCapture("screen"); }
        private void BtnWindowClick() { ScreenCapture("window"); }
        private void BtnCaptureRegionClick(object sender, EventArgs e) { ScreenCapture("region"); }
        #endregion

        #region Main Menu
        private void PreferencesToolStripMenuItemClick(object sender, EventArgs e)
        {
            new Preferences().ShowDialog();
        }
        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
        private void RegisterHotkeysToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            RegisterHotkeys();
        }
        #endregion

        #region Image Links Menu
        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (listImageLinks.SelectedItems.Count > 0)
                Process.Start(listImageLinks.SelectedItems[0].Text);
        }
        private void CopyToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (listImageLinks.SelectedItems.Count > 0)
                Clipboard.SetText(listImageLinks.SelectedItems[0].Text);
        }
        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (listImageLinks.SelectedItems.Count <= 0)
                return;

                // TODO

            /*if (Imgur.delete(listImageLinks.SelectedItems[0].SubItems[1].Text))
                listImageLinks.SelectedItems[0].Remove();
            else
            {
                GlobalFunctions.PlaySound("error.wav");

                if (Settings.BalloonMessages)
                    BalloonTip("Could not delete file!", "Error", 2000, ToolTipIcon.Error);
            }*/
        }
        #endregion

        private delegate void OnProgressCallback(long a, long b);
        private DateTime lastUpdate;
        

        public void OnProgress(long uploaded, long total)
        {
            if (progress.InvokeRequired)
            {
                OnProgressCallback callback = new OnProgressCallback(OnProgress);
                this.Invoke(callback, new object[] {uploaded, total});
                return;
            }

            if (lastUpdate != null && (DateTime.Now - lastUpdate).Milliseconds < 100)
                return;
            lastUpdate = DateTime.Now;

            int percent = (int)((uploaded / (double)total) * 100);
            groupUploadProgress.Text = string.Format("Upload Progress - {0}% ({1}kb/{2}kb)", percent, uploaded / 1024, total / 1024);
            progress.Value = percent;
        }

        #region Progress Bar
        private void UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            try
            {
            }
            catch
            {
                // below .NET 4.0, sometimes it throws an absurd
                // number into the ProgressPercentage
            }
        }

        public void ContentUplaoded(UploadedContent content)
        {
            groupUploadProgress.Text = "Upload Progress";
            progress.Value = 0;

            string delete_hash = "";
            string link = string.Format("{0}/{1}", APIConfig.BaseURL, content.Key);

            listImageLinks.Items.Add(
                new ListViewItem(new string[] { link, delete_hash })
            );

            listImageLinks.Items[listImageLinks.Items.Count - 1].EnsureVisible();

            if (Settings.CopyLinksToClipboard)
                Clipboard.SetText(link);

            if (Settings.BalloonMessages)
                BalloonTip("Link copied to clipboard:" + Environment.NewLine + link, "Upload Completed!", 2000, ToolTipIcon.Info, link);

            GlobalFunctions.PlaySound("success.wav");
        }

        private void UploadProgressChanged(object sender, UploadValuesCompletedEventArgs e)
        {
        }
        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        private async void loginBtn_Click(object sender, EventArgs e)
        {
            LoginProvider loginProvider = new LoginProvider(emailField.Text, passwordField.Text);
            LoginResult loginResult = await loginProvider.PerformLogin();

            switch (loginResult)
            {
                case LoginResult.InvalidCredentials:
                    MessageBox.Show("Unknown username/password", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case LoginResult.UnknownError:
                    MessageBox.Show("Unable to connect to Shikashi", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case LoginResult.Success:
                    SetButtonsEnabled();
                    MessageBox.Show("Login successfull", "Login success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            loginBtn.Enabled = true;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AuthKey = string.Empty;
            Properties.Settings.Default.AuthExpirationTime = 0;
            Properties.Settings.Default.Save();

            SetButtonsEnabled();
        }

        private void SetButtonsEnabled()
        {
            bool loggedIn = (AuthKey.LoadKey() != null);

            emailField.Enabled = !loggedIn;
            passwordField.Enabled = !loggedIn;
            loginBtn.Enabled = !loggedIn;
            logoutBtn.Enabled = loggedIn;
        }

        private async void uploadFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                Image image = Clipboard.GetImage();
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
    }
}
