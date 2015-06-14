using System;
using System.Windows.Forms;

namespace hyperdesktop2
{
    public partial class Preferences : Form
    {

        public Preferences()
        {
            InitializeComponent();
        }

        void Frm_PreferencesLoad(object sender, EventArgs e)
        {
            checkSaveScreenshots.Checked = Settings.SaveScreenshots;
            txtSaveFolder.Text = Settings.SaveFolder;
            dropSaveFormat.Text = Settings.SaveFormat;
            dropSaveQuality.Text = Settings.SaveQuality.ToString();

            dropUploadMethod.Text = Settings.UploadMethod;
            dropUploadFormat.Text = Settings.UploadFormat;

            checkRunAtStartup.Checked = GlobalFunctions.startupRegistryKey.GetValue("Hyperdesktop2") != null;
            checkCopyLinks.Checked = Settings.CopyLinksToClipboard;
            checkSoundEffects.Checked = Settings.SoundEffects;
            checkShowCursor.Checked = Settings.ShowCursor;
            checkBalloon.Checked = Settings.BalloonMessages;
            checkLaunchBrowser.Checked = Settings.LaunchBrowser;
            checkEditScreenshot.Checked = Settings.EdiScreenshot;

            numericTop.Minimum = -50000;
            numericLeft.Minimum = -50000;
            numericWidth.Minimum = -50000;
            numericHeight.Minimum = -50000;

            try
            {
                string[] screen_res = Settings.ScreenResolution.Split(',');
                numericLeft.Value = Convert.ToDecimal(screen_res[0]);
                numericTop.Value = Convert.ToDecimal(screen_res[1]);
                numericWidth.Value = Convert.ToDecimal(screen_res[2]);
                numericHeight.Value = Convert.ToDecimal(screen_res[3]);
            }
            catch
            {
                btnResetScreen.PerformClick();
            }
        }

        #region Save & Cancel
        void BtnSaveClick(object sender, EventArgs e)
        {
            // Screen resolution
            Settings.ScreenResolution = Settings.ScreenResolution = string.Format(
                "{0},{1},{2},{3}",
                numericLeft.Value,
                numericTop.Value,
                numericWidth.Value,
                numericHeight.Value
            );

            ScreenBounds.Load();

            Settings.SaveScreenshots = checkSaveScreenshots.Checked;
            Settings.SaveFolder = txtSaveFolder.Text;
            Settings.SaveFormat = dropSaveFormat.Text;
            Settings.SaveQuality = Convert.ToInt16(dropSaveQuality.Text);

            Settings.UploadMethod = dropUploadMethod.Text;
            Settings.UploadFormat = dropUploadFormat.Text;

            Settings.CopyLinksToClipboard = checkCopyLinks.Checked;
            Settings.SoundEffects = checkSoundEffects.Checked;
            Settings.ShowCursor = checkShowCursor.Checked;
            Settings.BalloonMessages = checkBalloon.Checked;
            Settings.LaunchBrowser = checkLaunchBrowser.Checked;
            Settings.EdiScreenshot = checkEditScreenshot.Checked;

            Settings.WriteSettings();
            GlobalFunctions.CheckRunAtStartup(checkRunAtStartup.Checked);
            Dispose();
        }
        void BtnCancelClick(object sender, EventArgs e)
        {
            Dispose();
        }
        #endregion

        #region General
        void CheckSaveScreenshotsCheckedChanged(object sender, EventArgs e)
        {
            txtSaveFolder.Enabled = checkSaveScreenshots.Checked;
            btnBrowseSaveFolder.Enabled = checkSaveScreenshots.Checked;
            dropSaveFormat.Enabled = checkSaveScreenshots.Checked;
            dropSaveQuality.Enabled = checkSaveScreenshots.Checked;
        }
        void BtnBrowseSaveFolderClick(object sender, EventArgs e)
        {
            FolderBrowserDialog browseFolder = new FolderBrowserDialog();
            if (browseFolder.ShowDialog() == DialogResult.OK)
                txtSaveFolder.Text = browseFolder.SelectedPath;
        }
        void BtnResetScreenClick(object sender, System.EventArgs e)
        {
            string[] screen_res = ScreenBounds.Reset().Split(',');
            numericLeft.Value = Convert.ToDecimal(screen_res[0]);
            numericTop.Value = Convert.ToDecimal(screen_res[1]);
            numericWidth.Value = Convert.ToDecimal(screen_res[2]);
            numericHeight.Value = Convert.ToDecimal(screen_res[3]);
        }
        #endregion
    }
}
