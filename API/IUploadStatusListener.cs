
namespace Shikashi.API
{
    interface IUploadStatusListener
    {
        void ContentUplaoded(UploadedContent content);
        void OnProgress(long uploaded, long total);
    }
}
