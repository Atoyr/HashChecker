using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace HashChecker.Models
{
    public static class BindingGridData
    {
        /// <summary>
        /// ファイル一覧
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public static ObservableCollection<FileData> GetFileList(string folderPath, string searchPattern)
        {
            var returnCollection = new ObservableCollection<FileData>();
            if (Directory.Exists(folderPath))
            {
                var files = new DirectoryInfo(folderPath).EnumerateFiles(searchPattern, SearchOption.AllDirectories);
                returnCollection.AddRange(files.Select(fi => new FileData
                {
                    FullName = fi.FullName,
                    FullPath = Path.GetDirectoryName(fi.FullName),
                    Path = Path.GetDirectoryName(fi.FullName).Replace(folderPath, string.Empty),
                    Name = Path.GetFileName(fi.FullName),
                    Extension = fi.Extension,
                    UpdateDatetime = fi.LastWriteTime,
                    Size = fi.Length
                }));
            }

            return returnCollection;
        }

        /// <summary>
        /// フォルダ比較結果
        /// </summary>
        /// <param name="leftFolderPath"></param>
        /// <param name="rightFolderPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public static IEnumerable<MergeData> GetMergeList(string leftFolderPath, string rightFolderPath, string searchPattern)
        {
            var leftFileList = FileData.GetFileEnumerate(leftFolderPath, searchPattern);
            var rightFileList = FileData.GetFileEnumerate(rightFolderPath, searchPattern);

            // 左外部結合と右外部結合を取得、マージする
            var leftOuter = FileDataLeftOuterJoin(leftFileList, rightFileList);
            var rightOuter = FileDataRightOuterJoin(leftFileList, rightFileList);
            return leftOuter.Union(rightOuter, new MergeDataPathComparer());
        }

        /// <summary>
        /// 左結合
        /// </summary>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 右結合
        /// </summary>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <returns></returns>
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
            //fileData.Hash = Hash.ConvertHashString(Hash.GetHashFromFile(fileData.FullName, algorithm));
        }
    }
}
