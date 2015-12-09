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

        [Column("whisker_plot", TypeName = "bytea")]
        public byte[] WhiskerPlot { get; set; }

        [Column("valid")]
        public bool Valid { get; set; }

        [Column("expert_status")]
        public ExpertStatus ExpertStatus { get; set; }

        [Column("created_at", TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Measure> Measures { get; set; }

        public string FibrosisStage
        {
            get
            {
                if (Med == 0)
                {
                    return "Нет данных";
                }

                if (Med > 12.5f)
                {
                    return "F4";
                }

                if (Med >= 9.6f)
                {
                    return "F3";
                }

                if (Med >= 7.3f)
                {
                    return "F2";
                }

                if (Med >= 5.9f)
                {
                    return "F1";
                }

                if (Med >= 1.5f)
                {
                    return "F0";
                }

                return "Отсутствует";
            }
        }

        public int? IqrMed
        {
            get
            {
                try
                {
                    return Convert.ToInt32(Math.Round(Iqr / Med * 100));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool Validate() => IqrMed > 30;
    }
}
