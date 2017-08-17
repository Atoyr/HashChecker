using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Interfaces
{
    public interface IProgressBarValue
    {
        bool ProgressBarIsIndeterminate { set; get; }
        double ProgressBarMinimum { set; get; }
        double ProgressBarMaximum { set; get; }
        double ProgressBarValue { set; get; }
    }
}
