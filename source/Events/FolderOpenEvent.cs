using HashChecker.Interfaces;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HashChecker.Events
{
    public class FolderOpenEvent : PubSubEvent<IFolderOpenValue>
    {
    }
}