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

        /// <summary>
        /// メインウィンドウRegionのNavigation
        /// </summary>
        /// <param name="regionName">対象Region</param>
        /// <param name="source">移動先</param>
        public static void RequestNavigate(string regionName,string source)
        {
            RequestNavigate(ServiceLocator.Current.GetInstance<IRegionManager>(), regionName, source);
        }

        /// <summary>
        /// メインウィンドウRegionのNavigation
        /// </summary>
        /// <param name="regionManager">Navigationを実行するRegionManager</param>
        /// <param name="regionName">対象Region</param>
        /// <param name="source">移動先</param>
        public static void RequestNavigate(IRegionManager regionManager,string regionName ,string source)
        {
            if(regionManager != null && !string.IsNullOrEmpty(regionName))
            {
                regionManager.RequestNavigate(regionName, source);
            }
        }

        public static void RequestNavigate(string regionName,string source, NavigationParameters param)
        {
            RequestNavigate(ServiceLocator.Current.GetInstance<IRegionManager>(), regionName, source, param);
        }

        public static void RequestNavigate(IRegionManager regionManager, string regionName, string source, NavigationParameters param)
        {
            if (regionManager != null && !string.IsNullOrEmpty(regionName))
            {
                regionManager.RequestNavigate(regionName, source, param);
            }
        }

        public static void NavigateGoBack(string regionName)
        {
            NavigateGoBack(ServiceLocator.Current.GetInstance<IRegionManager>(),regionName);
        }

        public static void NavigateGoBack(IRegionManager regionManager, string regionName)
        {
            if (regionManager != null && !string.IsNullOrEmpty(regionName))
            {
                if (regionManager.Regions[regionName].NavigationService.Journal.CanGoBack)
                {
                    regionManager.Regions[regionName].NavigationService.Journal.GoBack();
                }
            }
        }

        //public static void 
    }
}
