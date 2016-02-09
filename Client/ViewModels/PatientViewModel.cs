using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;
using Cimbalino.Toolkit.Extensions;

namespace Client.ViewModels
{
    using System.Collections.ObjectModel;
    using Repositories;
    using Models;

    public class PatientViewModel : BaseViewModel
    {
        #region Filter properties

        private string _nameFilter;
        private string _iinFilter;
        private string _fibrosisStageFilter;
        private string _stiffnessFilter;
        private string _expertSatusFilter;
        private string _systemStatusFilter;

        public string NameFilter
        {
            get { return _nameFilter; }
            set
            {
                if (_nameFilter == value)
                {
                    return;
                }

                OnPropertyChanging();
                _nameFilter = value;
                OnPropertyChanged();
            }
        }


        public string IinFilter
        {
            get { return _iinFilter; }
            set
            {
                if (_iinFilter == value)
                {
                    return;
                }

                OnPropertyChanging();
                _iinFilter = value;
                OnPropertyChanged();
            }
        }

        public string FibrosisStageFilter
        {
            get { return _fibrosisStageFilter; }
            set
            {
                if (_fibrosisStageFilter == value)
                {
                    return;
                }

                OnPropertyChanging();
                _fibrosisStageFilter = value;
                OnPropertyChanged();
            }
        }

        public string StiffnessFilter
        {
            get { return _stiffnessFilter; }
            set
            {
                if (_stiffnessFilter == value)
                {
                    return;
                }

                OnPropertyChanging();
                _stiffnessFilter = value;
                OnPropertyChanged();
            }
        }

        public string ExtpertStatusFilter
        {
            get { return _expertSatusFilter; }
            set
            {
                if (_expertSatusFilter == value)
                {
                    return;
                }

                OnPropertyChanging();
                _expertSatusFilter = value;
                OnPropertyChanged();
            }
        }

        public string SystemStatusFilter
        {
            get { return _systemStatusFilter; }
            set
            {
                if (_systemStatusFilter == value)
                {
                    return;
                }

                OnPropertyChanging();
                _systemStatusFilter = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private ObservableCollection<Patient> _patients;
        private ObservableCollection<Patient> _filteredPatients;

        public ObservableCollection<Patient> Patients
        {
            get { return _patients; }
            set
            {
                if (_patients == value)
                {
                    return;
                }

                OnPropertyChanging();
                _patients = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Patient> FilteredPatients
        {
            get { return _filteredPatients; }
            set
            {
                if (_filteredPatients == value)
                {
                    return;
                }

                OnPropertyChanging();
                _filteredPatients = value;
                OnPropertyChanged();
            }
        }

        public PatientViewModel()
        {
            Patients = new ObservableCollection<Patient>();
            FilteredPatients = new ObservableCollection<Patient>();

            ReloadPatients();
        }

        private void RefreshFilter()
        {

        }

        private void ReloadPatients()
        {
            Patients.Clear();
            FilteredPatients.Clear();

            var patients = PatientsRepository.Instance.GetAll();
            foreach (var p in patients)
            {
                Patients.Add(p);
                FilteredPatients.Add(p);
            }

           
        }
    }
}
