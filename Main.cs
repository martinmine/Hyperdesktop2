using System;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Specialized;

namespace hyperdesktop2
{

    public partial class Main : Form
    {
        private Hotkeys hook;
        private bool snipperOpen;

        #region Main Form
        public Main()
        {
            InitializeComponent();

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
            Imgur.WebClient.UploadProgressChanged += UploadProgressChanged;
            Imgur.WebClient.UploadValuesCompleted += UploadProgressChanged;

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
        private void BalloonTip(string text, string title, Int32 duration, ToolTipIcon icon = ToolTipIcon.Info)
        {
            tray_icon.BalloonTipText = text;
            tray_icon.BalloonTipTitle = title;
            tray_icon.BalloonTipIcon = icon;
            tray_icon.ShowBalloonTip(duration);
        }

        private void TrayIconBalloonTipClicked(object sender, System.EventArgs e)
        {
            Process.Start(tray_icon.BalloonTipText);
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

        void SaveScreenshot(Bitmap bmp, string name = null)
        {
            if (!Settings.SaveScreenshots)
                return;

            if (name == null)
                name = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");

            try
            {
                bmp.Save(string.Format("{0}/{1}.{2}", Settings.SaveFolder, name, Settings.SaveFormat,
                    GlobalFunctions.ExtensionToImageFormat(Settings.SaveFormat)));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot save image.");
                Console.WriteLine(ex.Message);
            }
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

        private void WorkImage(Bitmap bmp, bool edit = false)
        {
            GlobalFunctions.PlaySound("capture.wav");

            if (edit)
                bmp = EditScreenshot(bmp);

            if (bmp == null)
                return;

            if (Settings.UploadMethod == "imgur")
                if (!Imgur.upload(bmp))
                {
                    GlobalFunctions.PlaySound("error.wav");

                    if (Settings.BalloonMessages)
                        BalloonTip("Error uploading file!", "Error", 2000, ToolTipIcon.Error);
                }

            SaveScreenshot(bmp);
        }
        #endregion

        #region Buttons
        private void BtnBrowseClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                WorkImage(new Bitmap(Image.FromFile(dialog.FileName)));
            }
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

            if (Imgur.delete(listImageLinks.SelectedItems[0].SubItems[1].Text))
                listImageLinks.SelectedItems[0].Remove();
            else
            {
                GlobalFunctions.PlaySound("error.wav");

                if (Settings.BalloonMessages)
                    BalloonTip("Could not delete file!", "Error", 2000, ToolTipIcon.Error);
            }
        }
        #endregion

        #region Progress Bar
        private void UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            try
            {
                int percent = (int)((e.BytesSent / e.TotalBytesToSend) * 100);
                groupUploadProgress.Text = string.Format("Upload Progress - {0}% ({1}kb/{2}kb)", percent, e.BytesSent / 1024, e.TotalBytesToSend / 1024);
                progress.Value = percent;
            }
            catch
            {
                // below .NET 4.0, sometimes it throws an absurd
                // number into the ProgressPercentage
            }
        }
        private void UploadProgressChanged(object sender, UploadValuesCompletedEventArgs e)
        {
            groupUploadProgress.Text = "Upload Progress";
            progress.Value = 0;

            string response = Encoding.UTF8.GetString(e.Result);

            string delete_hash = GlobalFunctions.get_text_inbetween(response, "deletehash\":\"", "\",\"name\"").Replace("\\", "");
            string link = GlobalFunctions.get_text_inbetween(response, "link\":\"", "\"}").Replace("\\", "");

            listImageLinks.Items.Add(
                new ListViewItem(new string[] { link, delete_hash })
            );

            listImageLinks.Items[listImageLinks.Items.Count - 1].EnsureVisible();

            if (Settings.CopyLinksToClipboard)
                Clipboard.SetText(link);

            if (Settings.BalloonMessages)
                BalloonTip(link, "Upload Complete!", 2000);

            GlobalFunctions.PlaySound("success.wav");
        }
        #endregion
    }
}
