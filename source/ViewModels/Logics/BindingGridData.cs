using HashChecker.Models;
using HashChecker.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HashChecker.Logics
{
    public static class BindingGridData
    {
        /// <summary>
        /// ファイル一覧
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public static IEnumerable<FileData> GetFileList(string folderPath, string searchPattern)
        {
            var returnCollection = new List<FileData>();
            if (Directory.Exists(folderPath))
            {
                var files = new DirectoryInfo(folderPath).EnumerateFiles(searchPattern, SearchOption.AllDirectories);
                returnCollection.AddRange(files.Select(fi => new FileData
                {
                    FullName = fi.FullName,
                    FullPath = Path.GetDirectoryName(fi.FullName),
                    Path = fi.FullName.Replace(folderPath, string.Empty),
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
        public static IEnumerable<ComparisonData> GetComparisonList(string leftFolderPath, string rightFolderPath, string searchPattern)
        {
            try
            {
                var leftFileList = FileData.GetFileEnumerate(leftFolderPath, searchPattern);
                var rightFileList = FileData.GetFileEnumerate(rightFolderPath, searchPattern);

                // 左外部結合と右外部結合を取得、マージする
                var leftOuter = FileDataLeftOuterJoin(leftFileList, rightFileList);
                var rightOuter = FileDataRightOuterJoin(leftFileList, rightFileList);
                return leftOuter.Union(rightOuter, new ComparisonDataPathComparer());
            }
            catch(Exception e)
            {
                System.Diagnostics.EventLog.WriteEntry(
                    e.Source, e.Message,
                    System.Diagnostics.EventLogEntryType.Error);
                return new ObservableCollection<ComparisonData>();
            }
        }

        private static IEnumerable<ComparisonData> FileDataOuterJoin(IEnumerable<FileData> L, IEnumerable<FileData> R)
        {
            return new List<ComparisonData>();
        }

        /// <summary>
        /// 左結合
        /// </summary>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        private static IEnumerable<ComparisonData> FileDataLeftOuterJoin(IEnumerable<FileData> L, IEnumerable<FileData> R)
        {
            return
                from l in L
                join r in R
                on new { l.Path, l.Name } equals new { r.Path, r.Name }
                into temp
                from r in temp.DefaultIfEmpty(new FileData())
                select new ComparisonData
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
                    RightUpdateDatetime = r.UpdateDatetime,
                    RightSize = r.Size,
                    ComparedResult = r == null ? Enums.comparedResult.RightFileNotFound : Enums.comparedResult.NotAction
                };
        }

        /// <summary>
        /// 右結合
        /// </summary>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        private static IEnumerable<ComparisonData> FileDataRightOuterJoin(IEnumerable<FileData> L, IEnumerable<FileData> R)
        {
            return
                from r in R
                join l in L
                on new { r.Path, r.Name } equals new { l.Path, l.Name }
                into temp
                from l in temp.DefaultIfEmpty(new FileData())
                select new ComparisonData
                {
                    Path = r.Path,
                    LeftFullName = l == null ? string.Empty : l.FullName,
                    LeftFullPath = l == null ? string.Empty : l.FullPath,
                    LeftName = l == null ? string.Empty : l.Name,
                    LeftHash = l == null ? string.Empty : l.Hash,
                    LeftExtension = l == null ? string.Empty : l.Extension,
                    LeftUpdateDatetime = l.UpdateDatetime,
                    LeftSize = l.Size,

                    RightFullName = r.FullName,
                    RightFullPath = r.FullPath,
                    RightName = r.Name,
                    RightHash = r.Hash,
                    RightExtension = r.Extension,
                    RightUpdateDatetime = r.UpdateDatetime,
                    RightSize = r.Size,
                    ComparedResult = l == null ? Enums.comparedResult.LeftFileNotFound : Enums.comparedResult.NotAction
                };
        }

        private static void AddHashValue<T>(FileData fileData, T algorithm)
            where T : HashAlgorithm, new()
        {
            fileData.Hash = HashUtil.ConvertHashString(HashUtil.GetHashFromFile(fileData.FullName, algorithm));
        }
        private static void AddHashValue<T>(ComparisonData ComparisonData, T algorithm)
            where T : HashAlgorithm, new()
        {
            if (File.Exists(ComparisonData.LeftFullName)) ComparisonData.LeftHash = HashUtil.ConvertHashString(HashUtil.GetHashFromFile(ComparisonData.LeftFullName, algorithm));
            if (File.Exists(ComparisonData.RightFullName)) ComparisonData.RightHash = HashUtil.ConvertHashString(HashUtil.GetHashFromFile(ComparisonData.RightFullName, algorithm));
        }
        public async static Task ExecuteHashComparisonAsync(IEnumerable<ComparisonData> comparisonDatas)
        {
            await ExecuteHashComparisonAsync(comparisonDatas,new Action<int>((i) => { }), new Action<int>((i) => { }), new Action<int>((i) => { }), new Action(() => { }));
        }

        public static Task ExecuteHashComparisonAsync(IEnumerable<ComparisonData> comparisonDatas,Action<int> initialAction,Action<int> beginAction,Action<int> endAction ,Action finalyAction)
        {
            return Task.Run(() =>
            {
                int maxValue = comparisonDatas.Count();
                initialAction(maxValue);
                int index = 0;
                foreach (ComparisonData md in comparisonDatas)
                {
                    beginAction(index);
                    // アルゴリズム変えるときはここを変える
                    // Configファイルにもちたかったけど・・・
                    var algo = HashAlgorithm.Create("SHA-1") as SHA1CryptoServiceProvider;
                    AddHashValue(md, algo);
                    md.UpdateComparedResult();
                    ++index;
                    endAction(index);
                }
                finalyAction();
            });
        }
    }
}
