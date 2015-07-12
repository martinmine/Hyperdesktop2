using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;

namespace hyperdesktop2
{
    public static class GlobalFunctions
    {
        public static ImageFormat ExtensionToImageFormat(string extension)
        {
            switch (extension.ToLower())
            {
                case "jpeg":
                case "jpg":
                    return ImageFormat.Jpeg;
                case "png":
                    return ImageFormat.Png;
                default:
                    return ImageFormat.Bmp;
            }
        }

        public static string BmpToBase64(Bitmap bmp, ImageFormat format)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bmp.Save(stream, format);
                Byte[] bytes = stream.ToArray();

                return Convert.ToBase64String(bytes);
            }
        }

        internal static readonly RegistryKey StartupRegistryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

        internal const string StartupKey = "Shikashi Uploader";

        public static void SetRunAtStartup(bool shouldRun)
        {
            if (shouldRun)
                StartupRegistryKey.SetValue(StartupKey, Settings.ExePath);
            else
                StartupRegistryKey.DeleteValue(StartupKey, false);
        }

        public static void PlaySound(UnmanagedMemoryStream file)
        {
            try
            {
                if (Settings.SoundEffects)
                { 
                    using (SoundPlayer soundPlayer = new SoundPlayer(file))
                    {
                        soundPlayer.Play();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Can't find audio file");
            }
        }

        internal static void CheckStartupPath()
        {
            if (!string.IsNullOrEmpty(StartupRegistryKey.GetValue(StartupKey) as string) && (string)StartupRegistryKey.GetValue(StartupKey) != Settings.ExePath)
            {
                SetRunAtStartup(true);
            }
        }
    }
}
