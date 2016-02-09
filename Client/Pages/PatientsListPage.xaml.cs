using Client.Models;

namespace Client.Pages
{
    using Windows.UI.Xaml;
    using Windows.UI.Core;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    using ViewModels;

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
            var examine = e.ClickedItem as Examine;

            if (examine == null)
            {
                return;
            }
      
            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(ExaminePage), examine);
        }
    }
}
