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
using Client.Models;
using Client.Pages;
using Client.ViewModels;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Client.Controls
{
    public sealed partial class PatientCard : UserControl
    {
        public PatientCard()
        {
            this.InitializeComponent();


        }

        private void ExaminesListButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null)
            {
                return;
            }

            var frame = Window.Current.Content as Frame;

            //var vm = new ExamineViewModel(button.DataContext as Patient);

            frame?.Navigate(typeof(ExaminesListPage), button.DataContext as ExamineViewModel);
        }
    }
}
