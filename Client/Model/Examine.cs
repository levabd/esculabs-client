using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using MongoRepository;
    using System.Windows.Controls;

    public enum SensorType
    {
        Small,
        Medium,
        XL,
    }

    public enum VerificationStatus
    {
        NotCalculated,
        Incorrect,
        Uncertain,
        Correct
    }

    public enum ExpertStatus
    {
        Pending,
        Confirmed,
        Unconfirmed,
    }

    [BsonIgnoreExtraElements]
    [CollectionName("examines")]
    public partial class Examine : Entity
    {
        public Examine()
        {
            ElastoExam = null;
        }

        [BsonElement("patient_id")]
        public int PatientId { get; set; }

        [BsonElement("physician_id")]
        public int PhysicianId { get; set; }

        [BsonElement("created_at")]
        public DateTime? CreatedAt { get; set; }

        [BsonElement("elasto_exam")]
        public ElastoExam ElastoExam { get; set; }
    }

    public partial class ElastoExam
    {
        public ElastoExam()
        {
            Measures = new List<Measure>();
        }

        public string PhibrosisStage
        {
            get
            {
                if (MED == 0)
                {
                    return "Нет данных";
                }

                if (MED > 12.5f)
                {
                    return "F4";
                }

                if (MED >= 9.6f)
                {
                    return "F3";
                }

                if (MED >= 7.3f)
                {
                    return "F2";
                }

                if (MED >= 5.9f)
                {
                    return "F1";
                }

                if (MED >= 1.5f)
                {
                    return "F0";
                }

                return "Отсутствует";
            }
        }

        [BsonElement("sensor_type")]
        public SensorType SensorType { get; set; }

        [BsonElement("e_med")]
        public double MED { get; set; }

        [BsonElement("e_iqr")]
        public double IQR { get; set; }

        [BsonElement("duration")]
        public int Duration { get; set; }

        [BsonElement("whisker_plot")]
        public string WhiskerPlot { get; set; }

        [BsonElement("measures")]
        public List<Measure> Measures { get; set; }

        [BsonElement("valid")]
        public bool Valid { get; set; }

        [BsonElement("expert_status")]
        public ExpertStatus ExpertStatus { get; set; }
    }

    public partial class Measure
    {
        public bool IsCorrect
        {
            get
            {
                return (ValidationModeA & ValidationModeM & ValidationElasto) == 0;
            }
        }

        [BsonElement("source")]
        public string Source { get; set; }
                
        [BsonElement("result_merged")]
        public string ResultMerged { get; set; }

        [BsonElement("result_mode_a")]
        public string ResultModeA { get; set; }

        [BsonElement("result_mode_m")]
        public string ResultModeM { get; set; }

        [BsonElement("result_elasto")]
        public string ResultElasto { get; set; }

        [BsonElement("validation_mode_a")]
        public VerificationStatus ValidationModeA { get; set; }

        [BsonElement("validation_mode_m")]
        public VerificationStatus ValidationModeM { get; set; }

        [BsonElement("validation_elasto")]
        public VerificationStatus ValidationElasto { get; set; }

        [BsonElement("stiffness")]
        public double Stiffness { get; set; }
    }
}
