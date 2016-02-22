using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Cimbalino.Toolkit.Extensions;
using Client.Context;
using Client.Repositories;
using Microsoft.Data.Entity;

namespace Client.ViewModels
{
    using Models;

    public class PatientViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Patient> _filteredPatients;
        private ObservableCollection<Patient> _patients;
        private string _nameFilter;
        private string _iinFilter;
        private string _fibrosisStageFilter;
        private string _stiffnessFilter;
        private ComboBoxItem _expertStatusFilter;
        private ComboBoxItem _systemStatusFilter;

        public ObservableCollection<Patient> FilteredPatients
        {
            get { return _filteredPatients; }
            set
            {
                _filteredPatients = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Patient> Patients
        {
            get { return _patients; }
            set
            {
                _patients = value;
                OnPropertyChanged();
            }
        }

        public string NameFilter
        {
            get { return _nameFilter; }
            set
            {
                _nameFilter = value;
                OnPropertyChanged();
            }
        }

        public string IinFilter
        {
            get { return _iinFilter; }
            set
            {
                _iinFilter = value;
                OnPropertyChanged();
            }
        }

        public string FibrosisStageFilter
        {
            get { return _fibrosisStageFilter; }
            set
            {
                _fibrosisStageFilter = value;
                OnPropertyChanged();
            }
        }

        public string StiffnessFilter
        {
            get { return _stiffnessFilter; }
            set
            {
                _stiffnessFilter = value;
                OnPropertyChanged();
            }
        }

        public ComboBoxItem ExpertStatusFilter
        {
            get { return _expertStatusFilter; }
            set
            {
                _expertStatusFilter = value;
                OnPropertyChanged();
            }
        }

        public ComboBoxItem SystemStatusFilter
        {
            get { return _systemStatusFilter; }
            set
            {
                _systemStatusFilter = value;
                OnPropertyChanged();
            }
        }

        private void FilterPatients()
        {
            var filteredPatients = Patients.ToList();

            if (!string.IsNullOrEmpty(NameFilter))
            {
                filteredPatients = filteredPatients.Where(p => $"{p.LastName} {p.FirstName} {p.MiddleName}".ToLower().Contains(NameFilter.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(IinFilter))
            {
                filteredPatients = filteredPatients.Where(p => p.Iin.Contains(IinFilter)).ToList();
            }

            if (!string.IsNullOrEmpty(FibrosisStageFilter))
            {
                filteredPatients = filteredPatients.Where(p => p.LastExamine != null && p.LastExamine.FibrosisStage.ToLower().Contains(FibrosisStageFilter.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(StiffnessFilter))
            {
                double stiffness = 0;

                try
                {
                    stiffness = double.Parse(StiffnessFilter, CultureInfo.InvariantCulture);
                }
                finally
                {
                    filteredPatients = filteredPatients.Where(p => p.LastExamine != null && Math.Abs(p.LastExamine.Med - stiffness) < 0.1).ToList();
                }
            }

            if (SystemStatusFilter != null && (SystemStatusFilter.Content as string) != "любой")
            {
                var status = (SystemStatusFilter.Content as string) == "Корректно";

                filteredPatients = filteredPatients.Where(p => p.LastExamine != null && p.LastExamine.Valid == status).ToList();
            }

            if (ExpertStatusFilter != null && (ExpertStatusFilter.Content as string) != "любой")
            {
                ExpertStatus status;

                switch (ExpertStatusFilter.Content as string)
                {
                    case "Корректно": status = ExpertStatus.Confirmed;
                        break;
                    case "Некорректно": status = ExpertStatus.Unconfirmed;
                        break;
                    default: status = ExpertStatus.Pending;
                        break;
                }

                filteredPatients = filteredPatients.Where(p => p.LastExamine != null && p.LastExamine.ExpertStatus == status).ToList();
            }
            
            FilteredPatients.Clear();
            FilteredPatients.AddRange(filteredPatients);
        }

        public PatientViewModel()
        {
            var patients = PatientsRepository.Instance.GetAll();
            Patients = new ObservableCollection<Patient>(patients);
            FilteredPatients = new ObservableCollection<Patient>(patients);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName != null && propertyName.EndsWith("Filter"))
            {
                FilterPatients();
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public ExamineViewModel LastExamine => Examines.LastOrDefault();

        //public string FormattedFullName => $"{LastName} {FirstName} {MiddleName}";

        //public string FormattedInitials => $"{LastName} {FirstName.ToUpper().Substring(0, 1)} {MiddleName.ToUpper().Substring(0, 1)}";

        //public string FormattedBloodGroup
        //{
        //    get
        //    {
        //        string group;

        //        switch (BloodGroup)
        //        {
        //            case 1:
        //                group = "o (I)";
        //                break;
        //            case 2:
        //                group = "A (II)";
        //                break;
        //            case 3:
        //                group = "B (III)";
        //                break;
        //            case 4:
        //                group = "AB (IV)";
        //                break;
        //            default:
        //                group = "Нет данных";
        //                break;
        //        }

        //        string rh = "";
        //        if (RhFactor.HasValue)
        //        {
        //            var t = RhFactor.Value ? "+" : "-";
        //            rh = $" (Rh{t})";
        //        }

        //        return $"{group}{rh}";
        //    }
        //}
    }
}
