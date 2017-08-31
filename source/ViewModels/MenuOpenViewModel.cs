using HashChecker.Abstract;
using HashChecker.Events;
using HashChecker.Models;
using HashChecker.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace HashChecker.ViewModels
{
    class MenuOpenViewModel : AbstractViewModel
    {
        public InteractionRequest<INotification> WindowCloseRequest { get; } = new InteractionRequest<INotification>();

        private Window window;
        public Window Window { get => window; set => SetProperty(ref window, value); }

        public ICommand OkCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public DelegateCommand<string> FolderOpenDialogCommand { get; private set; }

        enum FolderNo
        {
            None = 0,
            First = 1,
            Second = 2,            
        }

        private string firstFolderPath = string.Empty;
        private string secondFolderPath = string.Empty;
        private string filter = "*.*";

        public string FirstFolderPath
        {
            set
            {
                SetProperty(ref firstFolderPath, value);
                if (OkCommand is DelegateCommandBase dcb) dcb.RaiseCanExecuteChanged();
            }
            get => firstFolderPath;
        }
        public string SecondFolderPath
        {
            set
            {
                SetProperty(ref secondFolderPath, value);
                if (OkCommand is DelegateCommandBase dcb) dcb.RaiseCanExecuteChanged();
            }
            get => secondFolderPath;
        }
        public string Filter { set => SetProperty(ref filter, value); get => filter; }
        public ObservableCollection<string> FirstFolderPathHistory { set; private get; }
        public ObservableCollection<string> SecondFolderPathHistory { set; private get; }
        public ObservableCollection<string> FilterHistory { set; private get; }

        public override void Initialize()
        {
            base.Initialize();
            this.CommandInitialize();
            FirstFolderPathHistory = UserSetting.Current.FirstFolderPathList ?? new ObservableCollection<string>();
            SecondFolderPathHistory = UserSetting.Current.SecondFolderPathList ?? new ObservableCollection<string>();
            FilterHistory = UserSetting.Current.FilterList ?? new ObservableCollection<string>();
        }

        public void CommandInitialize()
        {
            this.OkCommand = new DelegateCommand(() =>
            {
                // 一度変数として受け取る
                // ItemsSourceからRemoveで消すと値が消えるため
                var firstFolderPath = FirstFolderPath;
                var secondFolderPath = SecondFolderPath;
                FirstFolderPathHistory.Remove(firstFolderPath);
                FirstFolderPathHistory.Insert(0, firstFolderPath);
                if (FirstFolderPathHistory.Count() > 10) FirstFolderPathHistory.RemoveAt(10);
                SecondFolderPathHistory.Remove(secondFolderPath);
                SecondFolderPathHistory.Insert(0, secondFolderPath);
                if (SecondFolderPathHistory.Count() > 10) SecondFolderPathHistory.RemoveAt(10);

                UserSetting.Current.FirstFolderPathList = FirstFolderPathHistory;
                UserSetting.Current.SecondFolderPathList = SecondFolderPathHistory;
                UserSetting.Current.Save();

                EventAggregator.GetEvent<FolderOpenEvent>().Publish(new FolderOpenValue { FirstFolderPath = firstFolderPath, SecondFolderPath = secondFolderPath, SearchPattern = this.Filter });
                this.WindowCloseRequest.Raise(new Notification());
            }, CanOkCommandExecute);
            this.CancelCommand = new DelegateCommand(() =>
            {
                this.WindowCloseRequest.Raise(new Notification());
            });
            this.FolderOpenDialogCommand = new DelegateCommand<string>((param) =>
            {
                switch (param)
                {
                    case "First":
                        this.FileOpen(FolderNo.First);
                        break;
                    case "Second":
                        this.FileOpen(FolderNo.Second);
                        break;
                    default:
                        break;
                }
            });
        }

        private void FileOpen(FolderNo folderNo)
        {
            // ダイアログのインスタンスを生成
            var dialog = new CommonOpenFileDialog("フォルダーの選択");

            // 選択形式をフォルダースタイルにする IsFolderPicker プロパティを設定
            dialog.IsFolderPicker = true;

            // ダイアログを表示
            if (dialog.ShowDialog(ServiceLocator.Current.GetInstance<MenuOpenWindow>()) == CommonFileDialogResult.Ok)
            {
                switch (folderNo)
                {
                    case FolderNo.First:
                        FirstFolderPath = dialog.FileName;
                        Task.Run(() =>
                        {
                            System.IO.File.Exists(FirstFolderPath);
                        });
                        break;
                    case FolderNo.Second:
                        SecondFolderPath = dialog.FileName;
                        break;
                    default:
                        break;
                }
            }
        }

        private bool CanOkCommandExecute()
        {
            if(FirstFolderPath == SecondFolderPath)
            {
                return false;
            }
            if(!Directory.Exists(FirstFolderPath) || !Directory.Exists(SecondFolderPath))
            {
                return false;
            }
            return true;
        }
    }
}
