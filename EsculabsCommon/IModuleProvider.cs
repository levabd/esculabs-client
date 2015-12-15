namespace EsculabsCommon
{
    using System;
    using System.Windows.Controls;
    using Models;

    public interface IModuleProvider
    {
        event EventHandler<ViewChangeArgs> ViewSwitchEventHandler;

        string Name { get; }

        void SetPhysician(Physician physician);

        UserControl GetWidget(Patient patient);

        void SetView(ViewChangeArgs args);
    }
}
