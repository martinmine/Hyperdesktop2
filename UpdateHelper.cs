using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace Shikashi
{
    class UpdateHelper
    {
        internal delegate void ApplicationRebootingEvent();
        internal event ApplicationRebootingEvent OnApplicationReboot;

        private ApplicationDeployment applicationDeployment;
        private bool alertOnDone;

        public UpdateHelper()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                applicationDeployment = ApplicationDeployment.CurrentDeployment;
                applicationDeployment.CheckForUpdateCompleted += UpdateCheckCompleted;
                applicationDeployment.UpdateCompleted += UpdateCompleted;
            }
        }

        internal void CheckForUpdates(bool alertOnDone = false)
        {
            this.alertOnDone = alertOnDone;
            if (applicationDeployment != null)
                applicationDeployment.CheckForUpdateAsync();
            else if (alertOnDone)
                MessageBox.Show("Unable to check for updates. Please try again.", "Update Error", MessageBoxButton.OK);
        }

        private void UpdateCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                OnApplicationReboot();
                Process.Start(GlobalFunctions.GetExePath());
                Environment.Exit(0);
            }
        }

        private void UpdateCheckCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            if (e.UpdateAvailable)
            {
                if (alertOnDone)
                    MessageBox.Show("An update is available. The application will update and then restart.", "Update Available", MessageBoxButton.OK);
                applicationDeployment.UpdateAsync();
            }
            else
            {
                if (alertOnDone)
                    MessageBox.Show("No update is available at the moment.", "No Update Available", MessageBoxButton.OK);
            }

            alertOnDone = false;
        }
    }
}
