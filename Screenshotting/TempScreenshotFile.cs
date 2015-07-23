using System;
using System.IO;

namespace Shikashi.Screenshotting
{
    class TempScreenshotFile : IDisposable
    {
        internal Stream FileStream { get; private set; }
        private string path;

        public TempScreenshotFile(string path)
        {
            this.path = path;
            this.FileStream = File.Open(path, FileMode.Open);
        }

        public void Dispose()
        {
            FileStream.Dispose();
            File.Delete(path);
        }
    }
}
