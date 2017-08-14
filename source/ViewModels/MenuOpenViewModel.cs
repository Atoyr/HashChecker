using HashChecker.Abstract;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.ViewModels
{
    class MenuOpenViewModel : AbstractViewModel
    {
        public InteractionRequest<INotification> WindowCloseRequest { get; } = new InteractionRequest<INotification>();

        public DelegateCommand WindowCloseCommand { get; private set; }
        public DelegateCommand FileOpenDialogCommand { get; private set; }

        private string firstFolderPath = string.Empty;
        private string secondFolderPath = string.Empty;
        private string filter = "*.*";

        public string FirstFolderPath { set => SetProperty(ref firstFolderPath,value); get => firstFolderPath; }
        public string SecondFolderPath { set => SetProperty(ref secondFolderPath,value); get => secondFolderPath; }
        public string Filter { set => SetProperty(ref filter, value); get => filter; }
        public ObservableCollection<string> FirstFolderPathHistory { set; private get; }
        public ObservableCollection<string> SecondFolderPathHistory { set; private get; }
        public ObservableCollection<string> FilterHistory { set; private get; }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void CommandInitialize()
        {
            this.WindowCloseCommand = new DelegateCommand(() =>
            {
                this.WindowCloseRequest.Raise(new Notification());
            });
        }

        private void FileOpen()
        {
        }
    }
}
