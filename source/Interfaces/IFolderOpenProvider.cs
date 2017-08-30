using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Interfaces
{
    public interface IFolderOpenProvider : INotifyPropertyChanged
    {
        IFolderOpenValue Value { get; }
    }
}
