using System;
using System.Windows;
using System.Windows.Controls;

namespace EsculabsCommon
{
    public interface IModuleProvider
    {
        event EventHandler<ViewSwitchEventArgs> ViewSwitchEventHandler;

        string Name { get; }

        UserControl GetWidget();
    }
}
