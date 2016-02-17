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
        private PatientViewModel _viewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public PatientViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }
        
        public PatientsListPage()
        {
            InitializeComponent();

            ViewModel = new PatientViewModel();
            DataContext = ViewModel;

            SetUpPageAnimation();
            PageHeader.PageName = "Список пациентов";
        }


        protected void SetUpPageAnimation()
        {
            var collection = new TransitionCollection();
            var theme = new NavigationThemeTransition();
            var info = new ContinuumNavigationTransitionInfo();

            theme.DefaultNavigationTransitionInfo = info;
            collection.Add(theme);
            Transitions = collection;
        }

        private void AddPatientButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var frame = Window.Current.Content as Frame;

            frame?.Navigate(typeof(AddPatientPage));
        }

        private void PatientsList_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var patient = e.ClickedItem as Patient;

            if (patient?.LastExamine == null)
            {
                return;
            }
      
            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(ExaminePage), ExaminesRepository.Instance.Find(patient.LastExamine.Id));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
