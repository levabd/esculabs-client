using System;
using System.Windows.Controls;

namespace EsculabsCommon
{
    public class ViewSwitchEventArgs : EventArgs
    {
        public UserControl View { get; set; } = null;
    }
}
