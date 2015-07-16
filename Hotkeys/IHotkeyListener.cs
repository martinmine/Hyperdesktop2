using System.Windows.Input;

namespace Shikashi
{
    interface IHotkeyListener
    {
        void OnKeyPress(Key key);
    }
}
