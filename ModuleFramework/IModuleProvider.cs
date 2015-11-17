using System;

namespace ModuleFramework
{
    using System.Windows.Controls;

    public interface IModuleProvider
    {
        event EventHandler<ViewSwitchEventArgs> ViewSwitchEventHandler;

        string Name { get; }

        UserControl GetWidget();
    }
}
