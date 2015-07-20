using System.Deployment.Application;
using System.Windows;

namespace Shikashi
{
    class UpdateHelper
    {
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
        }

        private void UpdateCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }

        private void UpdateCheckCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            if (e.UpdateAvailable)
            {
                if (alertOnDone)
                    MessageBox.Show("Update Available", "An update is available. The application will update and then restart.", MessageBoxButton.OK);
                applicationDeployment.UpdateAsync();
            }
            else
            {
                if (alertOnDone)
                    MessageBox.Show("No Update Available", "No update is available at the moment.", MessageBoxButton.OK);
            }

            alertOnDone = false;
        }
    }
}
