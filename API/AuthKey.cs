using System;
using System.Runtime.Serialization;

namespace Shikashi.API
{
    [DataContract]
    class AuthKey
    {
        [DataMember(Name="key")]
        public string Token { get; set; }

        [DataMember(Name="expirationTime")]
        public int ExpirationTime {get; set; }

        private static DateTime epoche = new DateTime(1970, 1, 1);

        public static AuthKey LoadKey()
        {
            AuthKey key = new AuthKey() 
            {
                Token = Shikashi.Properties.Settings.Default.AuthKey,
                ExpirationTime = Shikashi.Properties.Settings.Default.AuthExpirationTime
            };

            if (string.IsNullOrEmpty(key.Token) || key.ExpirationTime <= GetUnixTimestamp())
                return null;

            return key;
        }

        private static int GetUnixTimestamp()
        {
            return (int)(DateTime.UtcNow.Subtract(epoche)).TotalSeconds;
        }
    }
}
