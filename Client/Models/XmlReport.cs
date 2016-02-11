using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Client.Models
{
    public sealed class XmlMeasurements
    {
        [XmlElement("Measure")]
        public List<XmlMeasurement> Measures;

        public XmlMeasurements()
        {
            Measures = new List<XmlMeasurement>();
        }
    }

    public sealed class XmlExam
    {
        public string           ExamType;
        public DateTime         Date;
        public XmlResult        Result;
        public XmlMeasurements  Measurements;
    }

    public sealed class XmlMeasurement
    {
        public DateTime     Time;
        public double       Stiffness;
        public string       ImageLink;
    }

    public sealed class XmlResult
    {
        public double       StiffnessMedian;
        public double       StiffnessIQR;
        public int          ExamDuration;
        public string       WhiskerPlotImageLink;
    }

    [XmlRoot("Root", Namespace = "", IsNullable = false)]
    public sealed class XmlReport
    {
        [XmlElement("Exam")]
        public XmlExam              Exam;
    }
}
