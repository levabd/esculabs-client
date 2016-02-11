using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Client.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public enum PatientGender
    {
        Male,
        Female
    }

    public class Patient : BaseModel
    {
        private string _iin;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime _birthdate;
        private PatientGender _gender;
        private int? _bloodGroup;
        private bool? _rhFactor;
        private ObservableCollection<Examine> _examines;

        /// <summary>
        /// ИИН
        /// </summary>
        [Key]
        public string Iin
        {
            get { return _iin; }
            set
            {
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
                _rhFactor = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Список обследований пользователя
        /// </summary>
        public virtual ObservableCollection<Examine> Examines
        {
            get { return _examines; }
            set
            {
                _examines = value;
                OnPropertyChanged();
                _examines.CollectionChanged += CollectionChangedMethod;
            }
        }

        #region Вычисляемые поля

        /// <summary>
        /// Последнее обследование пользователя
        /// </summary>
        [NotMapped]
        public Examine LastExamine => Examines?.LastOrDefault();

        private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("LastExamine");
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
        #endregion      
    }
}
