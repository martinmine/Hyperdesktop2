using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shikashi.API
{
    class DeleteImageRequest
    {
        public async static Task<bool> RequestDeletion(string imageId)
        {
            try {
                string uri = string.Format("{0}/{1}/delete", APIConfig.BaseURL, imageId);
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    AuthKey key = AuthKey.LoadKey();
                    if (key == null)
                        return false;

                    client.DefaultRequestHeaders.Add("Authorization", key.Token);
                    HttpResponseMessage response = await client.DeleteAsync(uri);

                    return response.StatusCode == System.Net.HttpStatusCode.NoContent;
                }
            }
            catch (Exception e)
            {
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "error.txt", e.ToString());
                return false;
            }
        }
    }
}
