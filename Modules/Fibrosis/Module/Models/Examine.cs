using System;

namespace Fibrosis.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum SensorType
    {
        Small,
        Medium,
        Xl
    }

    [Table("fibrosis.examines")]
    public class Examine
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Column("physician_id")]
        public int PhysicianId { get; set; }

        [Column("sensor_type")]
        public SensorType SensorType { get; set; }

        [Column("e_med")]
        public double Med { get; set; }

        [Column("e_iqr")]
        public double Iqr { get; set; }

        [Column("duration")]
        public int Duration { get; set; }

        [Column("whisker_plot")]
        public string WhiskerPlot { get; set; }

        [Column("valid")]
        public bool Valid { get; set; }

        [Column("expert_status")]
        public ExpertStatus ExpertStatus { get; set; }

        [Column("created_at", TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Measure> Measures { get; set; }
    }
}
