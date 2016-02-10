using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Client.Models;
using Client.Repositories;

namespace Client.Pages
{
    using Windows.UI.Xaml;
    using Windows.UI.Core;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    using ViewModels;

    public partial class PatientsListPage : INotifyPropertyChanged
    {
        private ObservableCollection<PatientViewModel> _patients;

        public ObservableCollection<PatientViewModel> Patients
        {
            get { return _patients; }
            set
            {
                if (_patients == value)
                {
                    return;
                }

                _patients = value;
                OnPropertyChanged();
            }
        }

        public PatientsListPage()
        {
            InitializeComponent();

            DataContext = this;

            SetUpPageAnimation();
            PageHeader.PageName = "Список пациентов";

            LoadPatients();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetUpPageAnimation()
        {
            var collection = new TransitionCollection();
            var theme = new NavigationThemeTransition();
            var info = new ContinuumNavigationTransitionInfo();

            theme.DefaultNavigationTransitionInfo = info;
            collection.Add(theme);
            Transitions = collection;
        }

        private void LoadPatients()
        {
            Patients = new ObservableCollection<PatientViewModel>();

            var patients = PatientsRepository.Instance.GetAll();
            foreach (var p in patients)
            {
                var vm = new PatientViewModel(p);
                Patients.Add(vm);
            }
        }

        private void AddPatientButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var frame = Window.Current.Content as Frame;

            frame?.Navigate(typeof(AddPatientPage));
        }

        private void PatientsList_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var examine = e.ClickedItem as Examine;

            if (examine == null)
            {
                return;
            }
      
            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(ExaminePage), examine);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
