using HashChecker.Abstract;
using HashChecker.Events;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HashChecker.ViewModels
{
    class MenuOpenViewModel : AbstractViewModel
    {
        public InteractionRequest<INotification> WindowCloseRequest { get; } = new InteractionRequest<INotification>();

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

        public string FirstFolderPath { set => SetProperty(ref firstFolderPath,value); get => firstFolderPath; }
        public string SecondFolderPath { set => SetProperty(ref secondFolderPath,value); get => secondFolderPath; }
        public string Filter { set => SetProperty(ref filter, value); get => filter; }
        public ObservableCollection<string> FirstFolderPathHistory { set; private get; }
        public ObservableCollection<string> SecondFolderPathHistory { set; private get; }
        public ObservableCollection<string> FilterHistory { set; private get; }

        public override void Initialize()
        {
            base.Initialize();
            this.CommandInitialize();
        }

        public void CommandInitialize()
        {
            this.OkCommand = new DelegateCommand(() =>
            {
                EventAggregator.GetEvent<FolderOpenEvent>().Publish(new FolderOpenValue { FirstFolderPath = this.FirstFolderPath, SecondFolderPath = this.SecondFolderPath, SearchPattern = this.Filter });
                this.WindowCloseRequest.Raise(new Notification());
            });
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
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
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
            return true;
        }
    }
}
