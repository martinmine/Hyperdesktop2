using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Media;

namespace Shikashi
{
    public static class GlobalFunctions
    {
        internal static readonly RegistryKey StartupRegistryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
        internal const string StartupKey = "Shikashi Uploader";

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

        public static void SetRunAtStartup(bool shouldRun)
        {
            if (shouldRun)
                StartupRegistryKey.SetValue(StartupKey, GetExePath());
            else
                StartupRegistryKey.DeleteValue(StartupKey, false);
        }

        public static void PlaySound(UnmanagedMemoryStream file)
        {
            try
            {
                if (Properties.Settings.Default.SoundEffects)
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
            if (!string.IsNullOrEmpty(StartupRegistryKey.GetValue(StartupKey) as string) && (string)StartupRegistryKey.GetValue(StartupKey) != GetExePath())
            {
                SetRunAtStartup(true);
            }
        }

        private static string GetExePath()
        {
            return Process.GetCurrentProcess().MainModule.FileName;
        }
    }
}
