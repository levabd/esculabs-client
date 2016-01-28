using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Navigation;
using Client.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExaminesListPage : Page, INotifyPropertyChanged
    {
        private Patient _patient;

        public Patient Patient
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

            PageHeader.PageName = "Список обследований пациента";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Patient = e.Parameter as Patient;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
