using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Enums
{
    public enum comparedResult
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
        public static string GetcomparedResult(this comparedResult mergeResult)
        {
            switch (mergeResult)
            {
                case comparedResult.Exists:
                    return "一致";
                case comparedResult.NotExists:
                    return "不一致";
                case comparedResult.LeftFileNotFound:
                    return "左ファイルなし";
                case comparedResult.RightFileNotFound:
                    return "右ファイルなし";
                case comparedResult.None:
                    return "ファイルなし";
                case comparedResult.NotAction:
                    return "未比較";
                default:
                    return string.Empty;
            }
        }
    }
}
