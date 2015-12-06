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

        public UserControl GetWidget()
        {
            var x = ExaminesRepository.Instance.Find(1);           

            return new FibrosisWidget();
        }

        public UserControl GetExaminesList()
        {
            return new ExaminesListView();            
        }
    }
}
