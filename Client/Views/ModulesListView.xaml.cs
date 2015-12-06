using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Client.Annotations;

namespace Client.Views
{
    using Models;
    using Repositories;
    using EsculabsCommon;

    /// <summary>
    /// Interaction logic for ModulesListView.xaml
    /// </summary>
    public partial class ModulesListView : BaseView, INotifyPropertyChanged
    {
        private Patient _patient;
        private List<UserControl> _widgets;
         
        public Patient Patient
        {
            get { return _patient; }
            set
            {
                _patient = value;
                OnPropertyChanged();
            }
        }

        public List<UserControl> Widgets
        {
            get { return _widgets; }
            set
            {
                _widgets = value;
                OnPropertyChanged();
            }
        }

        public ModulesListView()
        {
            InitializeComponent();

            DataContext = this;
        }

        public void ReloadWidgets()
        {
            Widgets = ModulesRepository.Instance.GetWidgetsList(Patient);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
