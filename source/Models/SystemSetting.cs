using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HashChecker.Models
{
    /// <summary>
    /// 未実装
    /// </summary>
    [DataContract]
    public class SystemSetting
    {
       
        [DataMember(Name ="FontSize")]
        public double FontSize { set; get; }
        [DataMember(Name = "FontColor")]
        public Color FontColor { set; get; }

        [DataMember(Name = "Background")]
        public Color Background { set; get; }

        [DataMember(Name = "FileExistsColor")]
        public Color FileExistsColor { set; get; }
        [DataMember(Name = "FileNotExistsColor")]
        public Color FileNotExistsColor { set; get; }
        [DataMember(Name = "LeftFileNotFoundColor")]
        public Color LeftFileNotFoundColor { set; get; }
        [DataMember(Name = "RightFileNotFoundColor")]
        public Color RightFileNotFoundColor { set; get; }
    }
}