using System.Windows.Forms;
using System.Windows.Input;

namespace Shikashi
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
                RegisterHotkey(Properties.Settings.Default.FullScreenshotHotkeyFirst,
                        Properties.Settings.Default.FullScreenshotHotkeySecond,
                        Properties.Settings.Default.FullScreenshotHotkeyThird,
                        Properties.Settings.Default.FullScreenshotHotkeyValue);
                RegisterHotkey(Properties.Settings.Default.RegionalScreenshotHotkeyFirst,
                        Properties.Settings.Default.RegionalScreenshotHotkeySecond,
                        Properties.Settings.Default.RegionalScreenshotHotkeyThird,
                        Properties.Settings.Default.RegionalScreenshotHotkeyValue);
                RegisterHotkey(Properties.Settings.Default.WindowedScreenshotHotkeyFirst,
                        Properties.Settings.Default.WindowedScreenshotHotkeySecond,
                        Properties.Settings.Default.WindowedScreenshotHotkeyThird,
                        Properties.Settings.Default.WindowedScreenshotHotkeyValue);
            }
            catch
            {
                MessageBox.Show("Couldn't register hotkeys. Perhaps they are already in use or try running as an Administrator.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterHotkey(int first, int second, int third, int value)
        {
            ModifierKeys f = KeyUtil.Parse((Key)first);
            ModifierKeys s = KeyUtil.Parse((Key)second);
            ModifierKeys t = KeyUtil.Parse((Key)third);

            uint key = (uint)KeyInterop.VirtualKeyFromKey((Key)value);
            hook.RegisterHotKey(f | s | t, key);
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
