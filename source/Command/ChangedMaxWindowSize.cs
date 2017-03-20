using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HashChecker.Command
{
    class ChangedMaxUsuallyBidirectionalWindowSize : ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (!IsWindow(parameter)) return false;
            var targetWindow = parameter as Window;
            // 最大と最小を切り替えられるパターン
            return targetWindow.ResizeMode == ResizeMode.CanResize
                || targetWindow.ResizeMode == ResizeMode.CanResizeWithGrip;
        }

        public void Execute(object parameter)
        {
            if (!IsWindow(parameter)) return;
            var targetWindow = parameter as Window;
            targetWindow.WindowState = targetWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private bool IsWindow(object parameter) => parameter.GetType().Equals(typeof(Window));
    }
}
