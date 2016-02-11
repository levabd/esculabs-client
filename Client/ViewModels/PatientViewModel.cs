using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Client.Context;
using Client.Repositories;
using Microsoft.Data.Entity;

namespace Client.ViewModels
{
    using Models;

    public class PatientViewModel : BaseViewModel
    {
        private ObservableCollection<Patient> _patients;

        public ObservableCollection<Patient> Patients
        {
            get { return _patients; }
            set
            {
                _patients = value;
                OnPropertyChanged();
            }
        }

        public PatientViewModel()
        {
            var patients = PatientsRepository.Instance.GetAll();
            Patients = new ObservableCollection<Patient>(patients);
        }

        //  public ExamineViewModel LastExamine => Examines.LastOrDefault();

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
