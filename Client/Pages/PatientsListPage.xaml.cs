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

            //SetUpPageAnimation();

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
    }
}
