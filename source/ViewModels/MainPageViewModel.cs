using HashChecker.Abstract;
using HashChecker.Events;
using HashChecker.Interfaces;
using HashChecker.Logics;
using HashChecker.Models;
using Microsoft.Practices.ServiceLocation;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HashChecker.ViewModels
{
    public class MainPageViewModel : AbstractViewModel
    {
        public InteractionRequest<INotification> OpenForderNotificationRequest { get; } = new InteractionRequest<INotification>();

        public DelegateCommand ShowWindowCommand { get; private set; }

        private ObservableCollection<MergeData> gridData;
        public ObservableCollection<MergeData> GridData { set => SetProperty(ref gridData, value); get => gridData; }

        public override void Initialize()
        {
            base.Initialize();
            InitializeCommand();
            ServiceLocator.Current.GetInstance<IEventAggregator>().GetEvent<FolderOpenEvent>().Subscribe(FolderOpen,ThreadOption.BackgroundThread);
        }

        private void InitializeCommand()
        {
            this.ShowWindowCommand = new DelegateCommand(() =>
            {
                this.OpenForderNotificationRequest.Raise(new Notification
                {
                    Title = "ファイルを開く",
                });
            });
        }
        
        private void FolderOpen(IFolderOpenValue value)
        {
            
            if(EventAggregator != null)
            {
                EventAggregator.GetEvent<StatusBarMessageChangeEvent>().Publish(new StatusBarMessageChangeValue { Message = "処理中..." });
                EventAggregator.GetEvent<ProgressBarChangeEvent>().Publish(new ProgressBarChangeValue { IsIndeterminate = true, ProgressBarVisibility = Visibility.Visible });
            }
            GridData = new ObservableCollection<MergeData>(BindingGridData.GetMergeList(value.FirstFolderPath, value.SecondFolderPath, value.SearchPattern));
            if (EventAggregator != null)
            {
                EventAggregator.GetEvent<StatusBarMessageChangeEvent>().Publish(new StatusBarMessageChangeValue { Message = "準備完了" });
                EventAggregator.GetEvent<ProgressBarChangeEvent>().Publish(new ProgressBarChangeValue { IsIndeterminate = false,ProgressBarVisibility = Visibility.Hidden });
            }
        }
    }
}
