using System;
using System.Windows.Controls;

namespace ModuleFramework
{
    public class ViewSwitchEventArgs : EventArgs
    {
        public UserControl View { get; set; } = null;
    }
}
