using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Anaheim.Utility;

namespace HashChecker
{
    public static class GridData
    {
        public static ObservableCollection<FileData> GetFileList(string folderPath, string searchPattern)
        {
            var files = new DirectoryInfo(folderPath).EnumerateFiles(searchPattern, SearchOption.AllDirectories);
            var returnCollection = new ObservableCollection<FileData>();

            foreach (FileInfo fi in files)
            {
                returnCollection.Add(new FileData {
                    FullName = fi.FullName,
                    FullPath = Path.GetDirectoryName(fi.FullName),
                    Path = Path.GetDirectoryName(fi.FullName).Replace(folderPath,string.Empty),
                    Name = Path.GetFileName(fi.FullName),
                    Extension = fi.Extension,
                    UpdateDatetime = fi.LastWriteTime,
                    Size = fi.Length
                });
            }

            return returnCollection;
        }

        public static ObservableCollection<MergeData> GetMergeList(string leftFolderPath, string rightFolderPath, string searchPattern)
        {
            var leftFileList = GetFileList(leftFolderPath, searchPattern);
            var rightFileList = GetFileList(rightFolderPath, searchPattern);

            // 左外部結合と右外部結合を取得、マージする
            var leftOuter = FileDataLeftOuterJoin(leftFileList, rightFileList);
            var rightOuter = FileDataRightOuterJoin(leftFileList, rightFileList);
            return new ObservableCollection<MergeData>(leftOuter.Union(rightOuter, new MergeDataPathComparer()));
        }

        private static IEnumerable<MergeData> FileDataLeftOuterJoin(IEnumerable<FileData> L, IEnumerable<FileData> R)
        {
            return
                from l in L
                join r in R
                on new { l.Path, l.Name } equals new { r.Path, r.Name }
                into temp
                from r in temp.DefaultIfEmpty(new FileData())
                select new MergeData
                {
                    Path = l.Path,
                    LeftFullName = l.FullName,
                    LeftFullPath = l.FullPath,
                    LeftName = l.Name,
                    LeftHash = l.Hash,
                    LeftExtension = l.Extension,
                    LeftUpdateDatetime = l.UpdateDatetime,
                    LeftSize = l.Size,

                    RightFullName = r == null ? string.Empty : r.FullName,
                    RightFullPath = r == null ? string.Empty : r.FullPath,
                    RightName = r == null ? string.Empty : r.Name,
                    RightHash = r == null ? string.Empty : r.Hash,
                    RightExtension = r == null ? string.Empty : r.Extension,
                    RightUpdateDatetime = r == null ? DateTime.MinValue : r.UpdateDatetime,
                    RightSize = r == null ? 0L : r.Size
                };
        }

        private static IEnumerable<MergeData> FileDataRightOuterJoin(IEnumerable<FileData> L, IEnumerable<FileData> R)
        {
            return
                from r in R
                join l in L
                on new { r.Path, r.Name } equals new { l.Path, l.Name }
                into temp
                from l in temp.DefaultIfEmpty(new FileData())
                select new MergeData
                {
                    Path = r.Path,
                    LeftFullName = l == null ? string.Empty : l.FullName,
                    LeftFullPath = l == null ? string.Empty : l.FullPath,
                    LeftName = l == null ? string.Empty : l.Name,
                    LeftHash = l == null ? string.Empty : l.Hash,
                    LeftExtension = l == null ? string.Empty : l.Extension,
                    LeftUpdateDatetime = l == null ? DateTime.MinValue : l.UpdateDatetime,
                    LeftSize = l == null ? 0L : l.Size,

                    RightFullName = r.FullName,
                    RightFullPath = r.FullPath,
                    RightName = r.Name,
                    RightHash = r.Hash,
                    RightExtension = r.Extension,
                    RightUpdateDatetime = r.UpdateDatetime,
                    RightSize = r.Size
                };
        }
 
        private static void AddHashValue<T>(FileData fileData, T algorithm)
            where T : HashAlgorithm, new()
        {
            fileData.Hash = Hash.ConvertHashString(Hash.GetHashFromFile(fileData.FullName, algorithm));
        }
    }
}
