using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;

namespace hyperdesktop2
{
    class Imgur
    {
        public static WebClient WebClient = new WebClient();
        public static Boolean upload(Bitmap bmp)
        {
            try
            {
                var postData = new NameValueCollection();

                var imageData = GlobalFunctions.BmpToBase64(bmp, GlobalFunctions.ExtensionToImageFormat(Settings.UploadFormat));
                postData.Add("image", imageData);

                WebClient.Headers.Add("Authorization", "Client-ID " + Settings.ImgurClientId);
                WebClient.UploadValuesAsync(
                    new Uri("https://api.imgur.com/3/image/"),
                    "POST",
                    postData
                );

                WebClient.Headers.Remove("Authorization");
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public static Boolean delete(string delete_hash)
        {
            try
            {
                var webClient = new WebClient();

                webClient.Headers.Add("Authorization", "Client-ID " + Settings.ImgurClientId);
                webClient.UploadData(
                    new Uri("https://api.imgur.com/3/image/" + delete_hash),
                    "DELETE",
                    new Byte[] { 0x0 }
                );

                webClient.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
