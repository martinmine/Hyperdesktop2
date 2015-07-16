using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Shikashi
{
    public static class Settings
    {
        public const string BuildUrl = "https://raw.githubusercontent.com/TheTarkus/Hyperdesktop2/master/BUILD";
        public const string ReleaseUrl = "https://github.com/TheTarkus/Hyperdesktop2/releases";

        public static readonly string ContextRoot = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string ExePath = ContextRoot + "Shikashi Uploader.exe";
    }
}
