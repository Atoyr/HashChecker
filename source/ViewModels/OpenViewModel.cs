using HashChecker.Abstract;
using HashChecker.Models;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.ViewModels
{
    public class OpenViewModel : AbstractRequestAwareViewModel
    {
        private INotification notification;
        public override INotification Notification
        {
            get { return this.notification; }
            set
            {
                this.notification = value;
                // initialize
                this.firstFolderPath = string.Empty;
                this.secondFolderPath = string.Empty;
            }
        }

        private string firstFolderPath;
        public string FirstFolderPath { get => this.firstFolderPath; set => this.SetProperty(ref this.firstFolderPath, value); }
        private string secondFolderPath;
        public string SecondFolderPath { get => this.secondFolderPath; set => this.SetProperty(ref this.secondFolderPath, value); }

        public DelegateCommand OKCommand { get; }

        public OpenViewModel()
        {
            this.OKCommand = new DelegateCommand(() =>
            {
                ((OpenForderNotification)this.Notification).FirstFolderPath = this.FirstFolderPath;
                ((OpenForderNotification)this.Notification).SecondFolderPath = this.SecondFolderPath;
                this.FinishInteraction();
            },
                () => !string.IsNullOrWhiteSpace(this.SecondFolderPath))
                .ObservesProperty(() => this.SecondFolderPath);
        }
    }
}
