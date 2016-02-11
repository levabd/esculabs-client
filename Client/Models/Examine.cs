using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public enum ExpertStatus
    {
        Pending,
        Confirmed,
        Unconfirmed,
    }

    public class Examine : BaseModel
    {
        public int              Id { get; set; }

        [Required]
        public Patient          Patient { get; set; }

        public User             User { get; set; }

        //public string           PatientIin { get; set; }

        public string           SensorType { get; set; }

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
