using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Models
{
    [DataContract]
    public class UserSetting
    {
        [DataMember(Name = "FirstFolderPath")]
        public List<string> FirstFolderPath { set; get; }
        [DataMember(Name = "SecondFolderPath")]
        public List<string> SecondFolderPath { set; get; }

        public List<string> Filter { set; get; }
    }
}
