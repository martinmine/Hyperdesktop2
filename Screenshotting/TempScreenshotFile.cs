using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

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
            DeleteFileLater();
        }

        private async Task DeleteFileLater()
        {
            await Task.Delay(5000);
            File.Delete(Path);
        }
    }
}
