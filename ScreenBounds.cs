using System;
using System.Drawing;
using System.Windows.Forms;

namespace hyperdesktop2
{
    class ScreenBounds
    {
        public static Rectangle Bounds
        {
            get
            {
                Rectangle tempScreenBounds = new Rectangle(0, 0, 0, 0);

                foreach (Screen screen in Screen.AllScreens)
                    if (screen != Screen.PrimaryScreen)
                        tempScreenBounds = Rectangle.Union(screen.Bounds, tempScreenBounds);

                return new Rectangle(
                    tempScreenBounds.Left,
                    tempScreenBounds.Top,
                    SystemInformation.VirtualScreen.Width,
                    SystemInformation.VirtualScreen.Height
                );
            }
        }
    }
}
