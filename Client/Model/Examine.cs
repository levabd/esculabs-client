using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
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
        Correct,
        Incorrect,
        Uncertain,
        NotCalculated
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
            ElastoExams = new List<ElastoExam>();
        }

        [BsonElement("patient_id")]
        public int PatientId { get; set; }

        [BsonElement("physician_id")]
        public int PhysicianId { get; set; }

        [BsonElement("created_at")]
        public DateTime? CreatedAt { get; set; }

        [BsonElement("elasto_exams")]
        public List<ElastoExam> ElastoExams { get; set; }
    }

    public partial class ElastoExam : Entity
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

        [BsonElement("measures")]
        public List<Measure> Measures { get; set; }

        [BsonElement("valid")]
        public bool Valid { get; set; }

        [BsonElement("expert_status")]
        public ExpertStatus ExpertStatus { get; set; }
    }

    public partial class Measure : Entity
    {
        public Measure()
        {
            Source = new Image();
            ResultMerged = new Image();
            ResultModeA = new Image();
            ResultModeM = new Image();
            ResultElasto = new Image();
        }

        [BsonElement("source")]
        public Image Source { get; set; }

        [BsonElement("result_merged")]
        public Image ResultMerged { get; set; }

        [BsonElement("result_mode_a")]
        public Image ResultModeA { get; set; }

        [BsonElement("result_mode_m")]
        public Image ResultModeM { get; set; }

        [BsonElement("result_elasto")]
        public Image ResultElasto { get; set; }

        [BsonElement("validation_mode_a")]
        public VerificationStatus ValidationModeA { get; set; }

        [BsonElement("validation_mode_m")]
        public VerificationStatus ValidationModeM { get; set; }

        [BsonElement("validation_elasto")]
        public VerificationStatus ValidationElasto { get; set; }

        [BsonElement("stiffness")]
        public double stiffness { get; set; }
    }
}
