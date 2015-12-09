using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EsculabsCommon;
using Microsoft.Win32;

namespace Fibrosis.Views
{
    using Models;
    using Repositories;
    using Helpers;
    using Controls;

    /// <summary>
    /// Interaction logic for PatientsList.xaml
    /// </summary>
    public partial class ExaminesListView : BaseView, INotifyPropertyChanged
    {
        private ModuleProvider _moduleProvider;
        private IPatient _patient;
        private List<Examine> _examines;

        //public event EventHandler<RoutedEventArgs> AddExamineButtonClickHandler;

        public IPatient Patient
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
                OnPropertyChanged();
            }
        }

        public List<Examine> Examines
        {
            get
            {
                return _examines;
            }
            set
            {
                _examines = value;
                OnPropertyChanged();
            }
        }

        public ModuleProvider ModuleProvider
        {
            get
            {
                return _moduleProvider;
            }
            set
            {
                _moduleProvider = value;
                OnPropertyChanged();
            }
        }

        public ExaminesListView()
        {
            InitializeComponent();

            DataContext = this;
        }

        private async void ReloadExaminesList()
        {
            var examinesTask = FibrosisRepository.Instance.AllExaminesAsync(Patient.Id);
            Examines = await examinesTask;
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          //  FilterPatientsList(nameFilterTextBox.Text, iinFilterTextBox.Text);
        }

        private void FilterPatientsList(string nameFilter, string iinFilter)
        {
            //Patients.View.Filter = item =>
            //{
            //    var result = true;
            //    var p = item as Patient;

            //    if (p == null)
            //    {
            //        return true;
            //    }

            //    nameFilter = nameFilter.ToLower();

            //    if (!string.IsNullOrWhiteSpace(nameFilter))
            //    {
            //        result = p.FullNameString.ToLower().Contains(nameFilter);
            //    }

            //    if (!string.IsNullOrWhiteSpace(iinFilter))
            //    {
            //        result = p.Iin.Contains(iinFilter);
            //    }

            //    return result;
            //};
        }

        private void Tile_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var examinesListTile = sender as ExaminesListTile;
            if (examinesListTile != null)
            {
                ModuleProvider?.SetView(new ViewChangeArgs
                {
                    ViewName = typeof (ExamineView).FullName,
                    ViewInitDelegate = x =>
                    {
                        ((ExamineView) x).ModuleProvider = ModuleProvider;
                        ((ExamineView) x).Patient = Patient;
                        ((ExamineView) x).Examine = examinesListTile.DataContext as Examine;
                        ((ExamineView) x).ReloadView();
                    }
                });
            }
        }

        private void AddExamineBtn_Click(object sender, RoutedEventArgs e)
        {
            //AddExamineButtonClickHandler?.Invoke(sender, e);
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }

            if (FibxParser.Instance.Import(openFileDialog.FileName, _patient.Id))
            {
                ReloadExaminesList();
            }

            //if (examine != null && IsLoaded)
            //{
            //    RefreshExaminesList();
                //examinesGrid.ItemsSource = _examines;
            //}

            // loader.Close();
  //          Effect = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == "Patient")
            {
                ReloadExaminesList();
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
