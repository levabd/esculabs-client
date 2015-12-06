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
using EsculabsCommon;

namespace Client.Views
{
    using Models;
    using Repositories;
    using Helpers;
    using Controls;

    /// <summary>
    /// Interaction logic for PatientsList.xaml
    /// </summary>
    public partial class PatientsListView : BaseView
    {
        public event EventHandler<PatientTileClickArgs> TileClickEventHandler;
        public event EventHandler<RoutedEventArgs> AddPatientButtonClickHandler;

        public CollectionViewSource Patients { get; private set; }

        public PatientsListView()
        {
            InitializeComponent();

            ReloadPatientsGrid();

            DataContext = this;
        }

        private async void ReloadPatientsGrid()
        {
            var patientsTask = PatientsRepository.Instance.AllAsync();

            Patients = new CollectionViewSource();
            Patients.Source = await patientsTask;
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

                if (p == null)
                {
                    return true;
                }

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
                var patientsListTile = sender as PatientsListTile;
                if (patientsListTile != null)
                {
                    PatientTileClickArgs args = new PatientTileClickArgs()
                    {
                        Patient = patientsListTile.DataContext as Patient
                    };

                    TileClickEventHandler(this, args);
                }
            }
        }

        private void addPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPatientButtonClickHandler?.Invoke(sender, e);
        }
    }
}
