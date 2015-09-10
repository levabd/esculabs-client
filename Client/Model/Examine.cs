﻿using System;
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

    public enum ExamineType
    {
        MONITORING,
        NOT_MONITORING
    };

    [BsonIgnoreExtraElements]
    [CollectionName("examines")]
    public partial class Examine : Entity
    {
        public Examine()
        {
            Params = new List<object>();
        }

        [BsonElement("patient_id")]
        public int PatientId { get; set; }

        [BsonElement("physician_id")]
        public int PhysicianId { get; set; }

        [BsonElement("type")]
        public ExamineType Type { get; set; }

        [BsonElement("is_opened")]
        public bool Opened { get; set; }

        [BsonElement("phibrosis_stage")]
        public string PhibrosisStage { get; set; }

        [BsonElement("local_status")]
        public string LocalStatus { get; set; }

        [BsonElement("expert_status")]
        public string ExpertStatus { get; set; }

        [BsonElement("created_at")]
        public DateTime? CreatedAt { get; set; }

        [BsonElement("params")]
        public List<object> Params { get; set; }
    }
}
