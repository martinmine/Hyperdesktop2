using System.Runtime.Serialization;

namespace Shikashi.API
{
    [DataContract]
    public class UploadedContent
    {
        [DataMember(Name="key")]
        public string Key { get; set; }

        [DataMember(Name = "fileName")]
        public string FileName { get; set; }

        [DataMember(Name = "deleteKey")]
        public string DeleteKey { get; set; }
    }
}
