/*
 * Created by SharpDevelop.
 * User: Mike
 * Date: 5/20/2014
 * Time: 5:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace hyperdesktop2
{
	partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.main_menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerHotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.group_upload = new System.Windows.Forms.GroupBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.lbl_instructions = new System.Windows.Forms.Label();
            this.group_screenshot = new System.Windows.Forms.GroupBox();
            this.btn_capture_selected_area = new System.Windows.Forms.Button();
            this.btn_capture = new System.Windows.Forms.Button();
            this.groupUploadProgress = new System.Windows.Forms.GroupBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.group_image_links = new System.Windows.Forms.GroupBox();
            this.listImageLinks = new System.Windows.Forms.ListView();
            this.column_url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.image_links_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tray_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.takeRegionScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tray_icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.emailField = new System.Windows.Forms.TextBox();
            this.uploadFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu.SuspendLayout();
            this.group_upload.SuspendLayout();
            this.group_screenshot.SuspendLayout();
            this.groupUploadProgress.SuspendLayout();
            this.group_image_links.SuspendLayout();
            this.image_links_menu.SuspendLayout();
            this.tray_menu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_menu
            // 
            this.main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.main_menu.Location = new System.Drawing.Point(0, 0);
            this.main_menu.Name = "main_menu";
            this.main_menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.main_menu.Size = new System.Drawing.Size(259, 24);
            this.main_menu.TabIndex = 0;
            this.main_menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideWindowToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // hideWindowToolStripMenuItem
            // 
            this.hideWindowToolStripMenuItem.Name = "hideWindowToolStripMenuItem";
            this.hideWindowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hideWindowToolStripMenuItem.Text = "Hide Window";
            this.hideWindowToolStripMenuItem.Click += new System.EventHandler(this.InverseTrayOption);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.PreferencesToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.registerHotkeysToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // registerHotkeysToolStripMenuItem
            // 
            this.registerHotkeysToolStripMenuItem.Name = "registerHotkeysToolStripMenuItem";
            this.registerHotkeysToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.registerHotkeysToolStripMenuItem.Text = "Register Hotkeys";
            this.registerHotkeysToolStripMenuItem.Click += new System.EventHandler(this.RegisterHotkeysToolStripMenuItemClick);
            // 
            // group_upload
            // 
            this.group_upload.Controls.Add(this.btn_browse);
            this.group_upload.Controls.Add(this.lbl_instructions);
            this.group_upload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.group_upload.Location = new System.Drawing.Point(12, 27);
            this.group_upload.Name = "group_upload";
            this.group_upload.Size = new System.Drawing.Size(235, 53);
            this.group_upload.TabIndex = 1;
            this.group_upload.TabStop = false;
            this.group_upload.Text = "Upload Files";
            this.group_upload.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.group_upload.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // btn_browse
            // 
            this.btn_browse.AllowDrop = true;
            this.btn_browse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_browse.Location = new System.Drawing.Point(165, 19);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(64, 23);
            this.btn_browse.TabIndex = 0;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.BtnBrowseClick);
            this.btn_browse.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.btn_browse.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // lbl_instructions
            // 
            this.lbl_instructions.AllowDrop = true;
            this.lbl_instructions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_instructions.Location = new System.Drawing.Point(6, 17);
            this.lbl_instructions.Name = "lbl_instructions";
            this.lbl_instructions.Size = new System.Drawing.Size(153, 34);
            this.lbl_instructions.TabIndex = 1;
            this.lbl_instructions.Text = "Drag and drop files here, or select them by pressing browse";
            this.lbl_instructions.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.lbl_instructions.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // group_screenshot
            // 
            this.group_screenshot.Controls.Add(this.btn_capture_selected_area);
            this.group_screenshot.Controls.Add(this.btn_capture);
            this.group_screenshot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.group_screenshot.Location = new System.Drawing.Point(12, 86);
            this.group_screenshot.Name = "group_screenshot";
            this.group_screenshot.Size = new System.Drawing.Size(235, 52);
            this.group_screenshot.TabIndex = 2;
            this.group_screenshot.TabStop = false;
            this.group_screenshot.Text = "Screenshot";
            // 
            // btn_capture_selected_area
            // 
            this.btn_capture_selected_area.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_capture_selected_area.Location = new System.Drawing.Point(93, 19);
            this.btn_capture_selected_area.Name = "btn_capture_selected_area";
            this.btn_capture_selected_area.Size = new System.Drawing.Size(136, 23);
            this.btn_capture_selected_area.TabIndex = 2;
            this.btn_capture_selected_area.Text = "Capture region";
            this.btn_capture_selected_area.UseVisualStyleBackColor = true;
            this.btn_capture_selected_area.Click += new System.EventHandler(this.BtnCaptureRegionClick);
            // 
            // btn_capture
            // 
            this.btn_capture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_capture.Location = new System.Drawing.Point(6, 19);
            this.btn_capture.Name = "btn_capture";
            this.btn_capture.Size = new System.Drawing.Size(81, 23);
            this.btn_capture.TabIndex = 1;
            this.btn_capture.Text = "Capture";
            this.btn_capture.UseVisualStyleBackColor = true;
            this.btn_capture.Click += new System.EventHandler(this.BtnCaptureClick);
            // 
            // groupUploadProgress
            // 
            this.groupUploadProgress.Controls.Add(this.progress);
            this.groupUploadProgress.Location = new System.Drawing.Point(12, 144);
            this.groupUploadProgress.Name = "groupUploadProgress";
            this.groupUploadProgress.Size = new System.Drawing.Size(235, 49);
            this.groupUploadProgress.TabIndex = 3;
            this.groupUploadProgress.TabStop = false;
            this.groupUploadProgress.Text = "Upload Progress";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(6, 19);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(223, 20);
            this.progress.TabIndex = 0;
            // 
            // group_image_links
            // 
            this.group_image_links.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_image_links.Controls.Add(this.listImageLinks);
            this.group_image_links.Location = new System.Drawing.Point(12, 306);
            this.group_image_links.Name = "group_image_links";
            this.group_image_links.Size = new System.Drawing.Size(235, 221);
            this.group_image_links.TabIndex = 4;
            this.group_image_links.TabStop = false;
            this.group_image_links.Text = "Upload history";
            this.group_image_links.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.group_image_links.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // listImageLinks
            // 
            this.listImageLinks.AllowDrop = true;
            this.listImageLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listImageLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_url});
            this.listImageLinks.ContextMenuStrip = this.image_links_menu;
            this.listImageLinks.FullRowSelect = true;
            this.listImageLinks.GridLines = true;
            this.listImageLinks.Location = new System.Drawing.Point(6, 19);
            this.listImageLinks.MultiSelect = false;
            this.listImageLinks.Name = "listImageLinks";
            this.listImageLinks.Size = new System.Drawing.Size(223, 196);
            this.listImageLinks.TabIndex = 0;
            this.listImageLinks.UseCompatibleStateImageBehavior = false;
            this.listImageLinks.View = System.Windows.Forms.View.Details;
            this.listImageLinks.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.listImageLinks.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.listImageLinks.DoubleClick += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // column_url
            // 
            this.column_url.Text = "File URL";
            this.column_url.Width = 218;
            // 
            // image_links_menu
            // 
            this.image_links_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem});
            this.image_links_menu.Name = "image_links_menu";
            this.image_links_menu.Size = new System.Drawing.Size(108, 76);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItemClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(104, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // tray_menu
            // 
            this.tray_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToTrayToolStripMenuItem,
            this.toolStripMenuItem1,
            this.takeRegionScreenshotToolStripMenuItem,
            this.takeScreenshotToolStripMenuItem,
            this.uploadFromClipboardToolStripMenuItem,
            this.aboutToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.tray_menu.Name = "tray_menu";
            this.tray_menu.Size = new System.Drawing.Size(201, 164);
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            this.minimizeToTrayToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.minimizeToTrayToolStripMenuItem.Text = "Minimize to tray";
            this.minimizeToTrayToolStripMenuItem.Click += new System.EventHandler(this.InverseTrayOption);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(197, 6);
            // 
            // takeRegionScreenshotToolStripMenuItem
            // 
            this.takeRegionScreenshotToolStripMenuItem.Name = "takeRegionScreenshotToolStripMenuItem";
            this.takeRegionScreenshotToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.takeRegionScreenshotToolStripMenuItem.Text = "Take Region Screenshot";
            this.takeRegionScreenshotToolStripMenuItem.Click += new System.EventHandler(this.BtnCaptureRegionClick);
            // 
            // takeScreenshotToolStripMenuItem
            // 
            this.takeScreenshotToolStripMenuItem.Name = "takeScreenshotToolStripMenuItem";
            this.takeScreenshotToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.takeScreenshotToolStripMenuItem.Text = "Take Screenshot";
            this.takeScreenshotToolStripMenuItem.Click += new System.EventHandler(this.BtnCaptureClick);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // tray_icon
            // 
            this.tray_icon.ContextMenuStrip = this.tray_menu;
            this.tray_icon.Icon = ((System.Drawing.Icon)(resources.GetObject("tray_icon.Icon")));
            this.tray_icon.Text = "Hyperdesktop2";
            this.tray_icon.Visible = true;
            this.tray_icon.DoubleClick += new System.EventHandler(this.InverseTrayOption);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.logoutBtn);
            this.groupBox1.Controls.Add(this.loginBtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.passwordField);
            this.groupBox1.Controls.Add(this.emailField);
            this.groupBox1.Location = new System.Drawing.Point(12, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 101);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your account";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(149, 71);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(61, 23);
            this.logoutBtn.TabIndex = 10;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(82, 71);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(61, 23);
            this.loginBtn.TabIndex = 9;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Email:";
            // 
            // passwordField
            // 
            this.passwordField.Location = new System.Drawing.Point(82, 45);
            this.passwordField.Name = "passwordField";
            this.passwordField.PasswordChar = '*';
            this.passwordField.Size = new System.Drawing.Size(147, 20);
            this.passwordField.TabIndex = 8;
            // 
            // emailField
            // 
            this.emailField.Location = new System.Drawing.Point(82, 19);
            this.emailField.Name = "emailField";
            this.emailField.Size = new System.Drawing.Size(147, 20);
            this.emailField.TabIndex = 7;
            // 
            // uploadFromClipboardToolStripMenuItem
            // 
            this.uploadFromClipboardToolStripMenuItem.Name = "uploadFromClipboardToolStripMenuItem";
            this.uploadFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.uploadFromClipboardToolStripMenuItem.Text = "Upload from clipboard";
            this.uploadFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.uploadFromClipboardToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 539);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.group_image_links);
            this.Controls.Add(this.groupUploadProgress);
            this.Controls.Add(this.group_screenshot);
            this.Controls.Add(this.group_upload);
            this.Controls.Add(this.main_menu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.main_menu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(275, 99999999);
            this.MinimumSize = new System.Drawing.Size(275, 300);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "shikashi uploader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.main_menu.ResumeLayout(false);
            this.main_menu.PerformLayout();
            this.group_upload.ResumeLayout(false);
            this.group_screenshot.ResumeLayout(false);
            this.groupUploadProgress.ResumeLayout(false);
            this.group_image_links.ResumeLayout(false);
            this.image_links_menu.ResumeLayout(false);
            this.tray_menu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem registerHotkeysToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip image_links_menu;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader column_url;
		private System.Windows.Forms.NotifyIcon tray_icon;
		private System.Windows.Forms.ToolStripMenuItem minimizeToTrayToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem takeRegionScreenshotToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem takeScreenshotToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip tray_menu;
		private System.Windows.Forms.GroupBox groupUploadProgress;
		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.GroupBox group_image_links;
		private System.Windows.Forms.ListView listImageLinks;
		private System.Windows.Forms.GroupBox group_upload;
		private System.Windows.Forms.Button btn_browse;
		private System.Windows.Forms.Label lbl_instructions;
		private System.Windows.Forms.GroupBox group_screenshot;
		private System.Windows.Forms.Button btn_capture_selected_area;
		private System.Windows.Forms.Button btn_capture;
		private System.Windows.Forms.MenuStrip main_menu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hideWindowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.TextBox emailField;
        private System.Windows.Forms.ToolStripMenuItem uploadFromClipboardToolStripMenuItem;
	}
}
