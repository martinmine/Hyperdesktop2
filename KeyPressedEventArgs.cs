using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace Shikashi
{
    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        private int virtualKeyCode;
        internal KeyPressedEventArgs(ModifierKeys modifier, int key)
        {
            this.Modifier = modifier;
            this.virtualKeyCode = key;
        }

        public ModifierKeys Modifier { get; private set; }

        public Key Key
        {
            get
            {
                return KeyInterop.KeyFromVirtualKey(virtualKeyCode);
            }
        }
    }
}