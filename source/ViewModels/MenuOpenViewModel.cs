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
    class MenuOpenViewModel : AbstractViewModel
    {
        public InteractionRequest<INotification> WindowCloseRequest { get; } = new InteractionRequest<INotification>();

        public DelegateCommand WindowCloseCommand { get; private set; }

        private string text = "hogehoge";
        public string Text { set => SetProperty(ref text, value); get => text; }

        public override void Initialize()
        {
            base.Initialize();
            this.WindowCloseCommand = new DelegateCommand(() =>
            {
                this.WindowCloseRequest.Raise(new Notification());
            });
        }
    }
}
