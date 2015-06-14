using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Windows.Forms;

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

        [Obsolete]
        public static Boolean str_to_bool(string str)
        {
            return str.ToLower() == "true";
        }

        [Obsolete]
        public static string get_text_inbetween(string input, string a, string b)
        {
            return input.Substring(input.IndexOf(a) + a.Length, input.IndexOf(b) - input.IndexOf(a) - a.Length);
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

        readonly public static RegistryKey startupRegistryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

        public static void CheckRunAtStartup(bool run)
        {
            CreateAppDataFolder();

            if (run)
                startupRegistryKey.SetValue("Hyperdesktop2", Settings.ExePath);
            else
                startupRegistryKey.DeleteValue("Hyperdesktop2", false);
        }

        public static void CreateAppDataFolder()
        {
            if (!Directory.Exists(Settings.AppData))
                Directory.CreateDirectory(Settings.AppData);
        }

        public static void InstallApplicationData()
        {
            if (!File.Exists(Settings.ExePath))
                File.Copy(
                    Application.ExecutablePath,
                    Settings.ExePath
                );

            try
            {
                if (!Directory.Exists(Settings.AppData + "\\sounds\\"))
                {
                    Directory.CreateDirectory(Settings.AppData + "\\sounds\\");
                    foreach (var file in Directory.GetFiles(Environment.CurrentDirectory + "\\sounds"))
                        File.Copy(file, Settings.AppData + "\\sounds\\" + Path.GetFileName(file));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't copy sound files.");
                Console.WriteLine(ex.Message);
            }
        }

        public static void PlaySound(string filePath)
        {
            try
            {
                if (Settings.SoundEffects)
                    using (SoundPlayer soundPlayer = new SoundPlayer("sounds\\" + filePath))
                        soundPlayer.Play();
            }
            catch
            {
                Console.WriteLine("Can't find audio file: " + filePath);
            }
        }
    }
}
