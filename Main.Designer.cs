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
            this.registerHotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.takeRegionScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            resources.ApplyResources(this.main_menu, "main_menu");
            this.main_menu.Name = "main_menu";
            this.main_menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideWindowToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // hideWindowToolStripMenuItem
            // 
            this.hideWindowToolStripMenuItem.Name = "hideWindowToolStripMenuItem";
            resources.ApplyResources(this.hideWindowToolStripMenuItem, "hideWindowToolStripMenuItem");
            this.hideWindowToolStripMenuItem.Click += new System.EventHandler(this.InverseTrayOption);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerHotkeysToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // registerHotkeysToolStripMenuItem
            // 
            this.registerHotkeysToolStripMenuItem.Name = "registerHotkeysToolStripMenuItem";
            resources.ApplyResources(this.registerHotkeysToolStripMenuItem, "registerHotkeysToolStripMenuItem");
            this.registerHotkeysToolStripMenuItem.Click += new System.EventHandler(this.registerHotkeysToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            resources.ApplyResources(this.preferencesToolStripMenuItem, "preferencesToolStripMenuItem");
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.PreferencesToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // group_upload
            // 
            this.group_upload.Controls.Add(this.btn_browse);
            this.group_upload.Controls.Add(this.lbl_instructions);
            this.group_upload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.group_upload, "group_upload");
            this.group_upload.Name = "group_upload";
            this.group_upload.TabStop = false;
            this.group_upload.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.group_upload.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // btn_browse
            // 
            this.btn_browse.AllowDrop = true;
            resources.ApplyResources(this.btn_browse, "btn_browse");
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.BtnBrowseClick);
            this.btn_browse.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.btn_browse.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // lbl_instructions
            // 
            this.lbl_instructions.AllowDrop = true;
            this.lbl_instructions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.lbl_instructions, "lbl_instructions");
            this.lbl_instructions.Name = "lbl_instructions";
            this.lbl_instructions.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.lbl_instructions.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // group_screenshot
            // 
            this.group_screenshot.Controls.Add(this.btn_capture_selected_area);
            this.group_screenshot.Controls.Add(this.btn_capture);
            this.group_screenshot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.group_screenshot, "group_screenshot");
            this.group_screenshot.Name = "group_screenshot";
            this.group_screenshot.TabStop = false;
            // 
            // btn_capture_selected_area
            // 
            resources.ApplyResources(this.btn_capture_selected_area, "btn_capture_selected_area");
            this.btn_capture_selected_area.Name = "btn_capture_selected_area";
            this.btn_capture_selected_area.UseVisualStyleBackColor = true;
            this.btn_capture_selected_area.Click += new System.EventHandler(this.BtnCaptureRegionClick);
            // 
            // btn_capture
            // 
            resources.ApplyResources(this.btn_capture, "btn_capture");
            this.btn_capture.Name = "btn_capture";
            this.btn_capture.UseVisualStyleBackColor = true;
            this.btn_capture.Click += new System.EventHandler(this.BtnCaptureClick);
            // 
            // groupUploadProgress
            // 
            this.groupUploadProgress.Controls.Add(this.progress);
            resources.ApplyResources(this.groupUploadProgress, "groupUploadProgress");
            this.groupUploadProgress.Name = "groupUploadProgress";
            this.groupUploadProgress.TabStop = false;
            // 
            // progress
            // 
            resources.ApplyResources(this.progress, "progress");
            this.progress.Name = "progress";
            // 
            // group_image_links
            // 
            resources.ApplyResources(this.group_image_links, "group_image_links");
            this.group_image_links.Controls.Add(this.listImageLinks);
            this.group_image_links.Name = "group_image_links";
            this.group_image_links.TabStop = false;
            this.group_image_links.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.group_image_links.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // listImageLinks
            // 
            this.listImageLinks.AllowDrop = true;
            resources.ApplyResources(this.listImageLinks, "listImageLinks");
            this.listImageLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_url});
            this.listImageLinks.ContextMenuStrip = this.image_links_menu;
            this.listImageLinks.FullRowSelect = true;
            this.listImageLinks.GridLines = true;
            this.listImageLinks.MultiSelect = false;
            this.listImageLinks.Name = "listImageLinks";
            this.listImageLinks.UseCompatibleStateImageBehavior = false;
            this.listImageLinks.View = System.Windows.Forms.View.Details;
            this.listImageLinks.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.listImageLinks.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.listImageLinks.DoubleClick += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // column_url
            // 
            resources.ApplyResources(this.column_url, "column_url");
            // 
            // image_links_menu
            // 
            this.image_links_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem});
            this.image_links_menu.Name = "image_links_menu";
            resources.ApplyResources(this.image_links_menu, "image_links_menu");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItemClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // tray_menu
            // 
            this.tray_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToTrayToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.toolStripMenuItem1,
            this.takeRegionScreenshotToolStripMenuItem,
            this.takeScreenshotToolStripMenuItem,
            this.uploadFromClipboardToolStripMenuItem,
            this.aboutToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.tray_menu.Name = "tray_menu";
            resources.ApplyResources(this.tray_menu, "tray_menu");
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            resources.ApplyResources(this.minimizeToTrayToolStripMenuItem, "minimizeToTrayToolStripMenuItem");
            this.minimizeToTrayToolStripMenuItem.Click += new System.EventHandler(this.InverseTrayOption);
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            resources.ApplyResources(this.dashboardToolStripMenuItem, "dashboardToolStripMenuItem");
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // takeRegionScreenshotToolStripMenuItem
            // 
            this.takeRegionScreenshotToolStripMenuItem.Name = "takeRegionScreenshotToolStripMenuItem";
            resources.ApplyResources(this.takeRegionScreenshotToolStripMenuItem, "takeRegionScreenshotToolStripMenuItem");
            this.takeRegionScreenshotToolStripMenuItem.Click += new System.EventHandler(this.BtnCaptureRegionClick);
            // 
            // takeScreenshotToolStripMenuItem
            // 
            this.takeScreenshotToolStripMenuItem.Name = "takeScreenshotToolStripMenuItem";
            resources.ApplyResources(this.takeScreenshotToolStripMenuItem, "takeScreenshotToolStripMenuItem");
            this.takeScreenshotToolStripMenuItem.Click += new System.EventHandler(this.BtnCaptureClick);
            // 
            // uploadFromClipboardToolStripMenuItem
            // 
            this.uploadFromClipboardToolStripMenuItem.Name = "uploadFromClipboardToolStripMenuItem";
            resources.ApplyResources(this.uploadFromClipboardToolStripMenuItem, "uploadFromClipboardToolStripMenuItem");
            this.uploadFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.uploadFromClipboardToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            resources.ApplyResources(this.aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // tray_icon
            // 
            this.tray_icon.ContextMenuStrip = this.tray_menu;
            resources.ApplyResources(this.tray_icon, "tray_icon");
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // logoutBtn
            // 
            resources.ApplyResources(this.logoutBtn, "logoutBtn");
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // loginBtn
            // 
            resources.ApplyResources(this.loginBtn, "loginBtn");
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // passwordField
            // 
            resources.ApplyResources(this.passwordField, "passwordField");
            this.passwordField.Name = "passwordField";
            // 
            // emailField
            // 
            resources.ApplyResources(this.emailField, "emailField");
            this.emailField.Name = "emailField";
            // 
            // Main
            // 
            this.AcceptButton = this.loginBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.group_image_links);
            this.Controls.Add(this.groupUploadProgress);
            this.Controls.Add(this.group_screenshot);
            this.Controls.Add(this.group_upload);
            this.Controls.Add(this.main_menu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.main_menu;
            this.MaximizeBox = false;
            this.Name = "Main";
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
        private System.Windows.Forms.ToolStripMenuItem registerHotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
	}
}
