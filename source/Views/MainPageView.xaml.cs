using HashChecker.Controls;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// MainPageView.xaml の相互作用ロジック
    /// </summary>
    public partial class MainPageView : BasePanel
    {
        public static string RowIndexName => "RowIndex";

        public MainPageView()
        {
            InitializeComponent();
        }
    }
}
