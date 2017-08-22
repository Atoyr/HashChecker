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

        ~ShellViewModel()
        {
            UnregistEventSubscribe();
        }

        public override void Initialize()
        {
            base.Initialize();
            RegistEventSubscribe();
            StatusBar = new StatusBar { Message = "準備完了" };
        }

        private void RegistEventSubscribe()
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<StatusBarMessageChangeEvent>().Subscribe(StatusBarMessageChange);
            eventAggregator.GetEvent<ProgressBarChangeEvent>().Subscribe(ProgressBarValueChange);
        }

        private void UnregistEventSubscribe()
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<StatusBarMessageChangeEvent>().Unsubscribe(StatusBarMessageChange);
            eventAggregator.GetEvent<ProgressBarChangeEvent>().Unsubscribe(ProgressBarValueChange);
        }

        /// <summary>
        /// ステータスバー メッセージ変更処理
        /// EventAggregator経由で変更する
        /// </summary>
        /// <param name="value"></param>
        private void StatusBarMessageChange(IMessageValue value)
        {
            if (StatusBar != null)
            {
                StatusBar.Message = value.Message;
            }
        }

        /// <summary>
        /// プログレスバー 変更処理
        /// EventAggregator経由で変更する
        /// </summary>
        /// <param name="value"></param>
        private void ProgressBarValueChange(IProgressBarValue value)
        {
            if (StatusBar != null)
            {
                StatusBar.IsIndeterminate = value.IsIndeterminate;
                StatusBar.Maximum = value.Maximum;
                StatusBar.Minimum = value.Minimum;
                StatusBar.Value = value.Value;
                StatusBar.ProgressBarVisibility = value.ProgressBarVisibility;
            }
        }
    }
}
