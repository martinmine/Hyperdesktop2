using Shikashi.Screenshotting;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Shikashi
{
    public static class ScreenCapture
    {
        private const string TempFolder = "temp";

        internal static TempScreenshotFile CaptureRegion(Rectangle area, bool cursor = true, PixelFormat pixelFormat = PixelFormat.Format32bppRgb)
        {
            if (!Directory.Exists(TempFolder))
                Directory.CreateDirectory(TempFolder);

            string fileName = Guid.NewGuid().ToString();
               
            using (Bitmap bmp = new Bitmap(area.Width, area.Height, pixelFormat))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(area.X, area.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

                    if (cursor)
                    {
                        CURSORINFO cursor_info;
                        cursor_info.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

                        if (NativeMethods.GetCursorInfo(out cursor_info) && cursor_info.flags == (Int32)0x0001)
                        {
                            IntPtr hdc = g.GetHdc();
                            NativeMethods.DrawIconEx(hdc, cursor_info.ptScreenPos.x - area.X, cursor_info.ptScreenPos.y - area.Y, cursor_info.hCursor, 0, 0, 0, IntPtr.Zero, (Int32)0x0003);
                            g.ReleaseHdc();
                        }
                    }
                }

                bmp.Save(TempFolder + "\\" + fileName, ImageFormat.Png);
            }

            return new TempScreenshotFile(TempFolder + "\\" + fileName);
        }

        internal static TempScreenshotFile CaptureScreen(bool cursor = true, PixelFormat pixelFormat = PixelFormat.Format32bppRgb)
        {
            return CaptureRegion(ScreenBounds.Bounds, cursor, pixelFormat);
        }

        internal static TempScreenshotFile Window(bool cursor = true, PixelFormat pixel_format = PixelFormat.Format32bppRgb)
        {
            Rectangle rect = new Rectangle(); // get rekt m8 1v1 me fgt xddddddd
            NativeMethods.GetWindowRect(NativeMethods.GetForegroundWindow(), ref rect);

            Rectangle rectangle = new Rectangle((int)rect.X, (int)rect.Y, (int)(rect.Width - rect.X), (int)(rect.Height - rect.Y));
            return CaptureRegion(rectangle, cursor, pixel_format);
        }
    }
}