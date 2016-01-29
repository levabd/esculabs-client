using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Client.Models;
using Client.ViewModels;
using FibrosisModule.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class ExaminePage : Page, INotifyPropertyChanged, INotifyPropertyChanging
    {
        private ExamineViewModel _viewModel;
        private ObservableCollection<FakeMeasure> _images;


        public ObservableCollection<FakeMeasure> Images
        {
            get { return _images; }
            set
            {
                if (_images == value)
                {
                    return;
                }

                OnPropertyChanging();
                _images = value;
                OnPropertyChanged();
            }
        }

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



        public ExaminePage()
        {
            this.InitializeComponent();

            Images = new ObservableCollection<FakeMeasure>(new List<FakeMeasure>()
            {
                new FakeMeasure()
                {
                    Correct = true,
                    Processed = "ms-appx:///Assets/Measures/1/01before.jpg",
                    Source = "ms-appx:///Assets/Measures/1/01after.jpg",
                },
                new FakeMeasure()
                {
                    Correct = true,
                    Processed = "ms-appx:///Assets/Measures/1/02before.jpg",
                    Source = "ms-appx:///Assets/Measures/1/02after.jpg",
                },
                new FakeMeasure()
                {
                    Correct = true,
                    Processed = "ms-appx:///Assets/Measures/1/03before.jpg",
                    Source = "ms-appx:///Assets/Measures/1/03after.jpg",
                },
                new FakeMeasure()
                {
                    Correct = true,
                    Processed = "ms-appx:///Assets/Measures/1/04before.jpg",
                    Source = "ms-appx:///Assets/Measures/1/04after.jpg",
                },
                new FakeMeasure()
                {
                    Correct = false,
                    Processed = "ms-appx:///Assets/Measures/2/01before.jpg",
                    Source = "ms-appx:///Assets/Measures/2/01after.jpg",
                },
                new FakeMeasure()
                {
                    Correct = true,
                    Processed = "ms-appx:///Assets/Measures/1/10before.jpg",
                    Source = "ms-appx:///Assets/Measures/1/10after.jpg",
                },
                new FakeMeasure()
                {
                    Correct = false,
                    Processed = "ms-appx:///Assets/Measures/2/02before.jpg",
                    Source = "ms-appx:///Assets/Measures/2/02after.jpg",
                },
                new FakeMeasure()
                {
                    Correct = true,
                    Processed = "ms-appx:///Assets/Measures/1/05before.jpg",
                    Source = "ms-appx:///Assets/Measures/1/05after.jpg",
                },
                new FakeMeasure()
                {
                    Correct = true,
                    Processed = "ms-appx:///Assets/Measures/1/06before.jpg",
                    Source = "ms-appx:///Assets/Measures/1/06after.jpg",
                },
                new FakeMeasure()
                {
                    Correct = true,
                    Processed = "ms-appx:///Assets/Measures/1/07before.jpg",
                    Source = "ms-appx:///Assets/Measures/1/07after.jpg",
                },
                new FakeMeasure()
                {
                    Correct = true,
                    Processed = "ms-appx:///Assets/Measures/1/08before.jpg",
                    Source = "ms-appx:///Assets/Measures/1/08after.jpg",
                },
                new FakeMeasure()
                {
                    Correct = true,
                    Processed = "ms-appx:///Assets/Measures/1/09before.jpg",
                    Source = "ms-appx:///Assets/Measures/1/09after.jpg",
                },
            });

            SetUpPageAnimation();

            DataContext = this;
            
            PageHeader.PageName = "Обследование пациента";
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

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        private void MeasuresGrid_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var image = e.ClickedItem as FakeMeasure;

            if (image == null)
            {
                return;
            }

            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(MeasurePage), image);
        }
    }
}
