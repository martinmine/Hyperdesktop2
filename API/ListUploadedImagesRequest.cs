using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Shikashi.API
{
    class ListUploadedImagesRequest
    {
        private static readonly UploadedContent[] EmptyList = new UploadedContent[] { };

        internal async static Task<UploadedContent[]> GetImages()
        {
            string uri = string.Format("{0}/account/uploads", APIConfig.BaseURL);
            using (HttpClient client = new HttpClient())
            {
                AuthKey key = AuthKey.LoadKey();
                if (key == null)
                    return EmptyList;

                client.DefaultRequestHeaders.Add("Authorization", key.Token);
                client.DefaultRequestHeaders.ExpectContinue = false;
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return EmptyList;

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(UploadedContent[]));
                return jsonSerializer.ReadObject(await response.Content.ReadAsStreamAsync()) as UploadedContent[];
            }
        }
    }
}
