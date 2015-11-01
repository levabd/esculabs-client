namespace Client.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ModuleFramework;

    [Table("public.patients")]
    public partial class Patient : IPatient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        public string FullNameString
        {
            get
            {
                return $"{LastName} {FirstName} {MiddleName}";
            }
        }

        public string BloodGroupString
        {
            get
            {
                string group;

                switch (BloodGroup)
                {
                    case (1):
                        group = "o (I)";
                        break;
                    case (2):
                        group = "A (II)";
                        break;
                    case (3):
                        group = "B (III)";
                        break;
                    case (4):
                        group = "AB (IV)";
                        break;
                    default:
                        group = "Нет данных";
                        break;
                }

                var rh = RhFactor.HasValue && RhFactor.Value ? "+" : "-";

                return $"{group} (Rh{rh})";
            }
        }

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required]
        [Column("birthdate", TypeName = "date")]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// ИИН
        /// </summary>
        [Required]
        [Index("IX_Iin", 1, IsUnique = true)]
        [StringLength(12)]
        [Column("iin")]
        public string Iin { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        [Required]
        [Column("gender")]
        public PatientGender Gender { get; set; }

        /// <summary>
        /// Группа крови
        /// </summary>
        [Column("blood_group")]
        public int? BloodGroup { get; set; }

        /// <summary>
        /// Резус-фактор
        /// </summary>
        [Column("rh_factor")]
        public bool? RhFactor { get; set; }

         
    }
}
