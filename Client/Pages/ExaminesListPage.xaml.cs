
using System.Collections.ObjectModel;

namespace Client.Pages
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    using Windows.UI.Xaml.Navigation;
    using ViewModels;
    using Models;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class ExaminesListPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<ExamineViewModel> _examines;
        private PatientViewModel _patient;

        public ObservableCollection<ExamineViewModel> Examines
        {
            get { return _examines; }
            set
            {
                if (_examines == value)
                {
                    return;
                }

                _examines = value;
                OnPropertyChanged();
            }
        }

        public PatientViewModel Patient
        {
            get { return _patient; }
            set
            {
                if (_patient == value)
                {
                    return;
                }

                _patient = value;
                OnPropertyChanged();
            }
        }

        public ExaminesListPage()
        {
            InitializeComponent();

            DataContext = this;

            SetUpPageAnimation();
            PageHeader.PageName = "Список обследований пациента";
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var patient = e.Parameter as PatientViewModel;

            if (patient == null)
            {
                return;
            }

            Patient = patient;
            Examines = patient.Examines;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ExaminesList_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var examine = e.ClickedItem as ExamineViewModel;

            if (examine == null)
            {
                return;
            }

            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(ExaminePage), examine);
        }
    }
}
