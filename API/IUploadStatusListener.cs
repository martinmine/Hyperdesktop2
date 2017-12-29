
namespace Shikashi.API
{
    interface IUploadStatusListener
    {
        void ContentUplaoded(UploadedContent content, string location);
        void OnProgress(long uploaded, long total);
    }
}
