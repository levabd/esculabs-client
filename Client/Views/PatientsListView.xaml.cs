﻿using System;
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
using Client.Annotations;
using EsculabsCommon;

namespace Client.Views
{
    using EsculabsCommon.Models;
    using EsculabsCommon.Repositories;
    using Helpers;
    using Controls;

    /// <summary>
    /// Interaction logic for PatientsList.xaml
    /// </summary>
    public partial class PatientsListView : BaseView, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler        PropertyChanged;
        public event EventHandler<PatientTileClickArgs> TileClickEventHandler;
        public event EventHandler<RoutedEventArgs>      AddPatientButtonClickHandler;

        public CollectionViewSource Patients { get; private set; }

        public PatientsListView()
        {
            InitializeComponent();

            Patients = new CollectionViewSource();

            ReloadPatientsGrid();

            DataContext = this;
        }

        public async void ReloadPatientsGrid()
        {
            var patientsTask = PatientsRepository.Instance.AllAsync();

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
            if (TileClickEventHandler == null)
            {
                return;
            }

            if (e.ChangedButton == MouseButton.Left)
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
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
