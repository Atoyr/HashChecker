using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HashChecker.Interfaces
{
    public interface IProgressBarValue
    {
        bool IsIndeterminate { set; get; }
        double Minimum { set; get; }
        double Maximum { set; get; }
        double Value { set; get; }
        Visibility ProgressBarVisibility { set; get; }
    }
}
