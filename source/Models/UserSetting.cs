using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Models
{
    [DataContract]
    public class UserSetting
    {
        [DataMember(Name = "FirstFolderPath")]
        public List<string> FirstFolderPathList { set; get; }
        [DataMember(Name = "SecondFolderPath")]
        public List<string> SecondFolderPathList { set; get; }

        [DataMember(Name = "Filter")]
        public List<string> FilterList { set; get; }

        [DataMember(Name = "HashAlgorithm")]
        public HashAlgorithm HashAlgorithm { set; get; }
    }
}
