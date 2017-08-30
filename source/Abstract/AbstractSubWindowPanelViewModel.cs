using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Abstract
{
    public class AbstractSubWindowPanelViewModel : AbstractRegionViewModel
    {
        public IRegionManager SubWindowRegionManager { get; set; }
    }
}
