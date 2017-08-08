using Microsoft.Practices.ServiceLocation;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Common
{
    public static class NavigationHelper
    {
        public static void LoadModule(string moduleName)
        {
            var moduleManager = ServiceLocator.Current.GetInstance<IModuleManager>();
            moduleManager.LoadModule(moduleName);
        }

        public static void RequestNavigate(string regionName,string source)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.RequestNavigate(regionName, source);
        }

        public static void RequestNavigate(string regionName,string source, NavigationParameters param)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.RequestNavigate(regionName, source,param);
        }

        public static void NavigateGoBack(string regionName)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            if (regionManager.Regions[regionName].NavigationService.Journal.CanGoBack)
            {
                regionManager.Regions[regionName].NavigationService.Journal.GoBack();
            }
        }
    }
}
