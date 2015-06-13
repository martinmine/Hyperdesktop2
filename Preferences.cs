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
			check_save_screenshots.Checked 		= Settings.SaveScreenshots;
			txt_save_folder.Text 				= Settings.SaveFolder;
			drop_save_format.Text 				= Settings.SaveFormat;
			drop_save_quality.Text 				= Settings.SaveQuality.ToString();
			
			drop_upload_method.Text 			= Settings.UploadMethod;
			drop_upload_format.Text 			= Settings.UploadFormat;
			
			check_run_at_startup.Checked 		= GlobalFunctions.startupRegistryKey.GetValue("Hyperdesktop2") != null;
			check_copy_links.Checked 			= Settings.CopyLinksToClipboard;
			check_sound_effects.Checked			= Settings.SoundEffects;
			check_show_cursor.Checked			= Settings.ShowCursor;
			check_balloon.Checked 				= Settings.BalloonMessages;
			check_launch_browser.Checked 		= Settings.LaunchBrowser;
			check_edit_screenshot.Checked 		= Settings.EdiScreenshot;
		
			numeric_top.Minimum = -50000;
			numeric_left.Minimum = -50000;
			numeric_width.Minimum = -50000;
			numeric_height.Minimum = -50000;
			
			try {
                String[] screen_res = Settings.ScreenResolution.Split(',');
				numeric_left.Value = Convert.ToDecimal(screen_res[0]);
				numeric_top.Value = Convert.ToDecimal(screen_res[1]);
				numeric_width.Value = Convert.ToDecimal(screen_res[2]);
				numeric_height.Value = Convert.ToDecimal(screen_res[3]);
			} catch {
				btn_reset_screen.PerformClick();
			}
		}
		
		#region Save & Cancel
		void Btn_saveClick(object sender, EventArgs e)
		{
			// Screen resolution
			Settings.ScreenResolution 				= Settings.ScreenResolution = String.Format(
				"{0},{1},{2},{3}",
				numeric_left.Value,
				numeric_top.Value,
				numeric_width.Value,
				numeric_height.Value
			);

            ScreenBounds.Load();
			
			Settings.SaveScreenshots 			= check_save_screenshots.Checked;
			Settings.SaveFolder 				= txt_save_folder.Text;
			Settings.SaveFormat 				= drop_save_format.Text;
			Settings.SaveQuality 				= Convert.ToInt16(drop_save_quality.Text);
			
			Settings.UploadMethod 				= drop_upload_method.Text;
			Settings.UploadFormat 				= drop_upload_format.Text;
			
			Settings.CopyLinksToClipboard 	= check_copy_links.Checked;
			Settings.SoundEffects 				= check_sound_effects.Checked;
			Settings.ShowCursor 				= check_show_cursor.Checked;
			Settings.BalloonMessages 			= check_balloon.Checked;
			Settings.LaunchBrowser 			= check_launch_browser.Checked;
			Settings.EdiScreenshot 			= check_edit_screenshot.Checked;
			
			Settings.WriteSettings();
			GlobalFunctions.CheckRunAtStartup(check_run_at_startup.Checked);
			Dispose();
		}
		void Btn_cancelClick(object sender, EventArgs e)
		{
			Dispose();
		}
		#endregion
		
		#region General
		void Check_save_screenshotsCheckedChanged(object sender, EventArgs e)
		{
			txt_save_folder.Enabled 		= check_save_screenshots.Checked;
			btn_browse_save_folder.Enabled 	= check_save_screenshots.Checked;
			drop_save_format.Enabled 		= check_save_screenshots.Checked;
			drop_save_quality.Enabled 		= check_save_screenshots.Checked;
		}
		void Btn_browse_save_folderClick(object sender, EventArgs e)
		{
			var browse_folder = new FolderBrowserDialog();
			if (browse_folder.ShowDialog() == DialogResult.OK)
			    txt_save_folder.Text = browse_folder.SelectedPath;
		}
		void Btn_reset_screenClick(object sender, System.EventArgs e)
		{
            String[] screen_res = ScreenBounds.Reset().Split(',');
            numeric_left.Value = Convert.ToDecimal(screen_res[0]);
			numeric_top.Value = Convert.ToDecimal(screen_res[1]);
			numeric_width.Value = Convert.ToDecimal(screen_res[2]);
			numeric_height.Value = Convert.ToDecimal(screen_res[3]);
		}
		#endregion
	}
}
