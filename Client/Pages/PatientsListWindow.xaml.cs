﻿using System;
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
using System.Windows.Shapes;

namespace Client.Pages
{
    using Models;
    using Repositories;
    using MahApps.Metro.Controls;

    /// <summary>
    /// Interaction logic for PatientsListWindow.xaml
    /// </summary>
    public partial class PatientsListWindow : MetroWindow
    {
        private List<Patient> _patients = null;
       
        public PatientsListWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Height = SystemParameters.PrimaryScreenHeight;
            Width = SystemParameters.PrimaryScreenWidth;
            Left = 0;
            Top = 0;

            _patients = PatientsRepository.Instance.All();

            if (_patients == null || !_patients.Any())
            {
                return;
            }

            patientsGrid.ItemsSource = _patients;
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
    }
}
