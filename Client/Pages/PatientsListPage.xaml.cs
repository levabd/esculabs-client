using Windows.UI.Xaml;
using Client.Models;
using FibrosisModule.Models;

namespace Client.Pages
{
    using System.Collections.ObjectModel;
    using Windows.UI.Core;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    using ViewModels;
    using Repositories;

    public partial class PatientsListPage : Page
    {
        public PatientViewModel PatientViewModel { get; set; }

        public PatientsListPage()
        {
            InitializeComponent();

            SetUpPageAnimation();

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            PatientViewModel = new PatientViewModel();
            DataContext = PatientViewModel;

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
            var vm = e.ClickedItem as ExamineViewModel;

            if (vm == null)
            {
                return;
            }

            vm.SelectedExamine = vm.LastExamine;

            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(ExaminePage), vm);
        }
    }
}
