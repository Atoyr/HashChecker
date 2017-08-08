using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Util
{
    static class DirectoryUtil
    {
        public static IEnumerable<FileInfo> GetFileEnumerate(string folderPath, string searchPattern, SearchOption searchOption)
        {
            if (Directory.Exists(folderPath))
            {
                return new DirectoryInfo(folderPath).EnumerateFiles(searchPattern, SearchOption.AllDirectories);
            }
            return new List<FileInfo>();
        }
    }
}
