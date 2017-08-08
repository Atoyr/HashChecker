using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Models
{
    public class OpenForderNotification : Notification
    {
        public string FirstFolderPath { set; get; }
        public string SecondFolderPath { set; get; }
    }
}
