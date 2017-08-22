using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Interfaces
{
    public interface IProgressBarPublisher
    {
        void publish(IProgressBarValue value);
    }
}
