namespace Client
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.patients")]
    public partial class Patient
    {
        [StringLength(255)]
        public string id { get; set; }

        [Required]
        [StringLength(255)]
        public string first_name { get; set; }

        [Required]
        [StringLength(255)]
        public string middle_name { get; set; }

        [Required]
        [StringLength(255)]
        public string last_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthdate { get; set; }

        public double? tp { get; set; }

        public double? scd { get; set; }

        [Required]
        [StringLength(12)]
        public string iin { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short gender { get; set; }
    }
}
