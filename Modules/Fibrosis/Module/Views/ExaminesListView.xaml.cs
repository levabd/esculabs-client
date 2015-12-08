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
        private IPatient _patient;
        private List<Examine> _examines;

        public event EventHandler<ExamineTileClickArgs> TileClickEventHandler;
        public event EventHandler<RoutedEventArgs> AddExamineButtonClickHandler;

        public IPatient Patient
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
                ReloadPatientsGrid();
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

        public ExaminesListView()
        {
            InitializeComponent();

            DataContext = this;
        }

        private async void ReloadPatientsGrid()
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
            if (TileClickEventHandler != null)
            {
                var patientsListTile = sender as PatientsListTile;
                if (patientsListTile != null)
                {
                    var args = new ExamineTileClickArgs { Examine = patientsListTile.DataContext as Examine };

                    TileClickEventHandler(this, args);
                }
            }
        }

        private void AddExamineBtn_Click(object sender, RoutedEventArgs e)
        {
            AddExamineButtonClickHandler?.Invoke(sender, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
