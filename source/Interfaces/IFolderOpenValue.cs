﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Interfaces
{
    public interface IFolderOpenValue
    {
        string FirstFolderPath { set; get; }
        string SecondFolderPath { set; get; }        
        string SearchPattern { set; get; }
    }
}
