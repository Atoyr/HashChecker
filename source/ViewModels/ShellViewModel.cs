using HashChecker.Abstract;
using HashChecker.Models;
using Prism.Commands;
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
        private ICommand openCommand;
        public ICommand OpenCommand { set => SetProperty(ref openCommand, value); get => openCommand; }

        public InteractionRequest<OpenForderNotification> OpenForderNotificationRequest { get; } = new InteractionRequest<OpenForderNotification>();

        public override void Initialize()
        {
            base.Initialize();
            OpenCommand = new DelegateCommand(() => this.OpenForderNotificationExecute());
        }

        private void OpenForderNotificationExecute()
        {
            this.OpenForderNotificationRequest.Raise(new OpenForderNotification { Title = "aaaa" });
        }
    }
}
