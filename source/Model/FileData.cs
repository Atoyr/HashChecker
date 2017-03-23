using System;

namespace HashChecker.Model
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
    }
}
