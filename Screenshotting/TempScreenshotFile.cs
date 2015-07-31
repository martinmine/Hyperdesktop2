using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Shikashi.Screenshotting
{
    class TempScreenshotFile : IDisposable
    {
        private const string TempFolder = "temp";

        internal Stream FileStream { get; private set; }
        internal string Path { get; private set; }

        public TempScreenshotFile(Image image)
        {
            if (!Directory.Exists(TempFolder))
                Directory.CreateDirectory(TempFolder);

            string path = TempFolder + "\\" + Guid.NewGuid().ToString();

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
