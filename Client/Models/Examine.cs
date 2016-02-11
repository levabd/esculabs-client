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
        private int _id;
        private Patient _patient;
        private User _user;
        private string _sensorType;
        private double _med;
        private double _iqr;
        private int _duration;
        private byte[] _whiskerPlot;
        private bool _valid;
        private ExpertStatus _expertStatus;
        private string _fibxSource;
        private DateTime? _createdAt;
        private PatientMetric _patientMetric;
        private List<Measure> _measures;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        [Required]
        public Patient Patient
        {
            get { return _patient; }
            set
            {
                _patient = value;
                OnPropertyChanged();
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public string SensorType
        {
            get { return _sensorType; }
            set
            {
                _sensorType = value;
                OnPropertyChanged();
            }
        }

        public double Med
        {
            get { return _med; }
            set
            {
                _med = value;
                OnPropertyChanged();
            }
        }

        public double Iqr
        {
            get { return _iqr; }
            set
            {
                _iqr = value;
                OnPropertyChanged();
            }
        }

        public int Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        public byte[] WhiskerPlot
        {
            get { return _whiskerPlot; }
            set
            {
                _whiskerPlot = value;
                OnPropertyChanged();
            }
        }

        public bool Valid
        {
            get { return _valid; }
            set
            {
                _valid = value;
                OnPropertyChanged();
            }
        }

        public ExpertStatus ExpertStatus
        {
            get { return _expertStatus; }
            set
            {
                _expertStatus = value;
                OnPropertyChanged();
            }
        }

        public string FibxSource
        {
            get { return _fibxSource; }
            set
            {
                _fibxSource = value;
                OnPropertyChanged();
            }
        }

        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set
            {
                _createdAt = value;
                OnPropertyChanged();
            }
        }

        public PatientMetric PatientMetric
        {
            get { return _patientMetric; }
            set
            {
                _patientMetric = value;
                OnPropertyChanged();
            }
        }

        public List<Measure> Measures
        {
            get { return _measures; }
            set
            {
                _measures = value;
                OnPropertyChanged();
            }
        }
    }
}
