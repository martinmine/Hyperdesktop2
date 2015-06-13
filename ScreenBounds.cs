using System;
using System.Drawing;
using System.Windows.Forms;

namespace hyperdesktop2
{
    class ScreenBounds
    {
        public static Rectangle Bounds { get; private set; }

        public static void Load()
        {
            String[] bounds_arr = Settings.ScreenResolution.Split(',');
            Bounds = new Rectangle(
                Convert.ToInt32(bounds_arr[0]),
                Convert.ToInt32(bounds_arr[1]),
                Convert.ToInt32(bounds_arr[2]),
                Convert.ToInt32(bounds_arr[3])
            );
        }

        public static String Reset()
        {
            Rectangle tempScreenBounds = new Rectangle(0, 0, 0, 0);

            foreach (Screen screen in Screen.AllScreens)
                if (screen != Screen.PrimaryScreen)
                    tempScreenBounds = Rectangle.Union(screen.Bounds, tempScreenBounds);

            return String.Format(
                "{0},{1},{2},{3}",
                tempScreenBounds.Left,
                tempScreenBounds.Top,
                SystemInformation.VirtualScreen.Width,
                SystemInformation.VirtualScreen.Height
            );
        }
    }
}
