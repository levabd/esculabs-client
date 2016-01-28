using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class AddPatientPage : Page
    {
        public AddPatientPage()
        {
            InitializeComponent();

            SetUpPageAnimation();

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            PageHeader.PageName = "Добавить нового пациента";
        }

        protected void SetUpPageAnimation()
        {
            var collection = new TransitionCollection();
            var theme = new NavigationThemeTransition();
            var info = new Windows.UI.Xaml.Media.Animation.SlideNavigationTransitionInfo(); 

            theme.DefaultNavigationTransitionInfo = info;
            collection.Add(theme);
            Transitions = collection;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var frame = Window.Current.Content as Frame;

            if (frame != null && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var frame = Window.Current.Content as Frame;

            if (frame != null && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }
    }
}
