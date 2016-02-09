﻿
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
        private ExamineViewModel _viewModel;

        public ExamineViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                if (_viewModel == value)
                {
                    return;
                }

                _viewModel = value;
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
            ViewModel = e.Parameter as ExamineViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ExaminesList_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var examine = e.ClickedItem as Examine;

            if (examine == null)
            {
                return;
            }

            ViewModel.SelectedExamine = examine;

            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(ExaminePage), ViewModel);
        }
    }
}
