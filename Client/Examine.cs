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

    public enum ExamineType
    {
        MONITORING,
        NOT_MONITORING
    };

    [BsonIgnoreExtraElements]
    public partial class Examine : MongoEntity
    {
        public Examine()
        {
           // Params = new List<string>();
        }

        [BsonElement("patient_id")]
        public int PatientId { get; set; }

        [BsonElement("physician_id")]
        public int PhysicianId { get; set; }

        [BsonElement("type")]
        public ExamineType ReleaseDate { get; set; }

        [BsonElement("is_opened")]
        public bool Opened { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("params")]
        public List<string> Params { get; set; }
    }
}
