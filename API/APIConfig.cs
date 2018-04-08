namespace Shikashi.API
{
    class APIConfig
    {
        private static string baseDomain = "api.shikashi.me";
        private static string hostDomain = "i.shikashi.me";

        private static string GetURL(string host)
        {
            return Properties.Settings.Default.SSLEnabled ? $"https://{host}" : $"http://{host}";
        }

        internal static string BaseURL => GetURL(baseDomain);

        internal static string HostURL => GetURL(hostDomain);
    }
}
