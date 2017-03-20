// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HashChecker
{
    using System.Windows;

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            //this.DataContext
            var data = BindingGridData.GetMergeList(@"C:\release\test", @"C:\release\test2","*");
            this.Grid.ItemsSource = data;
        }


    }
}
