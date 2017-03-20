using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace HashChecker.View
{
    class BindingData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            field = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal class WindowStatus : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
            {
                field = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            // TODO:ウィンドウの表示文字設定
            private string WindowSizeIdentifier;
        }
    }
}
