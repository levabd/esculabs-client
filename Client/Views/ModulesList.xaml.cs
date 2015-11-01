using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Views
{
    using Models;
    using Repositories;
    using ModuleFramework;
    using Controls;

    /// <summary>
    /// Interaction logic for ModulesList.xaml
    /// </summary>
    public partial class ModulesList : UserControl
    {
        private Patient _patient;
        private List<object> _widgets;

        public ModulesList()
        {
            InitializeComponent();
        }

        public void Initialize(Window owner, Physician currentPhysician, Patient patient)
        {
            _patient = patient;
            _widgets = ModulesRepository.Instance.GetWidgetsList(owner);
        }

        public void ShowWidgets()
        {
            foreach (var widget in _widgets)
            {
                widgetsList.Children.Add(widget as UIElement);
            }
        }
    }
}
