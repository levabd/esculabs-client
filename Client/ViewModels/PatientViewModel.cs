using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Client.Context;
using Microsoft.Data.Entity;

namespace Client.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Models;

    public class PatientViewModel : BaseViewModel
    {
        private Patient _patient;

        private string _iin;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime _birthdate;
        private PatientGender _gender;
        private int? _bloodGroup;
        private bool? _rhFactor;
        private ObservableCollection<ExamineViewModel> _examines;

        public Patient Patient
        {
            get { return _patient; }
            set
            {
                if (_patient == value)
                {
                    return;
                }

                _patient = value;
                OnPropertyChanged();
            }
        }

        public string Iin
        {
            get { return _iin; }
            set
            {
                if (_iin == value)
                {
                    return;
                }

                _iin = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value)
                {
                    return;
                }

                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (_middleName == value)
                {
                    return;
                }

                _middleName = value;
                OnPropertyChanged();
            }
        }
        
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName == value)
                {
                    return;
                }

                _lastName = value;
                OnPropertyChanged();
            }
        }
        
        public DateTime Birthdate
        {
            get { return _birthdate; }
            set
            {
                if (_birthdate == value)
                {
                    return;
                }

                _birthdate = value;
                OnPropertyChanged();
            }
        }
        
        public PatientGender Gender
        {
            get { return _gender; }
            set
            {
                if (_gender == value)
                {
                    return;
                }

                _gender = value;
                OnPropertyChanged();
            }
        }

        public int? BloodGroup
        {
            get { return _bloodGroup; }
            set
            {
                if (_bloodGroup == value)
                {
                    return;
                }

                _bloodGroup = value;
                OnPropertyChanged();
            }
        }

        public bool? RhFactor
        {
            get { return _rhFactor; }
            set
            {
                if (_rhFactor == value)
                {
                    return;
                }

                _rhFactor = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ExamineViewModel> Examines
        {
            get { return _examines; }
            set
            {
                if (_examines == value)
                {
                    return;
                }

                _examines = value;
                OnPropertyChanged();
                OnPropertyChanged("LastExamine");
            }
        }

        public ExamineViewModel LastExamine => Examines.LastOrDefault();

        public string FormattedFullName => $"{LastName} {FirstName} {MiddleName}";

        public string FormattedInitials => $"{LastName} {FirstName.ToUpper().Substring(0, 1)} {MiddleName.ToUpper().Substring(0, 1)}";

        public string FormattedBloodGroup
        {
            get
            {
                string group;

                switch (BloodGroup)
                {
                    case 1:
                        group = "o (I)";
                        break;
                    case 2:
                        group = "A (II)";
                        break;
                    case 3:
                        group = "B (III)";
                        break;
                    case 4:
                        group = "AB (IV)";
                        break;
                    default:
                        group = "Нет данных";
                        break;
                }

                string rh = "";
                if (RhFactor.HasValue)
                {
                    var t = RhFactor.Value ? "+" : "-";
                    rh = $" (Rh{t})";
                }

                return $"{group}{rh}";
            }
        }

        public PatientViewModel(Patient patient)
        {
            Birthdate = patient.Birthdate;
            BloodGroup = patient.BloodGroup;

            Examines = new ObservableCollection<ExamineViewModel>();
            foreach (var examine in patient.Examines)
            {
                var vm = new ExamineViewModel(examine);
                Examines.Add(vm);
            }

            Patient = patient;
            FirstName = patient.FirstName;
            Gender = patient.Gender;
            Iin = patient.Iin;
            LastName = patient.LastName;
            MiddleName = patient.MiddleName;
            RhFactor = patient.RhFactor;
        }

        public void SaveChanges()
        {
            using (var db = new EsculabsContext())
            {
                db.Entry(Patient).State = EntityState.Modified;

                Patient.Iin = Iin;
                Patient.FirstName = FirstName;
                Patient.MiddleName = MiddleName;
                Patient.LastName = LastName;
                Patient.RhFactor = RhFactor;
                Patient.BloodGroup = BloodGroup;
                Patient.Birthdate = Birthdate;
                Patient.Gender = Gender;

                foreach (var examineViewModel in Examines)
                {
                    
                }
                //Patient.Examines = Examines;

                db.SaveChanges();
            }
        }
    }
}
