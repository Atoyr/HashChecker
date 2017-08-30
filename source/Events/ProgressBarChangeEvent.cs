using HashChecker.Interfaces;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Events
{
    public class ProgressBarChangeEvent : PubSubEvent<IProgressBarValue>
    {
    }
}
