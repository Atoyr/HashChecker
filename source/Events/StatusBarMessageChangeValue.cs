using HashChecker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Events
{
    public class StatusBarMessageChangeValue : IMessageValue
    {
        public string Message { get; set; }
    }
}
