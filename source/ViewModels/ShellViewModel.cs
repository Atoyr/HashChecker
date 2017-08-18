using HashChecker.Abstract;
using HashChecker.Contexts;
using HashChecker.Events;
using HashChecker.Interfaces;
using HashChecker.Models;
using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HashChecker.ViewModels
{
    public class ShellViewModel : AbstractViewModel
    {
        private StatusBar statusBar;
        public StatusBar StatusBar { private set => SetProperty(ref statusBar, value); get => statusBar; }

        public override void Initialize()
        {
            base.Initialize();
            RegistEventSubscribe();
            StatusBar = new StatusBar { Message = "準備完了" };
        }

        private void RegistEventSubscribe()
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator .GetEvent<StatusBarMessageChangeEvent>().Subscribe(StatusBarMessageChange);
        }

        private void UnregistEventSubscribe()
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<StatusBarMessageChangeEvent>().Unsubscribe(StatusBarMessageChange);
        }

        private void StatusBarMessageChange(IMessageValue value)
        {
            if (StatusBar != null)
            {
                StatusBar.Message = value.Message;
            }
        }
    }
}
