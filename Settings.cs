using System;
using System.Runtime.InteropServices;
using System.Text;

namespace hyperdesktop2
{
    public static class Settings
    {
        public const int BuildVersion = 7;
        public const string BuildUrl = "https://raw.githubusercontent.com/TheTarkus/Hyperdesktop2/master/BUILD";
        public const string ReleaseUrl = "https://github.com/TheTarkus/Hyperdesktop2/releases";

        public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Hyperdesktop2\";
        public static readonly string ExePath = AppData + @"hyperdesktop2.exe";
        public static readonly string IniPath = AppData + @"hyperdesktop2.ini";

        public static string SettingsBuild;

        public static string ImgurClientId;

        public static bool SaveScreenshots;
        public static string SaveFolder;
        public static string SaveFormat;
        public static short SaveQuality;

        public static string UploadMethod;
        public static string UploadFormat;

        public static bool RunAtSystemStartup;
        public static bool CopyLinksToClipboard;
        public static bool ShowCursor;
        public static bool SoundEffects;
        public static bool BalloonMessages;
        public static bool LaunchBrowser;
        public static bool EdiScreenshot;

        public static bool AutoDetectScreeResolution;
        public static string ScreenResolution;

        [DllImport("kernel32")]
        static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static string Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, IniPath);
            return value;
        }

        public static string Read(string section, string key)
        {
            StringBuilder builder = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", builder, 255, IniPath);
            return builder.ToString();
        }

        public static string Exists(string section, string key, string value)
        {
            return (Read(section, key).Length > 0) ? Read(section, key) : Write(section, key, value);
        }

        public static void ReadSettings()
        {
            GlobalFunctions.CreateAppDataFolder();
            SettingsBuild = Exists("hyperdesktop2", "build", Convert.ToString(BuildVersion));

            ImgurClientId = Exists("upload", "imgur_client_id", "84c55d06b4c9686");

            SaveScreenshots = bool.Parse(Exists("general", "save_screenshots", "false"));
            SaveFolder = Exists("general", "save_folder", Environment.CurrentDirectory + "\\captures\\");
            SaveFormat = Exists("general", "save_format", "png");
            SaveQuality = Convert.ToInt16(Exists("general", "save_quality", "100"));

            UploadMethod = Exists("upload", "upload_method", "imgur");
            UploadFormat = Exists("upload", "upload_format", "png");

            CopyLinksToClipboard = bool.Parse(Exists("behavior", "copy_links_to_clipboard", "true"));
            ShowCursor = bool.Parse(Exists("behavior", "show_cursor", "false"));
            SoundEffects = bool.Parse(Exists("behavior", "sound_effects", "true"));
            BalloonMessages = bool.Parse(Exists("behavior", "balloon_messages", "true"));
            LaunchBrowser = bool.Parse(Exists("behavior", "launch_browser", "false"));
            EdiScreenshot = bool.Parse(Exists("behavior", "edit_screenshot", "true"));

            ScreenResolution = Exists("screen", "screen_res", ScreenBounds.Reset());
        }

        public static void WriteSettings()
        {
            Write("upload", "imgur_client_id", ImgurClientId);

            Write("general", "save_screenshots", SaveScreenshots.ToString());
            Write("general", "save_folder", SaveFolder);
            Write("general", "save_format", SaveFormat);
            Write("general", "save_quality", SaveQuality.ToString());

            Write("behavior", "copy_links_to_clipboard", CopyLinksToClipboard.ToString());
            Write("behavior", "show_cursor", ShowCursor.ToString());
            Write("behavior", "sound_effects", SoundEffects.ToString());
            Write("behavior", "balloon_messages", BalloonMessages.ToString());
            Write("behavior", "launch_browser", LaunchBrowser.ToString());
            Write("behavior", "edit_screenshot", EdiScreenshot.ToString());

            Write("screen", "screen_res", ScreenResolution);
        }
    }
}
