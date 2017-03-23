using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Model
{
    public class MergeData
    {
        // 左側
        public string Path { set; get; } = string.Empty;
        public string LeftFullName { set; get; } = string.Empty;
        public string LeftFullPath { set; get; } = string.Empty;
        public string LeftName { set; get; } = string.Empty;
        public string LeftHash { set; get; } = string.Empty;
        public string LeftExtension { set; get; } = string.Empty;
        public DateTime LeftUpdateDatetime { set; get; } = DateTime.MinValue;
        public long LeftSize { set; get; } = 0L;

        // 右側
        public string RightFullName { set; get; } = string.Empty;
        public string RightFullPath { set; get; } = string.Empty;
        public string RightName { set; get; } = string.Empty;
        public string RightHash { set; get; } = string.Empty;
        public string RightExtension { set; get; } = string.Empty;
        public DateTime RightUpdateDatetime { set; get; } = DateTime.MinValue;
        public long RightSize { set; get; } = 0L;

    }
    /// <summary>
    /// MergeDataの重複比較用
    /// 
    /// </summary>
    public class MergeDataPathComparer : IEqualityComparer<MergeData>
    {
        public bool Equals(MergeData x, MergeData y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null | y == null)
                return false;
            else if (
                x.Path == y.Path
                && x.LeftFullName == y.LeftFullName
                && x.RightFullName == y.RightFullName)
                return true;
            else
                return false;
        }

        public int GetHashCode(MergeData obj)
        {
            if (obj == null) return 0;
            string hCode = obj.LeftFullName + obj.RightFullName;
            return hCode.GetHashCode();
        }
    }

}
