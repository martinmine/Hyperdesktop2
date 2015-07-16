using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Shikashi.API
{
    class LoginProvider
    {
        private string email;
        private string password;

        public LoginProvider(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public async Task<LoginResult> PerformLogin()
        {
            string uri = string.Format("{0}/login", APIConfig.BaseURL);

            try 
            { 
                using (HttpClient client = new HttpClient())
                {
                    var formData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("email", email),
                        new KeyValuePair<string, string>("password", password),
                        new KeyValuePair<string, string>("client", "Shikashi-Win32")
                    };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(formData);
                    using (HttpResponseMessage response = await client.PostAsync(new Uri(uri), content))
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            return LoginResult.InvalidCredentials;
                        else if (response.StatusCode != HttpStatusCode.OK)
                            return LoginResult.UnknownError;

                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(AuthKey));
                        AuthKey key = jsonSerializer.ReadObject(await response.Content.ReadAsStreamAsync()) as AuthKey;

                        if (key == null)
                            return LoginResult.UnknownError;

                        Properties.Settings.Default.AuthKey = key.Token;
                        Properties.Settings.Default.AuthExpirationTime = key.ExpirationTime;
                        Properties.Settings.Default.Save();

                        return LoginResult.Success;
                    }
                }
            }
            catch (WebException)
            {
                return LoginResult.UnknownError;
            }
        }
    }

    enum LoginResult
    {
        Success,
        InvalidCredentials,
        UnknownError
    }
}
