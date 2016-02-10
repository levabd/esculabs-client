using System.Collections.Generic;

namespace Client.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public enum PatientGender
    {
        Male,
        Female
    }

    public class Patient
    {
        /// <summary>
        /// ИИН
        /// </summary>
        [Key]
        public string Iin { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string FirstName { get; set; }
   

        /// <summary>
        /// Отчество
        /// </summary>
        [Required]
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public PatientGender Gender { get; set; }

        /// <summary>
        /// Группа крови
        /// </summary>
        public int? BloodGroup { get; set; }

        /// <summary>
        /// Резус-фактор
        /// </summary>
        public bool? RhFactor { get; set; }

        public virtual ICollection<Examine> Examines { get; set; }

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
