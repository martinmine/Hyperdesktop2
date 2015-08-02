using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Shikashi.Screenshotting
{
    class TempScreenshotFile : IDisposable
    {
        internal Stream FileStream { get; private set; }
        internal string Path { get; private set; }

        public TempScreenshotFile(Image image)
        {
            string path = System.IO.Path.GetTempFileName();

            image.Save(path, ImageFormat.Png);

            this.Path = path;
            this.FileStream = File.Open(path, FileMode.Open);
        }

        public void Dispose()
        {
            FileStream.Dispose();
            File.Delete(Path);
        }
    }
}
