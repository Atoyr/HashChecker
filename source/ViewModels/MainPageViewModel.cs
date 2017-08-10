using HashChecker.Abstract;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.ViewModels
{
    public class MainPageViewModel : AbstractViewModel
    {
        public InteractionRequest<INotification> OpenForderNotificationRequest { get; } = new InteractionRequest<INotification>();

        public DelegateCommand ShowWindowCommand { get; private set; }

        public override void Initialize()
        {
            base.Initialize();

            this.ShowWindowCommand = new DelegateCommand(() =>
           {
               this.OpenForderNotificationRequest.Raise(new Notification
               {
                   Title = "Hello",
                   Content = "Sample",
               });
           });
        }
    }
}
