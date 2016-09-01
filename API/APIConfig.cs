namespace Shikashi.API
{
    class APIConfig
    {
        private static string baseDomain = "localhost:8080";
        private static string hostDomain = "labs.shikashi.me";

        private static string GetURL(string host)
        {
            //if (Shikashi.Properties.Settings.Default.SSLEnabled)
            //    return string.Format("https://{0}", host);
            //else
                return string.Format("http://{0}", host);
        }

        internal static string BaseURL
        {
            get
            {
                return GetURL(baseDomain);
            }
        }

        internal static string HostURL
        {
            get
            {
                return GetURL(hostDomain);
            }
        }
    }
}
