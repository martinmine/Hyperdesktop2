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
		private void BtnGithubHyperdesktopClick(object sender, System.EventArgs e)
		{
			Process.Start("https://github.com/TheTarkus/Hyperdesktop2/");
		}
        private void BtnShikashiUploadGithubClick(object sender, System.EventArgs e)
		{
            Process.Start("https://github.com/martinmine/Shikashi-Uploader");
		}
        private void FrmAboutLoad(object sender, System.EventArgs e)
		{
            labelBuild.Text = "Version " + Application.ProductVersion;
		}
	}
}
