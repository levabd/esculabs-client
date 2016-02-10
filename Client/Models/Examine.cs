using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public enum SensorType
    {
        Small,
        Medium,
        Xl
    }

    public enum ExpertStatus
    {
        Pending,
        Confirmed,
        Unconfirmed,
    }

    public class Examine : BaseModel
    {
        public int              Id { get; set; }

        public Patient          Patient { get; set; }

        [ForeignKey("Patient")]
        public string           PatientIin { get; set; }

        public string           SourceImage { get; set; }

        public string           ProcessedImage { get; set; }

        [Required]
        public int              PhysicianId { get; set; }

        public SensorType       SensorType { get; set; }

        public double           Med { get; set; }

        public double           Iqr { get; set; }

        public int              Duration { get; set; }

        public byte[]           WhiskerPlot { get; set; }

        public bool             Valid { get; set; }

        public ExpertStatus     ExpertStatus { get; set; }

        public string           FibxSource { get; set; }

        public DateTime?        CreatedAt { get; set; }

        public PatientMetric    PatientMetric { get; set; }

        public List<Measure>    Measures { get; set; }
    }
}
