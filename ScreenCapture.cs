using hyperdesktop2;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

public static class ScreenCapture
{
    [StructLayout(LayoutKind.Sequential)]
    struct CURSORINFO { public Int32 cbSize; public Int32 flags; public IntPtr hCursor; public POINTAPI ptScreenPos; }

    [StructLayout(LayoutKind.Sequential)]
    struct POINTAPI { public int x; public int y; }

    [DllImport("user32.dll")]
    static extern bool GetCursorInfo(out CURSORINFO pci);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight, int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);

    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hwnd, ref Rectangle rectangle);

    public static Bitmap CaptureRegion(Rectangle area, bool cursor = true, PixelFormat pixelFormat = PixelFormat.Format32bppRgb)
    {
        Bitmap bmp;

        try
        {
            bmp = new Bitmap(area.Width, area.Height, pixelFormat);
        }
        catch
        {
            bmp = new Bitmap(100, 100, pixelFormat);
        }

        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.CopyFromScreen(area.X, area.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

            if (cursor)
            {
                CURSORINFO cursor_info;
                cursor_info.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

                if (GetCursorInfo(out cursor_info) && cursor_info.flags == (Int32)0x0001)
                {
                    IntPtr hdc = g.GetHdc();
                    DrawIconEx(hdc, cursor_info.ptScreenPos.x - area.X, cursor_info.ptScreenPos.y - area.Y, cursor_info.hCursor, 0, 0, 0, IntPtr.Zero, (Int32)0x0003);
                    g.ReleaseHdc();
                }
            }
        }

        return bmp;
    }

    public static Bitmap CaptureScreen(bool cursor = true, PixelFormat pixelFormat = PixelFormat.Format32bppRgb)
    {
        return CaptureRegion(ScreenBounds.Bounds, cursor, pixelFormat);
    }

    public static Bitmap Window(bool cursor = true, PixelFormat pixel_format = PixelFormat.Format32bppRgb)
    {
        Rectangle rect = new Rectangle(); // get rekt m8 1v1 me fgt xddddddd
        GetWindowRect(GetForegroundWindow(), ref rect);

        Rectangle rectangle = new Rectangle((int)rect.X, (int)rect.Y, (int)(rect.Width - rect.X), (int)(rect.Height - rect.Y));
        return CaptureRegion(rectangle, cursor, pixel_format);
    }
}