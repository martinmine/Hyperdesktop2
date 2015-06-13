using System;
using System.Threading;
using System.Windows.Forms;

namespace hyperdesktop2
{
    internal sealed class Program
    {
        private static Mutex mutex;

        private static bool InstanceRunning()
        {
            const string applicationName = "Hyperdesktop2";

            try
            {
                Mutex.OpenExisting(applicationName);
            }
            catch
            {
                Program.mutex = new Mutex(true, applicationName);
                return true;
            }
            return false;
        }

        [STAThread]
        private static void Main()
        {
            if (!Program.InstanceRunning())
            {
                MessageBox.Show("Hyperdesktop2 is already running!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
        }
    }
}
