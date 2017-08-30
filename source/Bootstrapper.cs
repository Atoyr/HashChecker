using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HashChecker.Views;
using HashChecker.Common;

namespace HashChecker
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var catalog = (ModuleCatalog)this.ModuleCatalog;
            catalog.AddModule(typeof(HashCheckerModule));
        }
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            ViewModelLocationProvider.SetDefaultViewModelFactory(t =>
                this.Container.Resolve(t));
        }

        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
            ((Shell)this.Shell).Show();
            NavigationHelper.RequestNavigate("MainRegion", nameof(MainPageView));
        }

    }
}
