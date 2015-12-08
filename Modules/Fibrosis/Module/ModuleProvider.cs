using System;
using System.Windows.Controls;
using Fibrosis.Repositories;

namespace Fibrosis
{
    using Controls;
    using EsculabsCommon;
    using Views;

    public class ModuleProvider : IModuleProvider
    {
        public event EventHandler<ViewChangeArgs> ViewSwitchEventHandler;
        public string Name => "Fibrosis";
        
        public ModuleProvider()
        {            
        }

        public UserControl GetWidget(IPatient patient)
        {
            return new FibrosisWidget(this, patient);
        }

        public void SetView(ViewChangeArgs args)
        {
            ViewSwitchEventHandler?.Invoke(this, args);
        }
    }
}
