using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Interfaces
{
    interface IMessageProvider : INotifyPropertyChanged
    {
        IMessageValue Value { set; get; }
    }
}
