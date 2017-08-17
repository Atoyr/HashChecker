using HashChecker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Events
{
    public class FolderOpenValue : IFolderOpenValue
    {
        public string FirstFolderPath { get; set; }
        public string SecondFolderPath { get; set; }
        public string SearchPattern { get; set; }
    }
}
