using System;
using System.Runtime.Serialization;

namespace hyperdesktop2.API
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
                Token = Properties.Settings.Default.AuthKey,
                ExpirationTime = Properties.Settings.Default.AuthExpirationTime
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
