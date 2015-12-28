namespace Client.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public enum PatientGender
    {
        Male,
        Female
    }

    public sealed class Patient : BaseModel
    {
        private string _iin;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime _birthdate;
        private PatientGender _gender;
        private int? _bloodGroup;
        private bool? _rhFactor;

        /// <summary>
        /// ИИН
        /// </summary>
        [Key]
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

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
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

        /// <summary>
        /// Отчество
        /// </summary>
        [Required]
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
        
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
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
        
        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required]
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
        
        /// <summary>
        /// Пол
        /// </summary>
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

        /// <summary>
        /// Группа крови
        /// </summary>
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

        /// <summary>
        /// Резус-фактор
        /// </summary>
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
        
        //public string BloodGroupString
        //{
        //    get
        //    {
        //        string group;

        //        switch (BloodGroup)
        //        {
        //            case (1):
        //                group = "o (I)";
        //                break;
        //            case (2):
        //                group = "A (II)";
        //                break;
        //            case (3):
        //                group = "B (III)";
        //                break;
        //            case (4):
        //                group = "AB (IV)";
        //                break;
        //            default:
        //                group = "Нет данных";
        //                break;
        //        }

        //        var rh = RhFactor.HasValue && RhFactor.Value ? "+" : "-";

        //        return $"{group} (Rh{rh})";
        //    }
        //}        
    }
}
