using System;
using System.Windows.Controls;
using Fibrosis.Repositories;

namespace Fibrosis
{
    using Controls;
    using EsculabsCommon;
    using EsculabsCommon.Models;

    public class ModuleProvider : IModuleProvider
    {
        public Physician Physician { get; set; }

        public event EventHandler<ViewChangeArgs> ViewSwitchEventHandler;
        public string Name => "Fibrosis";

        public void SetPhysician(Physician physician)
        {
            Physician = physician;
        }

        public UserControl GetWidget(Patient patient)
        {
            return new FibrosisWidget(this, patient);
        }

        public void SetView(ViewChangeArgs args)
        {
            ViewSwitchEventHandler?.Invoke(this, args);
        }
    }
}
