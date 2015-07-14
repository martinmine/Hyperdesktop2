﻿/*
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
            this.tab_hotkeys = new System.Windows.Forms.TabPage();
            this.label_hotkeys_instructions = new System.Windows.Forms.Label();
            this.label_screenshot = new System.Windows.Forms.Label();
            this.label_region_screenshot = new System.Windows.Forms.Label();
            this.label_window_screenshot = new System.Windows.Forms.Label();
            this.comboBoxRegionalFirst = new System.Windows.Forms.ComboBox();
            this.comboBoxRegionalSecond = new System.Windows.Forms.ComboBox();
            this.comboBoxScreenshotThird = new System.Windows.Forms.ComboBox();
            this.comboBoxRegionalThird = new System.Windows.Forms.ComboBox();
            this.comboBoxWindowScreenshotThird = new System.Windows.Forms.ComboBox();
            this.comboBoxScreenshotSecond = new System.Windows.Forms.ComboBox();
            this.comboBoxWindowScreenshotSecond = new System.Windows.Forms.ComboBox();
            this.comboBoxScreenshotFirst = new System.Windows.Forms.ComboBox();
            this.comboBoxWindowScreenshotFirst = new System.Windows.Forms.ComboBox();
            this.buttonScreenshotKey = new System.Windows.Forms.Button();
            this.buttonRegionalValue = new System.Windows.Forms.Button();
            this.buttonWindowValue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.btn_save.Location = new System.Drawing.Point(208, 217);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "OK";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_cancel.Location = new System.Drawing.Point(290, 217);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // tab_hotkeys
            // 
            this.tab_hotkeys.Controls.Add(this.label5);
            this.tab_hotkeys.Controls.Add(this.label4);
            this.tab_hotkeys.Controls.Add(this.label1);
            this.tab_hotkeys.Controls.Add(this.buttonWindowValue);
            this.tab_hotkeys.Controls.Add(this.buttonRegionalValue);
            this.tab_hotkeys.Controls.Add(this.buttonScreenshotKey);
            this.tab_hotkeys.Controls.Add(this.comboBoxWindowScreenshotFirst);
            this.tab_hotkeys.Controls.Add(this.comboBoxScreenshotFirst);
            this.tab_hotkeys.Controls.Add(this.comboBoxWindowScreenshotSecond);
            this.tab_hotkeys.Controls.Add(this.comboBoxScreenshotSecond);
            this.tab_hotkeys.Controls.Add(this.comboBoxWindowScreenshotThird);
            this.tab_hotkeys.Controls.Add(this.comboBoxRegionalThird);
            this.tab_hotkeys.Controls.Add(this.comboBoxScreenshotThird);
            this.tab_hotkeys.Controls.Add(this.comboBoxRegionalSecond);
            this.tab_hotkeys.Controls.Add(this.comboBoxRegionalFirst);
            this.tab_hotkeys.Controls.Add(this.label_window_screenshot);
            this.tab_hotkeys.Controls.Add(this.label_region_screenshot);
            this.tab_hotkeys.Controls.Add(this.label_screenshot);
            this.tab_hotkeys.Controls.Add(this.label_hotkeys_instructions);
            this.tab_hotkeys.Location = new System.Drawing.Point(4, 22);
            this.tab_hotkeys.Name = "tab_hotkeys";
            this.tab_hotkeys.Padding = new System.Windows.Forms.Padding(3);
            this.tab_hotkeys.Size = new System.Drawing.Size(361, 189);
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
            // label_screenshot
            // 
            this.label_screenshot.Location = new System.Drawing.Point(6, 85);
            this.label_screenshot.Name = "label_screenshot";
            this.label_screenshot.Size = new System.Drawing.Size(140, 23);
            this.label_screenshot.TabIndex = 4;
            this.label_screenshot.Text = "Take screenshot:";
            this.label_screenshot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_region_screenshot
            // 
            this.label_region_screenshot.Location = new System.Drawing.Point(6, 31);
            this.label_region_screenshot.Name = "label_region_screenshot";
            this.label_region_screenshot.Size = new System.Drawing.Size(140, 23);
            this.label_region_screenshot.TabIndex = 9;
            this.label_region_screenshot.Text = "Take region screenshot:";
            this.label_region_screenshot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_window_screenshot
            // 
            this.label_window_screenshot.Location = new System.Drawing.Point(6, 58);
            this.label_window_screenshot.Name = "label_window_screenshot";
            this.label_window_screenshot.Size = new System.Drawing.Size(140, 23);
            this.label_window_screenshot.TabIndex = 14;
            this.label_window_screenshot.Text = "Take window screenshot:";
            this.label_window_screenshot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxRegionalFirst
            // 
            this.comboBoxRegionalFirst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegionalFirst.FormattingEnabled = true;
            this.comboBoxRegionalFirst.Items.AddRange(new object[] {
            "",
            "Ctrl",
            "Alt",
            "Shift",
            "Win"});
            this.comboBoxRegionalFirst.Location = new System.Drawing.Point(152, 32);
            this.comboBoxRegionalFirst.Name = "comboBoxRegionalFirst";
            this.comboBoxRegionalFirst.Size = new System.Drawing.Size(42, 21);
            this.comboBoxRegionalFirst.TabIndex = 16;
            // 
            // comboBoxRegionalSecond
            // 
            this.comboBoxRegionalSecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegionalSecond.FormattingEnabled = true;
            this.comboBoxRegionalSecond.Items.AddRange(new object[] {
            "",
            "Ctrl",
            "Alt",
            "Shift",
            "Win"});
            this.comboBoxRegionalSecond.Location = new System.Drawing.Point(200, 32);
            this.comboBoxRegionalSecond.Name = "comboBoxRegionalSecond";
            this.comboBoxRegionalSecond.Size = new System.Drawing.Size(42, 21);
            this.comboBoxRegionalSecond.TabIndex = 16;
            // 
            // comboBoxScreenshotThird
            // 
            this.comboBoxScreenshotThird.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScreenshotThird.FormattingEnabled = true;
            this.comboBoxScreenshotThird.Items.AddRange(new object[] {
            "",
            "Ctrl",
            "Alt",
            "Shift",
            "Win"});
            this.comboBoxScreenshotThird.Location = new System.Drawing.Point(248, 86);
            this.comboBoxScreenshotThird.Name = "comboBoxScreenshotThird";
            this.comboBoxScreenshotThird.Size = new System.Drawing.Size(42, 21);
            this.comboBoxScreenshotThird.TabIndex = 16;
            // 
            // comboBoxRegionalThird
            // 
            this.comboBoxRegionalThird.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegionalThird.FormattingEnabled = true;
            this.comboBoxRegionalThird.Items.AddRange(new object[] {
            "",
            "Ctrl",
            "Alt",
            "Shift",
            "Win"});
            this.comboBoxRegionalThird.Location = new System.Drawing.Point(248, 32);
            this.comboBoxRegionalThird.Name = "comboBoxRegionalThird";
            this.comboBoxRegionalThird.Size = new System.Drawing.Size(42, 21);
            this.comboBoxRegionalThird.TabIndex = 16;
            // 
            // comboBoxWindowScreenshotThird
            // 
            this.comboBoxWindowScreenshotThird.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWindowScreenshotThird.FormattingEnabled = true;
            this.comboBoxWindowScreenshotThird.Items.AddRange(new object[] {
            "",
            "Ctrl",
            "Alt",
            "Shift",
            "Win"});
            this.comboBoxWindowScreenshotThird.Location = new System.Drawing.Point(248, 59);
            this.comboBoxWindowScreenshotThird.Name = "comboBoxWindowScreenshotThird";
            this.comboBoxWindowScreenshotThird.Size = new System.Drawing.Size(42, 21);
            this.comboBoxWindowScreenshotThird.TabIndex = 16;
            // 
            // comboBoxScreenshotSecond
            // 
            this.comboBoxScreenshotSecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScreenshotSecond.FormattingEnabled = true;
            this.comboBoxScreenshotSecond.Items.AddRange(new object[] {
            "",
            "Ctrl",
            "Alt",
            "Shift",
            "Win"});
            this.comboBoxScreenshotSecond.Location = new System.Drawing.Point(200, 86);
            this.comboBoxScreenshotSecond.Name = "comboBoxScreenshotSecond";
            this.comboBoxScreenshotSecond.Size = new System.Drawing.Size(42, 21);
            this.comboBoxScreenshotSecond.TabIndex = 16;
            // 
            // comboBoxWindowScreenshotSecond
            // 
            this.comboBoxWindowScreenshotSecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWindowScreenshotSecond.FormattingEnabled = true;
            this.comboBoxWindowScreenshotSecond.Items.AddRange(new object[] {
            "",
            "Ctrl",
            "Alt",
            "Shift",
            "Win"});
            this.comboBoxWindowScreenshotSecond.Location = new System.Drawing.Point(200, 59);
            this.comboBoxWindowScreenshotSecond.Name = "comboBoxWindowScreenshotSecond";
            this.comboBoxWindowScreenshotSecond.Size = new System.Drawing.Size(42, 21);
            this.comboBoxWindowScreenshotSecond.TabIndex = 16;
            // 
            // comboBoxScreenshotFirst
            // 
            this.comboBoxScreenshotFirst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScreenshotFirst.FormattingEnabled = true;
            this.comboBoxScreenshotFirst.Items.AddRange(new object[] {
            "",
            "Ctrl",
            "Alt",
            "Shift",
            "Win"});
            this.comboBoxScreenshotFirst.Location = new System.Drawing.Point(152, 86);
            this.comboBoxScreenshotFirst.Name = "comboBoxScreenshotFirst";
            this.comboBoxScreenshotFirst.Size = new System.Drawing.Size(42, 21);
            this.comboBoxScreenshotFirst.TabIndex = 16;
            // 
            // comboBoxWindowScreenshotFirst
            // 
            this.comboBoxWindowScreenshotFirst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWindowScreenshotFirst.FormattingEnabled = true;
            this.comboBoxWindowScreenshotFirst.Items.AddRange(new object[] {
            "",
            "Ctrl",
            "Alt",
            "Shift",
            "Win"});
            this.comboBoxWindowScreenshotFirst.Location = new System.Drawing.Point(152, 59);
            this.comboBoxWindowScreenshotFirst.Name = "comboBoxWindowScreenshotFirst";
            this.comboBoxWindowScreenshotFirst.Size = new System.Drawing.Size(42, 21);
            this.comboBoxWindowScreenshotFirst.TabIndex = 16;
            // 
            // buttonScreenshotKey
            // 
            this.buttonScreenshotKey.Location = new System.Drawing.Point(313, 85);
            this.buttonScreenshotKey.Name = "buttonScreenshotKey";
            this.buttonScreenshotKey.Size = new System.Drawing.Size(34, 23);
            this.buttonScreenshotKey.TabIndex = 17;
            this.buttonScreenshotKey.UseVisualStyleBackColor = true;
            this.buttonScreenshotKey.Click += new System.EventHandler(this.buttonScreenshotKey_Click);
            // 
            // buttonRegionalValue
            // 
            this.buttonRegionalValue.Location = new System.Drawing.Point(313, 31);
            this.buttonRegionalValue.Name = "buttonRegionalValue";
            this.buttonRegionalValue.Size = new System.Drawing.Size(34, 23);
            this.buttonRegionalValue.TabIndex = 17;
            this.buttonRegionalValue.UseVisualStyleBackColor = true;
            this.buttonRegionalValue.Click += new System.EventHandler(this.buttonRegionalValue_Click);
            // 
            // buttonWindowValue
            // 
            this.buttonWindowValue.Location = new System.Drawing.Point(313, 58);
            this.buttonWindowValue.Name = "buttonWindowValue";
            this.buttonWindowValue.Size = new System.Drawing.Size(34, 23);
            this.buttonWindowValue.TabIndex = 17;
            this.buttonWindowValue.UseVisualStyleBackColor = true;
            this.buttonWindowValue.Click += new System.EventHandler(this.buttonWindowValue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "+";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "+";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "+";
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
            this.tab_behavior.Size = new System.Drawing.Size(361, 189);
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
            this.tab_general.Size = new System.Drawing.Size(361, 189);
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
            this.txtSaveFolder.Size = new System.Drawing.Size(274, 20);
            this.txtSaveFolder.TabIndex = 1;
            // 
            // btnBrowseSaveFolder
            // 
            this.btnBrowseSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSaveFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowseSaveFolder.Location = new System.Drawing.Point(281, 30);
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
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(369, 215);
            this.tabControl1.TabIndex = 1;
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 244);
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
        private System.Windows.Forms.TabPage tab_hotkeys;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonWindowValue;
        private System.Windows.Forms.Button buttonRegionalValue;
        private System.Windows.Forms.Button buttonScreenshotKey;
        private System.Windows.Forms.ComboBox comboBoxWindowScreenshotFirst;
        private System.Windows.Forms.ComboBox comboBoxScreenshotFirst;
        private System.Windows.Forms.ComboBox comboBoxWindowScreenshotSecond;
        private System.Windows.Forms.ComboBox comboBoxScreenshotSecond;
        private System.Windows.Forms.ComboBox comboBoxWindowScreenshotThird;
        private System.Windows.Forms.ComboBox comboBoxRegionalThird;
        private System.Windows.Forms.ComboBox comboBoxScreenshotThird;
        private System.Windows.Forms.ComboBox comboBoxRegionalSecond;
        private System.Windows.Forms.ComboBox comboBoxRegionalFirst;
        private System.Windows.Forms.Label label_window_screenshot;
        private System.Windows.Forms.Label label_region_screenshot;
        private System.Windows.Forms.Label label_screenshot;
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
