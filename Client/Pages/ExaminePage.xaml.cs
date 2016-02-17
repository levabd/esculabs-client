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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class ExaminePage : INotifyPropertyChanged
    {
        private Examine _examine;

        public Examine Examine
        {
            get { return _examine; }
            set
            {
                if (_examine == value)
                {
                    return;
                }

                _examine = value;
                OnPropertyChanged();
            }
        }

        public ExaminePage()
        {
            InitializeComponent();

            SetUpPageAnimation();
            
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
            Examine = e.Parameter as Examine;
            DataContext = Examine;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void MeasuresGrid_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var measure = e.ClickedItem as Measure;

            if (measure == null)
            {
                return;
            }

            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(MeasurePage), measure);
        }

        private void WhiskerPlotButton_Click(object sender, RoutedEventArgs e)
        {
            var image = (DataContext as Examine)?.WhiskerPlotImage;

            if (image == null)
            {
                return;
            }

            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(WhiskerPlotPage), image);
        }
    }
}
