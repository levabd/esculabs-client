using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace EsculabsCommon
{
    public delegate void ViewInitializeDelegate(FrameworkElement v);

    public class ViewChangeArgs : EventArgs
    {
        public ViewInitializeDelegate   ViewInitDelegate;
        public string                   ViewName { get; set; }

        public FrameworkElement         View { get; set; }
    }
}
