

namespace Client.Views
{
    using EsculabsCommon.Models;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using Annotations;
    using Repositories;
    using EsculabsCommon;

    /// <summary>
    /// Interaction logic for ModulesListView.xaml
    /// </summary>
    public partial class ModulesListView : BaseView, INotifyPropertyChanged
    {
        private Patient _patient;
        private Physician _physician;

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

        public Physician Physician
        {
            get { return _physician; }
            set
            {
                _physician = value;
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
            Widgets = ModulesRepository.Instance.GetWidgetsList(Patient, Physician);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
