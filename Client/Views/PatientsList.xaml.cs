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

    /// <summary>
    /// Interaction logic for PatientsList.xaml
    /// </summary>
    public partial class PatientsList : UserControl
    {
        private List<Patient> _patients = null;

        public PatientsList()
        {
            InitializeComponent();
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterPatientsList(nameFilterTextBox.Text, iinFilterTextBox.Text);
        }

        private void FilterPatientsList(string nameFilter, string iinFilter)
        {
            IEnumerable<Patient> filteredList = _patients;

            nameFilter = nameFilter.ToLower();

            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                filteredList = filteredList.Where(x => x.FullNameString.ToLower().Contains(nameFilter));
            }

            if (!string.IsNullOrWhiteSpace(iinFilter))
            {
                filteredList = filteredList.Where(x => x.Iin.Contains(iinFilter));
            }

            patientsGrid.ItemsSource = filteredList;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _patients = PatientsRepository.Instance.All();

            if (_patients == null || !_patients.Any())
            {
                return;
            }

            patientsGrid.ItemsSource = _patients;
        }
    }
}
