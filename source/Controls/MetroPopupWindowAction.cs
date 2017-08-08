using HashChecker.Views;
using MetroRadiance.UI.Controls;
using Prism.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HashChecker.Controls
{
    internal class MetroPopupWindowAction : PopupWindowAction
    {
        protected override Window CreateWindow()
        {
            return new Shell
            {
                Style = new Style(),
                SizeToContent = SizeToContent.WidthAndHeight
            };
        }
    }
}
