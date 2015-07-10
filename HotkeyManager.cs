using System.Windows.Forms;

namespace hyperdesktop2
{
    class HotkeyManager
    {
        private Hotkeys hook;
        private IHotkeyListener listener;

        private static readonly HotkeyManager instance = new HotkeyManager();

        private HotkeyManager()
        {
        }

        internal static HotkeyManager GetInstance()
        {
            return instance;
        }

        public void SetListener(IHotkeyListener listener)
        {
            this.listener = listener;
        }

        internal void RegisterHotkeys()
        {
            hook = new Hotkeys();
            hook.KeyPressed += hook_KeyPressed;
            try
            {
                hook.RegisterHotKey((ModifierKeys)Properties.Settings.Default.FullScreenshotHotkeyFirst | 
                        (ModifierKeys)Properties.Settings.Default.FullScreenshotHotkeySecond | 
                        (ModifierKeys)Properties.Settings.Default.FullScreenshotHotkeyThird, 
                        (Keys)Properties.Settings.Default.FullScreenshotHotkeyValue);
                hook.RegisterHotKey((ModifierKeys)Properties.Settings.Default.RegionalScreenshotHotkeyFirst |
                        (ModifierKeys)Properties.Settings.Default.RegionalScreenshotHotkeySecond |
                        (ModifierKeys)Properties.Settings.Default.RegionalScreenshotHotkeyThird,
                        (Keys)Properties.Settings.Default.RegionalScreenshotHotkeyValue);
                hook.RegisterHotKey((ModifierKeys)Properties.Settings.Default.WindowedScreenshotHotkeyFirst |
                       (ModifierKeys)Properties.Settings.Default.WindowedScreenshotHotkeySecond |
                       (ModifierKeys)Properties.Settings.Default.WindowedScreenshotHotkeyThird,
                       (Keys)Properties.Settings.Default.WindowedScreenshotHotkeyValue);
            }
            catch
            {
                MessageBox.Show("Couldn't register hotkeys. Perhaps they are already in use or try running as an Administrator.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void UnregisterHotkeys()
        {
            hook.Dispose();
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (listener != null)
            {
                listener.OnKeyPress(e.Key);
            }
        }
    }
}
