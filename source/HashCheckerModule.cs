using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using HashChecker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker
{
    class HashCheckerModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            this.Container.RegisterType<object, MainPageView>(nameof(MainPageView));

        }
    }
}
