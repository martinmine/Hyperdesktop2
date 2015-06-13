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
		void Btn_githubClick(object sender, System.EventArgs e)
		{
			Process.Start("https://github.com/TheTarkus/Hyperdesktop2/");
		}
		void Btn_reportClick(object sender, System.EventArgs e)
		{
			Process.Start("https://github.com/TheTarkus/Hyperdesktop2/issues");
		}
		void Frm_AboutLoad(object sender, System.EventArgs e)
		{
			label_build.Text = "Build: " + Settings.BuildVersion;
		}
	}
}
