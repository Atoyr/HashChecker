﻿using MetroRadiance.UI.Controls;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
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
    /// MenuOpenWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MenuOpenWindow : MetroWindow
    {
        public MenuOpenWindow()
        {
            InitializeComponent();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterInstance(this);
        }

    }
}
