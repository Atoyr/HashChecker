using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Interactivity;

namespace HashChecker.Common
{
    public class ShowModalWindowAction : TriggerAction<DependencyObject>
    {
        public Type WindowType
        {
            get { return (Type)GetValue(WindowTypeProperty); }
            set { SetValue(WindowTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WindowType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowTypeProperty =
            DependencyProperty.Register("WindowType", typeof(Type), typeof(ShowModalWindowAction), new PropertyMetadata(typeof(Window)));

        protected override void Invoke(object parameter)
        {
            var currentRegionManager = RegionManager.GetRegionManager(Window.GetWindow(this.AssociatedObject));
            var w = (Window)Activator.CreateInstance(this.WindowType);
            RegionManager.SetRegionManager(w, currentRegionManager.CreateRegionManager());
            w.ShowDialog();
        }
    }
}
