using Shikashi.API;
using Shikashi.Screenshotting;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shikashi.Uploading
{
    class Uploader : IHotkeyListener
    {
        internal delegate void UploadResultReceived(FileUploadResult res);
        internal event UploadResultReceived OnUploadCompleted;
        private IUploadStatusListener progressStatusListener;
        private bool snipperOpen;


        public Uploader(IUploadStatusListener progressStatusListener)
        {
            this.progressStatusListener = progressStatusListener;
        }
        
        internal async void CaptureScreen(string type)
        {
            switch (type)
            {
                case "screen":
                    using (TempScreenshotFile screenshot = ScreenCapture.CaptureScreen(Properties.Settings.Default.ShowCursor))
                    {
                        await HandleImageUpload(screenshot, true);
                    }

                    break;

                case "window":
                    using (TempScreenshotFile screenshot = ScreenCapture.Window(Properties.Settings.Default.ShowCursor))
                    {
                        await HandleImageUpload(screenshot, true);
                    }

                    break;

                default:
                    if (snipperOpen)
                        return;

                    snipperOpen = true;

                    try
                    {
                        Rectangle rect = Snipper.GetRegion();
                        if (rect == Rectangle.Empty)
                            return;
                        
                        using (TempScreenshotFile screenshot = ScreenCapture.CaptureRegion(rect))
                        {
                            await HandleImageUpload(screenshot, true);
                        }
                    }
                    finally
                    {
                        snipperOpen = false;
                    }

                    break;
            }
        }

        private async Task HandleImageUpload(TempScreenshotFile screenshot, bool edit = false)
        {
            GlobalFunctions.PlaySound(Properties.Resources.capture);

            FileUpload upload = new FileUpload(progressStatusListener);
            string nameSuffix = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
            FileUploadResult result = await upload.UploadFile(screenshot.FileStream, string.Format("Screenshot {0}.png", nameSuffix), "image/png");
            OnUploadCompleted(result);
        }

        internal async Task UploadFile(string path)
        {
            GlobalFunctions.PlaySound(Properties.Resources.capture);
            string extension = System.IO.Path.GetExtension(path);
            FileUpload upload = new FileUpload(progressStatusListener);
            Stream fileStream = File.OpenRead(path);
            string mimeType = MimeMapping.Instance.GetMimeType(extension);

            FileUploadResult result = await upload.UploadFile(File.OpenRead(path), System.IO.Path.GetFileName(path), mimeType);
            OnUploadCompleted(result);
        }

        internal async Task UploadImage(System.Drawing.Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Png);

                FileUpload upload = new FileUpload(progressStatusListener);
                string nameSuffix = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
                using (StreamReader reader = new StreamReader(memoryStream))
                {
                    memoryStream.Position = 0;
                    reader.DiscardBufferedData();

                    FileUploadResult result = await upload.UploadFile(memoryStream, string.Format("Copied image {0}.png", nameSuffix), "image/png");
                    OnUploadCompleted(result);
                }
            }
        }

        void IHotkeyListener.OnKeyPress(Key key)
        {
            if (key == (Key)Properties.Settings.Default.WindowedScreenshotHotkeyValue)
            {
                CaptureScreen("window");
            }
            else if (key == (Key)Properties.Settings.Default.RegionalScreenshotHotkeyValue)
            {
                CaptureScreen("region");
            }
            else if (key == (Key)Properties.Settings.Default.FullScreenshotHotkeyValue)
            {
                CaptureScreen("screen");
            }
        }
    }
}
