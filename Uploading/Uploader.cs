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

        internal Bitmap EditScreenshot(Bitmap bmp)
        {
            if (!Properties.Settings.Default.EditScreenshot)
                return null;

            Edit edit = new Edit(bmp);
            edit.ShowDialog();

            return edit.Result;
        }

        internal void CaptureScreen(string type)
        {
            Bitmap bmp = null;

            switch (type)
            {
                case "screen":
                    bmp = ScreenCapture.CaptureScreen(Properties.Settings.Default.ShowCursor);
                    break;

                case "window":
                    bmp = ScreenCapture.Window(Properties.Settings.Default.ShowCursor);
                    break;

                default:
                    if (snipperOpen)
                        return;

                    snipperOpen = true;

                    try
                    {
                        System.Drawing.Rectangle rect = Snipper.GetRegion();

                        if (rect == new System.Drawing.Rectangle(0, 0, 0, 0))
                            return;

                        bmp = ScreenCapture.CaptureRegion(rect);
                    }
                    finally
                    {
                        snipperOpen = false;
                    }

                    break;
            }
            WorkImage(bmp, true);
        }

        internal async void WorkImage(Bitmap bmp, bool edit = false)
        {
            try
            {
                GlobalFunctions.PlaySound(Properties.Resources.capture);

                if (Properties.Settings.Default.EditScreenshot && edit)
                    bmp = EditScreenshot(bmp);

                if (bmp == null)
                {
                    return;
                }


                using (MemoryStream memoryStream = new MemoryStream())
                {
                    bmp.Save(memoryStream, ImageFormat.Png);
                    FileUpload upload = new FileUpload(progressStatusListener);
                    string nameSuffix = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
                    using (StreamReader reader = new StreamReader(memoryStream))
                    {
                        memoryStream.Position = 0;
                        reader.DiscardBufferedData();

                        FileUploadResult result = await upload.UploadFile(memoryStream, string.Format("Screenshot {0}.png", nameSuffix), "image/png");
                        OnUploadCompleted(result);
                    }
                }
            }
            finally
            {
                if (bmp != null)
                    bmp.Dispose();
                GC.Collect();
            }
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
