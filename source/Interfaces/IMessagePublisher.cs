using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Interfaces
{
    interface IMessagePublisher
    {
        void Publish(IMessageValue value);
    }
}
