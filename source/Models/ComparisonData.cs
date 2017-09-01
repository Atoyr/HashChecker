using HashChecker.Enums;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Models
{
    public class ComparisonData : BindableBase
    {
        public string Path { set; get; } = string.Empty;
        private comparedResult comparedResult = comparedResult.None;
        public comparedResult ComparedResult {
            set
            {
                SetProperty(ref comparedResult, value);
                this.RaisePropertyChanged(nameof(this.comparedResultMessage));
            }
            get => comparedResult; }

        public string comparedResultMessage { get => ComparedResult.GetcomparedResult(); }

        // 左側
        public string LeftFullName { set; get; } = string.Empty;
        public string LeftFullPath { set; get; } = string.Empty;
        public string LeftName { set; get; } = string.Empty;
        private string leftHash = string.Empty;
        public string LeftHash { set => SetProperty(ref leftHash,value); get => leftHash; }
        public string LeftExtension { set; get; } = string.Empty;
        public DateTime? LeftUpdateDatetime { set; get; }
        public long? LeftSize { set; get; } = 0L;

        // 右側
        public string RightFullName { set; get; } = string.Empty;
        public string RightFullPath { set; get; } = string.Empty;
        public string RightName { set; get; } = string.Empty;
        private string rightHash = string.Empty;
        public string RightHash { set => SetProperty(ref rightHash, value); get => rightHash; }
        public string RightExtension { set; get; } = string.Empty;
        public DateTime? RightUpdateDatetime { set; get; }
        public long? RightSize { set; get; } = 0L;

        public void UpdateComparedResult()
        {
            if(!File.Exists(LeftFullName) && !File.Exists(RightFullName))
            {
                ComparedResult = comparedResult.None;
                return;
            }
            if (!File.Exists(LeftFullName))
            {
                ComparedResult = comparedResult.LeftFileNotFound;
                return;
            }
            if (!File.Exists(RightFullName))
            {
                ComparedResult = comparedResult.RightFileNotFound;
                return;
            }
            if (!string.IsNullOrEmpty(LeftHash) && !string.IsNullOrEmpty(RightHash))
            {
                if(LeftHash == RightHash)
                {
                    ComparedResult = comparedResult.Exists;
                }
                else
                {
                    ComparedResult = comparedResult.NotExists;
                }
                return;
            }
            ComparedResult = comparedResult.NotAction;
        }
    }
    /// <summary>
    /// ComparisonDataの重複比較用
    /// 
    /// </summary>
    public class ComparisonDataPathComparer : IEqualityComparer<ComparisonData>
    {
        public bool Equals(ComparisonData x, ComparisonData y)
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

        public int GetHashCode(ComparisonData obj)
        {
            if (obj == null) return 0;
            string hCode = obj.LeftFullName + obj.RightFullName;
            return hCode.GetHashCode();
        }
    }

}
