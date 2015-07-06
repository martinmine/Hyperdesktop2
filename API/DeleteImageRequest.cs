﻿using System.Net.Http;
using System.Threading.Tasks;

namespace hyperdesktop2.API
{
    class DeleteImageRequest
    {
        public async static Task<bool> RequestDeletion(string imageId)
        {
            string uri = string.Format("{0}/{1}/delete", APIConfig.BaseURL, imageId);
            using (HttpClient client = new HttpClient())
            {
                AuthKey key = AuthKey.LoadKey();
                if (key == null)
                    return false;

                client.DefaultRequestHeaders.Add("Authorization", key.Token);
                HttpResponseMessage response = await client.DeleteAsync(uri);

                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
        }
    }
}
