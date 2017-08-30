using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Enums
{
    public enum MergeResult
    {
        None = 0,
        Exists = 1,
        NotAction = 2,
        NotExists = 91,
        LeftFileNotFound = 92,
        RightFileNotFound = 93,
    }

    public static class MergeResultEx
    {
        public static string GetMergeResult(this MergeResult mergeResult)
        {
            switch (mergeResult)
            {
                case MergeResult.Exists:
                    return "一致";
                case MergeResult.NotExists:
                    return "不一致";
                case MergeResult.LeftFileNotFound:
                    return "左ファイルなし";
                case MergeResult.RightFileNotFound:
                    return "右ファイルなし";
                case MergeResult.None:
                    return "ファイルなし";
                case MergeResult.NotAction:
                    return "未比較";
                default:
                    return string.Empty;
            }
        }
    }
}
