using System;
using System.Collections.ObjectModel;
using HashChecker.Util;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HashChecker.Models
{
    public class FileData
    {
        public string FullName { set; get; } = string.Empty;
        public string FullPath { set; get; } = string.Empty;
        public string Path { set; get; } = string.Empty;
        public string Name { set; get; } = string.Empty;
        public string Hash { set; get; } = string.Empty;
        public string Extension { set; get; } = string.Empty;
        public DateTime UpdateDatetime { set; get; } = DateTime.MinValue;
        public long Size { set; get; } = 0L;

        public static IEnumerable<FileData> GetFileEnumerate(string folderPath, string searchPattern)
        {
            return DirectoryUtil.GetFileEnumerate(folderPath,searchPattern, SearchOption.AllDirectories).Select(fi => new FileData
            {
                FullName = fi.FullName,
                FullPath = System.IO.Path.GetDirectoryName(fi.FullName),
                Path = System.IO.Path.GetDirectoryName(fi.FullName).Replace(folderPath, string.Empty),
                Name = System.IO.Path.GetFileName(fi.FullName),
                Extension = fi.Extension,
                UpdateDatetime = fi.LastWriteTime,
                Size = fi.Length
            });
        }
    }
}
