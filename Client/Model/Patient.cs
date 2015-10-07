namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public enum PatientGender
    {
        Male,
        Female
    };

    [Table("public.patients")]
    public partial class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(255)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required]
        [Column("birthdate", TypeName = "date")]
        public DateTime Birthdate { get; set; }

        [Required]
        [StringLength(12)]
        [Column("iin")]
        public string Iin { get; set; }

        [Required]
        [Column("gender")]
        public PatientGender Gender { get; set; }

        [Column("blood_group")]
        public int? BloodGroup { get; set; }

        [Column("rh_factor")]
        public bool? RhFactor { get; set; }

    }
}
