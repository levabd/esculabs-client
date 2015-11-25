using System;
using System.Windows;
using System.Windows.Controls;

namespace EsculabsCommon
{
    public class ViewChangeArgs : EventArgs
    {
        public string               ViewName { get; set; }

        public FrameworkElement     View { get; set; }
    }
}
