using HashChecker.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HashChecker.Contexts
{
    public class StatusBar : BindableBase ,IProgressBarValue,IMessageValue
    {
        private string message = string.Empty;
        private bool progressBarIsIndeterminate = false;
        private double progressBarMinimum = 0;
        private double progressBarMaximum = 100;
        private double progressBarValue = 0;
        private Visibility progressBarVisibility = Visibility.Visible;

        public string Message { set => SetProperty(ref message, value); get => message; }
        public bool IsIndeterminate { set => SetProperty(ref progressBarIsIndeterminate, value); get => progressBarIsIndeterminate; }
        public double Minimum { set => SetProperty(ref progressBarMinimum, value); get => progressBarMinimum; }
        public double Maximum { set => SetProperty(ref progressBarMaximum, value); get => progressBarMaximum; }
        public double Value { set => SetProperty(ref progressBarValue, value); get => progressBarValue; }
        public Visibility ProgressBarVisibility { set => SetProperty(ref progressBarVisibility, value); get => progressBarVisibility; }
    }
}
