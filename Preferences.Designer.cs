/*
 * Created by SharpDevelop.
 * User: Mike
 * Date: 5/21/2014
 * Time: 6:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace hyperdesktop2
{
	partial class Preferences
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.tab_screens = new System.Windows.Forms.TabPage();
            this.label_screen_x = new System.Windows.Forms.Label();
            this.numericTop = new System.Windows.Forms.NumericUpDown();
            this.label_screen_y = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericLeft = new System.Windows.Forms.NumericUpDown();
            this.numericWidth = new System.Windows.Forms.NumericUpDown();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.btnResetScreen = new System.Windows.Forms.Button();
            this.tab_hotkeys = new System.Windows.Forms.TabPage();
            this.label_hotkeys_instructions = new System.Windows.Forms.Label();
            this.check_screenshot_ctrl = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label_screenshot = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label_region_screenshot = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.label_window_screenshot = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tab_behavior = new System.Windows.Forms.TabPage();
            this.checkRunAtStartup = new System.Windows.Forms.CheckBox();
            this.checkCopyLinks = new System.Windows.Forms.CheckBox();
            this.checkSoundEffects = new System.Windows.Forms.CheckBox();
            this.checkBalloon = new System.Windows.Forms.CheckBox();
            this.checkLaunchBrowser = new System.Windows.Forms.CheckBox();
            this.checkEditScreenshot = new System.Windows.Forms.CheckBox();
            this.checkShowCursor = new System.Windows.Forms.CheckBox();
            this.tab_general = new System.Windows.Forms.TabPage();
            this.checkSaveScreenshots = new System.Windows.Forms.CheckBox();
            this.txtSaveFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseSaveFolder = new System.Windows.Forms.Button();
            this.label_save_format = new System.Windows.Forms.Label();
            this.dropSaveFormat = new System.Windows.Forms.ComboBox();
            this.label_save_quality = new System.Windows.Forms.Label();
            this.dropSaveQuality = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_screens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            this.tab_hotkeys.SuspendLayout();
            this.tab_behavior.SuspendLayout();
            this.tab_general.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_save.Location = new System.Drawing.Point(191, 213);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Okay";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_cancel.Location = new System.Drawing.Point(273, 213);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // tab_screens
            // 
            this.tab_screens.Controls.Add(this.btnResetScreen);
            this.tab_screens.Controls.Add(this.numericHeight);
            this.tab_screens.Controls.Add(this.numericWidth);
            this.tab_screens.Controls.Add(this.numericLeft);
            this.tab_screens.Controls.Add(this.label3);
            this.tab_screens.Controls.Add(this.label2);
            this.tab_screens.Controls.Add(this.label_screen_y);
            this.tab_screens.Controls.Add(this.numericTop);
            this.tab_screens.Controls.Add(this.label_screen_x);
            this.tab_screens.Location = new System.Drawing.Point(4, 22);
            this.tab_screens.Name = "tab_screens";
            this.tab_screens.Padding = new System.Windows.Forms.Padding(3);
            this.tab_screens.Size = new System.Drawing.Size(344, 185);
            this.tab_screens.TabIndex = 4;
            this.tab_screens.Text = "Screen";
            this.tab_screens.UseVisualStyleBackColor = true;
            // 
            // label_screen_x
            // 
            this.label_screen_x.Location = new System.Drawing.Point(6, 28);
            this.label_screen_x.Name = "label_screen_x";
            this.label_screen_x.Size = new System.Drawing.Size(45, 17);
            this.label_screen_x.TabIndex = 2;
            this.label_screen_x.Text = "Top:";
            this.label_screen_x.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericTop
            // 
            this.numericTop.Location = new System.Drawing.Point(51, 28);
            this.numericTop.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericTop.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this.numericTop.Name = "numericTop";
            this.numericTop.Size = new System.Drawing.Size(120, 20);
            this.numericTop.TabIndex = 3;
            this.numericTop.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // label_screen_y
            // 
            this.label_screen_y.Location = new System.Drawing.Point(6, 7);
            this.label_screen_y.Name = "label_screen_y";
            this.label_screen_y.Size = new System.Drawing.Size(45, 17);
            this.label_screen_y.TabIndex = 4;
            this.label_screen_y.Text = "Left:";
            this.label_screen_y.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Width:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Height:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericLeft
            // 
            this.numericLeft.Location = new System.Drawing.Point(51, 7);
            this.numericLeft.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericLeft.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this.numericLeft.Name = "numericLeft";
            this.numericLeft.Size = new System.Drawing.Size(120, 20);
            this.numericLeft.TabIndex = 7;
            this.numericLeft.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // numericWidth
            // 
            this.numericWidth.Location = new System.Drawing.Point(51, 49);
            this.numericWidth.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericWidth.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this.numericWidth.Name = "numericWidth";
            this.numericWidth.Size = new System.Drawing.Size(120, 20);
            this.numericWidth.TabIndex = 8;
            this.numericWidth.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // numericHeight
            // 
            this.numericHeight.Location = new System.Drawing.Point(51, 70);
            this.numericHeight.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericHeight.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new System.Drawing.Size(120, 20);
            this.numericHeight.TabIndex = 9;
            this.numericHeight.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // btnResetScreen
            // 
            this.btnResetScreen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnResetScreen.Location = new System.Drawing.Point(51, 90);
            this.btnResetScreen.Name = "btnResetScreen";
            this.btnResetScreen.Size = new System.Drawing.Size(120, 23);
            this.btnResetScreen.TabIndex = 10;
            this.btnResetScreen.Text = "Reset";
            this.btnResetScreen.UseVisualStyleBackColor = true;
            this.btnResetScreen.Click += new System.EventHandler(this.BtnResetScreenClick);
            // 
            // tab_hotkeys
            // 
            this.tab_hotkeys.Controls.Add(this.textBox3);
            this.tab_hotkeys.Controls.Add(this.textBox2);
            this.tab_hotkeys.Controls.Add(this.textBox1);
            this.tab_hotkeys.Controls.Add(this.label_window_screenshot);
            this.tab_hotkeys.Controls.Add(this.checkBox6);
            this.tab_hotkeys.Controls.Add(this.checkBox7);
            this.tab_hotkeys.Controls.Add(this.checkBox8);
            this.tab_hotkeys.Controls.Add(this.label_region_screenshot);
            this.tab_hotkeys.Controls.Add(this.checkBox3);
            this.tab_hotkeys.Controls.Add(this.checkBox4);
            this.tab_hotkeys.Controls.Add(this.checkBox5);
            this.tab_hotkeys.Controls.Add(this.label_screenshot);
            this.tab_hotkeys.Controls.Add(this.checkBox2);
            this.tab_hotkeys.Controls.Add(this.checkBox1);
            this.tab_hotkeys.Controls.Add(this.check_screenshot_ctrl);
            this.tab_hotkeys.Controls.Add(this.label_hotkeys_instructions);
            this.tab_hotkeys.Location = new System.Drawing.Point(4, 22);
            this.tab_hotkeys.Name = "tab_hotkeys";
            this.tab_hotkeys.Padding = new System.Windows.Forms.Padding(3);
            this.tab_hotkeys.Size = new System.Drawing.Size(344, 185);
            this.tab_hotkeys.TabIndex = 3;
            this.tab_hotkeys.Text = "Hotkeys";
            this.tab_hotkeys.UseVisualStyleBackColor = true;
            // 
            // label_hotkeys_instructions
            // 
            this.label_hotkeys_instructions.Location = new System.Drawing.Point(8, 6);
            this.label_hotkeys_instructions.Name = "label_hotkeys_instructions";
            this.label_hotkeys_instructions.Size = new System.Drawing.Size(322, 23);
            this.label_hotkeys_instructions.TabIndex = 0;
            this.label_hotkeys_instructions.Text = "Set your own hotkeys here.";
            this.label_hotkeys_instructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // check_screenshot_ctrl
            // 
            this.check_screenshot_ctrl.Appearance = System.Windows.Forms.Appearance.Button;
            this.check_screenshot_ctrl.Checked = true;
            this.check_screenshot_ctrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_screenshot_ctrl.Enabled = false;
            this.check_screenshot_ctrl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.check_screenshot_ctrl.Location = new System.Drawing.Point(154, 33);
            this.check_screenshot_ctrl.Name = "check_screenshot_ctrl";
            this.check_screenshot_ctrl.Size = new System.Drawing.Size(42, 24);
            this.check_screenshot_ctrl.TabIndex = 1;
            this.check_screenshot_ctrl.Text = "Ctrl";
            this.check_screenshot_ctrl.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.Enabled = false;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox1.Location = new System.Drawing.Point(202, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(39, 24);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Alt";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Enabled = false;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox2.Location = new System.Drawing.Point(247, 33);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(47, 24);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Shift";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label_screenshot
            // 
            this.label_screenshot.Location = new System.Drawing.Point(8, 33);
            this.label_screenshot.Name = "label_screenshot";
            this.label_screenshot.Size = new System.Drawing.Size(140, 23);
            this.label_screenshot.TabIndex = 4;
            this.label_screenshot.Text = "1. Take screenshot:";
            this.label_screenshot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(300, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(30, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "3";
            // 
            // checkBox5
            // 
            this.checkBox5.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Enabled = false;
            this.checkBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox5.Location = new System.Drawing.Point(154, 63);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(42, 24);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Text = "Ctrl";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox4.Enabled = false;
            this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox4.Location = new System.Drawing.Point(202, 63);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(39, 24);
            this.checkBox4.TabIndex = 7;
            this.checkBox4.Text = "Alt";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Enabled = false;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox3.Location = new System.Drawing.Point(247, 63);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(47, 24);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "Shift";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label_region_screenshot
            // 
            this.label_region_screenshot.Location = new System.Drawing.Point(8, 63);
            this.label_region_screenshot.Name = "label_region_screenshot";
            this.label_region_screenshot.Size = new System.Drawing.Size(140, 23);
            this.label_region_screenshot.TabIndex = 9;
            this.label_region_screenshot.Text = "2. Take region screenshot:";
            this.label_region_screenshot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(300, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(30, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "4";
            // 
            // checkBox8
            // 
            this.checkBox8.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox8.Checked = true;
            this.checkBox8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox8.Enabled = false;
            this.checkBox8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox8.Location = new System.Drawing.Point(154, 93);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(42, 24);
            this.checkBox8.TabIndex = 11;
            this.checkBox8.Text = "Ctrl";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox7.Enabled = false;
            this.checkBox7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox7.Location = new System.Drawing.Point(202, 93);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(39, 24);
            this.checkBox7.TabIndex = 12;
            this.checkBox7.Text = "Alt";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Enabled = false;
            this.checkBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox6.Location = new System.Drawing.Point(247, 93);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(47, 24);
            this.checkBox6.TabIndex = 13;
            this.checkBox6.Text = "Shift";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // label_window_screenshot
            // 
            this.label_window_screenshot.Location = new System.Drawing.Point(8, 93);
            this.label_window_screenshot.Name = "label_window_screenshot";
            this.label_window_screenshot.Size = new System.Drawing.Size(140, 23);
            this.label_window_screenshot.TabIndex = 14;
            this.label_window_screenshot.Text = "3. Take window screenshot";
            this.label_window_screenshot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(300, 95);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(30, 20);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "5";
            // 
            // tab_behavior
            // 
            this.tab_behavior.Controls.Add(this.checkShowCursor);
            this.tab_behavior.Controls.Add(this.checkEditScreenshot);
            this.tab_behavior.Controls.Add(this.checkLaunchBrowser);
            this.tab_behavior.Controls.Add(this.checkBalloon);
            this.tab_behavior.Controls.Add(this.checkSoundEffects);
            this.tab_behavior.Controls.Add(this.checkCopyLinks);
            this.tab_behavior.Controls.Add(this.checkRunAtStartup);
            this.tab_behavior.Location = new System.Drawing.Point(4, 22);
            this.tab_behavior.Name = "tab_behavior";
            this.tab_behavior.Padding = new System.Windows.Forms.Padding(3);
            this.tab_behavior.Size = new System.Drawing.Size(344, 185);
            this.tab_behavior.TabIndex = 1;
            this.tab_behavior.Text = "Behavior";
            this.tab_behavior.UseVisualStyleBackColor = true;
            // 
            // checkRunAtStartup
            // 
            this.checkRunAtStartup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkRunAtStartup.Location = new System.Drawing.Point(8, 6);
            this.checkRunAtStartup.Name = "checkRunAtStartup";
            this.checkRunAtStartup.Size = new System.Drawing.Size(316, 19);
            this.checkRunAtStartup.TabIndex = 0;
            this.checkRunAtStartup.Text = "Run at system startup";
            this.checkRunAtStartup.UseVisualStyleBackColor = true;
            // 
            // checkCopyLinks
            // 
            this.checkCopyLinks.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkCopyLinks.Location = new System.Drawing.Point(8, 31);
            this.checkCopyLinks.Name = "checkCopyLinks";
            this.checkCopyLinks.Size = new System.Drawing.Size(316, 19);
            this.checkCopyLinks.TabIndex = 1;
            this.checkCopyLinks.Text = "Copy links to clipboard";
            this.checkCopyLinks.UseVisualStyleBackColor = true;
            // 
            // checkSoundEffects
            // 
            this.checkSoundEffects.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkSoundEffects.Location = new System.Drawing.Point(8, 81);
            this.checkSoundEffects.Name = "checkSoundEffects";
            this.checkSoundEffects.Size = new System.Drawing.Size(316, 19);
            this.checkSoundEffects.TabIndex = 2;
            this.checkSoundEffects.Text = "Enable sound effects";
            this.checkSoundEffects.UseVisualStyleBackColor = true;
            // 
            // checkBalloon
            // 
            this.checkBalloon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBalloon.Location = new System.Drawing.Point(8, 106);
            this.checkBalloon.Name = "checkBalloon";
            this.checkBalloon.Size = new System.Drawing.Size(316, 19);
            this.checkBalloon.TabIndex = 3;
            this.checkBalloon.Text = "Enable balloon messages";
            this.checkBalloon.UseVisualStyleBackColor = true;
            // 
            // checkLaunchBrowser
            // 
            this.checkLaunchBrowser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkLaunchBrowser.Location = new System.Drawing.Point(8, 131);
            this.checkLaunchBrowser.Name = "checkLaunchBrowser";
            this.checkLaunchBrowser.Size = new System.Drawing.Size(316, 19);
            this.checkLaunchBrowser.TabIndex = 4;
            this.checkLaunchBrowser.Text = "Launch browser after upload";
            this.checkLaunchBrowser.UseVisualStyleBackColor = true;
            // 
            // checkEditScreenshot
            // 
            this.checkEditScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkEditScreenshot.Location = new System.Drawing.Point(8, 156);
            this.checkEditScreenshot.Name = "checkEditScreenshot";
            this.checkEditScreenshot.Size = new System.Drawing.Size(316, 19);
            this.checkEditScreenshot.TabIndex = 5;
            this.checkEditScreenshot.Text = "Edit screenshot after capture";
            this.checkEditScreenshot.UseVisualStyleBackColor = true;
            // 
            // checkShowCursor
            // 
            this.checkShowCursor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkShowCursor.Location = new System.Drawing.Point(8, 56);
            this.checkShowCursor.Name = "checkShowCursor";
            this.checkShowCursor.Size = new System.Drawing.Size(316, 19);
            this.checkShowCursor.TabIndex = 6;
            this.checkShowCursor.Text = "Show cursor in screenshots";
            this.checkShowCursor.UseVisualStyleBackColor = true;
            // 
            // tab_general
            // 
            this.tab_general.Controls.Add(this.dropSaveQuality);
            this.tab_general.Controls.Add(this.label_save_quality);
            this.tab_general.Controls.Add(this.dropSaveFormat);
            this.tab_general.Controls.Add(this.label_save_format);
            this.tab_general.Controls.Add(this.btnBrowseSaveFolder);
            this.tab_general.Controls.Add(this.txtSaveFolder);
            this.tab_general.Controls.Add(this.checkSaveScreenshots);
            this.tab_general.Location = new System.Drawing.Point(4, 22);
            this.tab_general.Name = "tab_general";
            this.tab_general.Padding = new System.Windows.Forms.Padding(3);
            this.tab_general.Size = new System.Drawing.Size(344, 185);
            this.tab_general.TabIndex = 0;
            this.tab_general.Text = "General";
            this.tab_general.UseVisualStyleBackColor = true;
            // 
            // checkSaveScreenshots
            // 
            this.checkSaveScreenshots.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkSaveScreenshots.Location = new System.Drawing.Point(8, 6);
            this.checkSaveScreenshots.Name = "checkSaveScreenshots";
            this.checkSaveScreenshots.Size = new System.Drawing.Size(328, 19);
            this.checkSaveScreenshots.TabIndex = 0;
            this.checkSaveScreenshots.Text = "Save Screenshots Automatically";
            this.checkSaveScreenshots.UseVisualStyleBackColor = true;
            this.checkSaveScreenshots.CheckedChanged += new System.EventHandler(this.CheckSaveScreenshotsCheckedChanged);
            // 
            // txtSaveFolder
            // 
            this.txtSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaveFolder.Location = new System.Drawing.Point(8, 31);
            this.txtSaveFolder.Name = "txtSaveFolder";
            this.txtSaveFolder.Size = new System.Drawing.Size(254, 20);
            this.txtSaveFolder.TabIndex = 1;
            // 
            // btnBrowseSaveFolder
            // 
            this.btnBrowseSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSaveFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowseSaveFolder.Location = new System.Drawing.Point(261, 30);
            this.btnBrowseSaveFolder.Name = "btnBrowseSaveFolder";
            this.btnBrowseSaveFolder.Size = new System.Drawing.Size(75, 22);
            this.btnBrowseSaveFolder.TabIndex = 2;
            this.btnBrowseSaveFolder.Text = "browse";
            this.btnBrowseSaveFolder.UseVisualStyleBackColor = true;
            this.btnBrowseSaveFolder.Click += new System.EventHandler(this.BtnBrowseSaveFolderClick);
            // 
            // label_save_format
            // 
            this.label_save_format.Location = new System.Drawing.Point(8, 59);
            this.label_save_format.Name = "label_save_format";
            this.label_save_format.Size = new System.Drawing.Size(42, 23);
            this.label_save_format.TabIndex = 3;
            this.label_save_format.Text = "Format:";
            this.label_save_format.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dropSaveFormat
            // 
            this.dropSaveFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropSaveFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dropSaveFormat.FormattingEnabled = true;
            this.dropSaveFormat.Items.AddRange(new object[] {
            "bmp",
            "png",
            "jpg"});
            this.dropSaveFormat.Location = new System.Drawing.Point(56, 61);
            this.dropSaveFormat.Name = "dropSaveFormat";
            this.dropSaveFormat.Size = new System.Drawing.Size(121, 21);
            this.dropSaveFormat.TabIndex = 4;
            // 
            // label_save_quality
            // 
            this.label_save_quality.Location = new System.Drawing.Point(8, 86);
            this.label_save_quality.Name = "label_save_quality";
            this.label_save_quality.Size = new System.Drawing.Size(42, 23);
            this.label_save_quality.TabIndex = 5;
            this.label_save_quality.Text = "Quality:";
            this.label_save_quality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dropSaveQuality
            // 
            this.dropSaveQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropSaveQuality.Enabled = false;
            this.dropSaveQuality.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dropSaveQuality.FormattingEnabled = true;
            this.dropSaveQuality.Items.AddRange(new object[] {
            "100",
            "90",
            "80",
            "70",
            "60",
            "50",
            "40",
            "30",
            "20",
            "10"});
            this.dropSaveQuality.Location = new System.Drawing.Point(56, 88);
            this.dropSaveQuality.Name = "dropSaveQuality";
            this.dropSaveQuality.Size = new System.Drawing.Size(121, 21);
            this.dropSaveQuality.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab_general);
            this.tabControl1.Controls.Add(this.tab_behavior);
            this.tabControl1.Controls.Add(this.tab_hotkeys);
            this.tabControl1.Controls.Add(this.tab_screens);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(352, 211);
            this.tabControl1.TabIndex = 1;
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 240);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Preferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.Frm_PreferencesLoad);
            this.tab_screens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            this.tab_hotkeys.ResumeLayout(false);
            this.tab_hotkeys.PerformLayout();
            this.tab_behavior.ResumeLayout(false);
            this.tab_general.ResumeLayout(false);
            this.tab_general.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TabPage tab_screens;
        private System.Windows.Forms.Button btnResetScreen;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.NumericUpDown numericWidth;
        private System.Windows.Forms.NumericUpDown numericLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_screen_y;
        private System.Windows.Forms.NumericUpDown numericTop;
        private System.Windows.Forms.Label label_screen_x;
        private System.Windows.Forms.TabPage tab_hotkeys;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_window_screenshot;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Label label_region_screenshot;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label_screenshot;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox check_screenshot_ctrl;
        private System.Windows.Forms.Label label_hotkeys_instructions;
        private System.Windows.Forms.TabPage tab_behavior;
        private System.Windows.Forms.CheckBox checkShowCursor;
        private System.Windows.Forms.CheckBox checkEditScreenshot;
        private System.Windows.Forms.CheckBox checkLaunchBrowser;
        private System.Windows.Forms.CheckBox checkBalloon;
        private System.Windows.Forms.CheckBox checkSoundEffects;
        private System.Windows.Forms.CheckBox checkCopyLinks;
        private System.Windows.Forms.CheckBox checkRunAtStartup;
        private System.Windows.Forms.TabPage tab_general;
        private System.Windows.Forms.ComboBox dropSaveQuality;
        private System.Windows.Forms.Label label_save_quality;
        private System.Windows.Forms.ComboBox dropSaveFormat;
        private System.Windows.Forms.Label label_save_format;
        private System.Windows.Forms.Button btnBrowseSaveFolder;
        private System.Windows.Forms.TextBox txtSaveFolder;
        private System.Windows.Forms.CheckBox checkSaveScreenshots;
        private System.Windows.Forms.TabControl tabControl1;
	}
}
