using System;
using System.Windows.Forms;

namespace hyperdesktop2
{
    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            this.Modifier = modifier;
            this.Key = key;
        }

        public ModifierKeys Modifier { get; private set; }

        public Keys Key { get; private set; }
    }
}