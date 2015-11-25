using System;
using System.Windows;
using System.Windows.Controls;
using EsculabsCommon;

namespace Fibrosis
{
    public class ModuleProvider : IModuleProvider
    {
        public event EventHandler<ViewSwitchEventArgs> ViewSwitchEventHandler;

        public string Name => "Fibrosis";

        public UserControl GetWidget()
        {
            return new FibrosisWidget();
        }
    }
}
