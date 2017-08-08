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
using System.Windows.Shapes;

namespace HashChecker.Views
{
    /// <summary>
    /// Shell.xaml の相互作用ロジック
    /// </summary>
    public partial class Shell 
    {
        public Shell()
        {
            InitializeComponent();
        }

        private void PART_MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            new MenuOpenWindow().ShowDialog();
        }
    }
}
