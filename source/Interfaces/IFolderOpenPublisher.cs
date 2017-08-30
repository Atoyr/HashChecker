using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Interfaces
{
    public interface IFolderOpenPublisher
    {
        void Publish(IFolderOpenValue value);
    }
}
