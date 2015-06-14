using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace hyperdesktop2
{
	/// <summary>
	/// Description of frm_About.
	/// </summary>
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
		}
		private void BtnGithubClick(object sender, System.EventArgs e)
		{
			Process.Start("https://github.com/TheTarkus/Hyperdesktop2/");
		}
        private void BtnReportClick(object sender, System.EventArgs e)
		{
			Process.Start("https://github.com/TheTarkus/Hyperdesktop2/issues");
		}
        private void FrmAboutLoad(object sender, System.EventArgs e)
		{
			labelBuild.Text = "Build: " + Settings.BuildVersion;
		}
	}
}
