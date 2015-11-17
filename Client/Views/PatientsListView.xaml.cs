using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Client.Views
{
    using Models;
    using Repositories;
    using Helpers;
    using Controls;

    /// <summary>
    /// Interaction logic for PatientsList.xaml
    /// </summary>
    public partial class PatientsListView : UserControl
    {
        public event EventHandler<PatientTileClickArgs> TileClickEventHandler;
        public event EventHandler<RoutedEventArgs> AddPatientButtonClick;

        private List<Patient> _patients = new List<Patient>();

        public CollectionViewSource Patients { get; private set; }

        public PatientsListView()
        {
            InitializeComponent();

            ReloadPatientsList();
            DataContext = this;
        }

        public void ReloadPatientsList()
        {
            _patients = PatientsRepository.Instance.All();

            Patients = new CollectionViewSource();
            Patients.Source = _patients;
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterPatientsList(nameFilterTextBox.Text, iinFilterTextBox.Text);
        }

        private void FilterPatientsList(string nameFilter, string iinFilter)
        {
            Patients.View.Filter = item =>
            {
                var result = true;
                var p = item as Patient;

                nameFilter = nameFilter.ToLower();

                if (!string.IsNullOrWhiteSpace(nameFilter))
                {
                    result = p.FullNameString.ToLower().Contains(nameFilter);
                }

                if (!string.IsNullOrWhiteSpace(iinFilter))
                {
                    result = p.Iin.Contains(iinFilter);
                }

                return result;
            };
        }

        private void Tile_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (TileClickEventHandler != null)
            {
                PatientTileClickArgs args = new PatientTileClickArgs()
                {
                    Patient = (sender as PatientsListTile).DataContext as Patient
                };

                TileClickEventHandler(this, args);
            }
        }

        private void addPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AddPatientButtonClick != null)
            {
                AddPatientButtonClick(sender, e);
            }
        }
    }
}
