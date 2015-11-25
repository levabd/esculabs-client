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
    using EsculabsCommon;

    /// <summary>
    /// Interaction logic for ModulesListView.xaml
    /// </summary>
    public partial class ModulesListView : BaseView
    {
        public Patient              Patient { get; set; }
        public List<UserControl>    Widgets { get; set; }

        public ModulesListView()
        {
            InitializeComponent();

            Widgets = ModulesRepository.Instance.GetWidgetsList();
            
            DataContext = this;
        }
    }
}
