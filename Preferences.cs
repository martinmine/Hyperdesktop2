using hyperdesktop2.API;
using System;
using System.Windows.Forms;

namespace hyperdesktop2
{
    public partial class Preferences : Form
    {
        private int currentHotkeyContext = -1;

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


            comboBoxRegionalFirst.Text = EnumToStrong((ModifierKeys)Properties.Settings.Default.RegionalScreenshotHotkeyFirst);
            comboBoxWindowScreenshotFirst.Text = EnumToStrong((ModifierKeys)Properties.Settings.Default.WindowedScreenshotHotkeyFirst);
            comboBoxScreenshotFirst.Text = EnumToStrong((ModifierKeys)Properties.Settings.Default.FullScreenshotHotkeyFirst);
            comboBoxWindowScreenshotSecond.Text = EnumToStrong((ModifierKeys)Properties.Settings.Default.WindowedScreenshotHotkeySecond);
            comboBoxScreenshotSecond.Text = EnumToStrong((ModifierKeys)Properties.Settings.Default.FullScreenshotHotkeySecond);
            comboBoxRegionalSecond.Text = EnumToStrong((ModifierKeys)Properties.Settings.Default.RegionalScreenshotHotkeySecond);
            comboBoxWindowScreenshotThird.Text = EnumToStrong((ModifierKeys)Properties.Settings.Default.WindowedScreenshotHotkeyThird);
            comboBoxRegionalThird.Text = EnumToStrong((ModifierKeys)Properties.Settings.Default.RegionalScreenshotHotkeyThird);
            comboBoxScreenshotThird.Text = EnumToStrong((ModifierKeys)Properties.Settings.Default.FullScreenshotHotkeyThird);

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

            tabControl1.Selecting += tabControl1_Selecting;

            buttonScreenshotKey.Text = ((Keys)Properties.Settings.Default.FullScreenshotHotkeyValue).ToString();
            buttonRegionalValue.Text = ((Keys)Properties.Settings.Default.RegionalScreenshotHotkeyValue).ToString();
            buttonWindowValue.Text = ((Keys)Properties.Settings.Default.WindowedScreenshotHotkeyValue).ToString();
        }

        void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            currentHotkeyContext = -1;
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

            Settings.CopyLinksToClipboard = checkCopyLinks.Checked;
            Settings.SoundEffects = checkSoundEffects.Checked;
            Settings.ShowCursor = checkShowCursor.Checked;
            Settings.BalloonMessages = checkBalloon.Checked;
            Settings.LaunchBrowser = checkLaunchBrowser.Checked;
            Settings.EdiScreenshot = checkEditScreenshot.Checked;

            Properties.Settings.Default.RegionalScreenshotHotkeyFirst = (int)ParseValue(comboBoxRegionalFirst.Text);
            Properties.Settings.Default.WindowedScreenshotHotkeyFirst = (int)ParseValue(comboBoxWindowScreenshotFirst.Text);
            Properties.Settings.Default.FullScreenshotHotkeyFirst = (int)ParseValue(comboBoxScreenshotFirst.Text);
            Properties.Settings.Default.WindowedScreenshotHotkeySecond = (int)ParseValue(comboBoxWindowScreenshotSecond.Text);
            Properties.Settings.Default.FullScreenshotHotkeySecond = (int)ParseValue(comboBoxScreenshotSecond.Text);
            Properties.Settings.Default.RegionalScreenshotHotkeySecond = (int)ParseValue(comboBoxRegionalSecond.Text);
            Properties.Settings.Default.WindowedScreenshotHotkeyThird = (int)ParseValue(comboBoxWindowScreenshotThird.Text);
            Properties.Settings.Default.RegionalScreenshotHotkeyThird = (int)ParseValue(comboBoxRegionalThird.Text);
            Properties.Settings.Default.FullScreenshotHotkeyThird = (int)ParseValue(comboBoxScreenshotThird.Text);

            Properties.Settings.Default.Save();

            HotkeyManager.GetInstance().UnregisterHotkeys();
            HotkeyManager.GetInstance().RegisterHotkeys();

            Settings.WriteSettings();
            GlobalFunctions.CheckRunAtStartup(checkRunAtStartup.Checked);
            Dispose();
        }

        private ModifierKeys ParseValue(string value)
        {
            switch (value)
            {
                case "Alt":
                    return hyperdesktop2.ModifierKeys.Alt;
                case "Ctrl":
                    return hyperdesktop2.ModifierKeys.Control;
                case "Shift":
                    return hyperdesktop2.ModifierKeys.Shift;
                case "Win":
                    return hyperdesktop2.ModifierKeys.Win;
                default:
                    return hyperdesktop2.ModifierKeys.None;
            }
        }

        private string EnumToStrong(ModifierKeys keys)
        {
            switch (keys)
            {
                case hyperdesktop2.ModifierKeys.Alt:
                    return "Alt";
                case hyperdesktop2.ModifierKeys.Control:
                    return "Ctrl";
                case hyperdesktop2.ModifierKeys.Shift:
                    return "Shift";
                case hyperdesktop2.ModifierKeys.Win:
                    return "Win";
                default:
                    return string.Empty;
            }
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


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys key)
        {
            switch (currentHotkeyContext)
            {
                case 1:
                    {
                        Properties.Settings.Default.FullScreenshotHotkeyValue = (int)key;
                        buttonScreenshotKey.Text = key.ToString();
                        return true;
                    }
                case 2:
                    {
                        Properties.Settings.Default.RegionalScreenshotHotkeyValue = (int)key;
                        buttonRegionalValue.Text = key.ToString();
                        return true;
                    }
                case 3:
                    {
                        Properties.Settings.Default.WindowedScreenshotHotkeyValue = (int)key;
                        buttonWindowValue.Text = key.ToString();
                        return true;
                    }
            }

            return base.ProcessCmdKey(ref msg, key);
        }

        private void buttonScreenshotKey_Click(object sender, EventArgs e)
        {
            currentHotkeyContext = 1;
        }

        private void buttonRegionalValue_Click(object sender, EventArgs e)
        {
            currentHotkeyContext = 2;
        }

        private void buttonWindowValue_Click(object sender, EventArgs e)
        {
            currentHotkeyContext = 3;
        }
    }
}
