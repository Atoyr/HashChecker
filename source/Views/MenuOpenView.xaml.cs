using Microsoft.Practices.ServiceLocation;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HashChecker.Views
{
    /// <summary>
    /// OpenView.xaml の相互作用ロジック
    /// </summary>
    public partial class MenuOpenView : UserControl
    {
        public MenuOpenView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog("フォルダーの選択");

            // 選択形式をフォルダースタイルにする IsFolderPicker プロパティを設定
            dialog.IsFolderPicker = true;
            dialog.ShowDialog((Window)ServiceLocator.Current.GetInstance(typeof(SubWindow)));
        }
    }
}
