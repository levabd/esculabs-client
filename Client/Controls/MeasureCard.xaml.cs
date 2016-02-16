using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Client.Helpers.Converters;
using Client.Models;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Client.Controls
{
    public sealed partial class MeasureCard : UserControl
    {
        public MeasureCard()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var measure = DataContext as Measure;

            if (measure == null)
            {
                return;
            }

            CorrectGrid.Visibility = measure.Correct ? Visibility.Visible : Visibility.Collapsed;
            IncorrectGrid.Visibility = measure.Correct ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
