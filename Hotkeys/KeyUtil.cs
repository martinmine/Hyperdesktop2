using System.Windows.Input;

namespace Shikashi
{
    class KeyUtil
    {
        internal static bool IsModifierKeys(Key key)
        {
            return Parse(key) != ModifierKeys.None;
        }

        internal static ModifierKeys Parse(Key key)
        {
            if (key == Key.LeftAlt || key == Key.RightAlt)
            {
                return ModifierKeys.Alt;
            }

            if (key == Key.LeftCtrl || key == Key.RightCtrl) 
            {
                return ModifierKeys.Control;
            }

            if (key == Key.LWin || key == Key.RWin) 
            {
                return ModifierKeys.Win;
            }

            if (key == Key.LeftShift || key == Key.RightShift)
            {
                return ModifierKeys.Shift;
            }

            return ModifierKeys.None;
        }
    }
}
