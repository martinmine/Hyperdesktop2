using System.Windows.Forms;

namespace hyperdesktop2
{
    interface IHotkeyListener
    {
        void OnKeyPress(Keys key);
    }
}
