using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Shikashi.API
{
    class FileUpload
    {
        private IUploadStatusListener listener;
        private HttpClient client;

        public FileUpload(IUploadStatusListener listener)
        {
            this.listener = listener;

            ProgressMessageHandler progressHandler = new ProgressMessageHandler();
            progressHandler.HttpSendProgress += (o, sender) => { listener.OnProgress(sender.BytesTransferred, sender.TotalBytes.Value); };

            client = HttpClientFactory.Create(progressHandler);
        }

        internal async Task<FileUploadResult> UploadFile(Stream data, string fileName, string contentType, long size)
        {
            string uri = string.Format("{0}/upload", APIConfig.BaseURL);
            string responseString = null;

            try
            {
                client.DefaultRequestHeaders.ExpectContinue = false;
                AuthKey key = AuthKey.LoadKey();
                if (key == null)
                    return FileUploadResult.NotAuthorized;

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", key.Token);
                client.DefaultRequestHeaders.Add("UploadFileSize", size.ToString());

                using (MultipartFormDataContent content = new MultipartFormDataContent())
                {
                    content.Add(CreateFileContent(data, fileName, contentType));

                    using (HttpResponseMessage response = await client.PostAsync(uri, content))
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(UploadedContent));
                        responseString = await response.Content.ReadAsStringAsync();
                        UploadedContent upload = jsonSerializer.ReadObject(await response.Content.ReadAsStreamAsync()) as UploadedContent;

                        File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "responses.txt", "HTTP Response: " + response.StatusCode + Environment.NewLine);

                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            return FileUploadResult.InvalidCredentials;

                        if (response.StatusCode == System.Net.HttpStatusCode.OK && upload != null)
                        {
                            listener.ContentUplaoded(upload);
                            return FileUploadResult.OK;
                        }

                        if (response.StatusCode == HttpStatusCode.BadRequest)
                            return FileUploadResult.FileTooLarge;

                        File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "error_responses.txt", responseString + Environment.NewLine);
                        return FileUploadResult.Failed;
                    }
                }
            }
            catch (Exception e)
            {
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "error.txt", e.ToString() + Environment.NewLine);

                if (responseString != null)
                    File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "error_responses.txt", responseString + Environment.NewLine);
                return FileUploadResult.Failed;
            }
        }

        void progressHandler_HttpSendProgress(object sender, HttpProgressEventArgs e)
        {
            listener.OnProgress(e.BytesTransferred, e.TotalBytes.Value);
        }

        private static StreamContent CreateFileContent(Stream fileStream, string fileName, string contentType)
        {
            StreamContent fileContentStream = new StreamContent(fileStream);
            fileContentStream.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"files\"",
                FileName = "\"" + fileName + "\""
            };

            fileContentStream.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return fileContentStream;
        }
    }

    enum FileUploadResult
    {
        OK,
        Failed,
        InvalidCredentials,
        NotAuthorized,
        FileTooLarge
    }
}
