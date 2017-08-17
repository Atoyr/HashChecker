using HashChecker.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Contexts
{
    public class StatusBar : BindableBase ,IProgressBarValue,IMessageValue
    {
        private string message = string.Empty;
        private bool progressBarIsIndeterminate = false;
        private double progressBarMinimum = 0;
        private double progressBarMaximum = 100;
        private double progressBarValue = 0;

        public string Message { set => SetProperty(ref message, value); get => message; }
        public bool ProgressBarIsIndeterminate { set => SetProperty(ref progressBarIsIndeterminate, value); get => progressBarIsIndeterminate; }
        public double ProgressBarMinimum { set => SetProperty(ref progressBarMinimum, value); get => progressBarMinimum; }
        public double ProgressBarMaximum { set => SetProperty(ref progressBarMaximum, value); get => progressBarMaximum; }
        public double ProgressBarValue { set => SetProperty(ref progressBarValue, value); get => progressBarValue; }
    }
}
