using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Models
{
    [DataContract]
    public class UserSetting : ApplicationSettingsBase
    {
        private static UserSetting current;
        public static UserSetting Current
        {
            get
            {
                if (current == null) current = new UserSetting();
                return current;
            }
        }

        private UserSetting() { }

        [UserScopedSetting()]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        [DataMember(Name = "FirstFolderPath")]
        public ObservableCollection<string> FirstFolderPathList { set => this["FirstFolderPathList" ] = value; get => (ObservableCollection<string>)this["FirstFolderPathList"]; }
        [UserScopedSetting()]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        [DataMember(Name = "SecondFolderPath")]
        public ObservableCollection<string> SecondFolderPathList { set => this["SecondFolderPathList"] = value; get => (ObservableCollection<string>)this["SecondFolderPathList"]; }

        [UserScopedSetting()]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        [DataMember(Name = "Filter")]
        public ObservableCollection<string> FilterList { set => this["FilterList"] = value; get => (ObservableCollection<string>)this["FilterList"]; }

        /// <summary>
        /// 未実装
        /// </summary>
        [UserScopedSetting()]
        [SettingsSerializeAs(SettingsSerializeAs.String)]
        [DataMember(Name = "HashAlgorithm")]
        public string HashAlgorithm { set => this["HashAlgorithm"] = value; get => (string)this["HashAlgorithm"]; }
    }
}
