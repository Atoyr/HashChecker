using HashChecker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HashChecker.Events
{
    public class ProgressBarChangeValue : IProgressBarValue
    {
        public bool IsIndeterminate { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        public double Value { get; set; }
        public Visibility ProgressBarVisibility { get; set; }
    }
}
