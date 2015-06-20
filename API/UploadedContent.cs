using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace hyperdesktop2.API
{
    [DataContract]
    public class UploadedContent
    {
        [DataMember(Name="key")]
        public string Key { get; set; }

        [DataMember(Name = "fileName")]
        public string FileName { get; set; }
    }
}
