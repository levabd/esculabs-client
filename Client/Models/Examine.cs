using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        #region Приватные поля

        private int _id;
        private Patient _patient;
        private User _user;
        private string _sensorType;
        private double _med;
        private double _iqr;
        private int _duration;
        private string _whiskerPlotImage;
        private bool _valid;
        private ExpertStatus _expertStatus;
        private string _fibxSource;
        private DateTime? _createdAt;
        private PatientMetric _patientMetric;
        private ObservableCollection<Measure> _measures;

        #endregion

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

        public string WhiskerPlotImage
        {
            get { return _whiskerPlotImage; }
            set
            {
                _whiskerPlotImage = value;
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

        public ObservableCollection<Measure> Measures
        {
            get { return _measures; }
            set
            {
                _measures = value;
                OnPropertyChanged();
                _measures.CollectionChanged += CollectionChangedMethod;
            }
        }

        #region Вычисляемые поля

        [NotMapped]
        public Measure LastMeasure => Measures?.LastOrDefault();

        [NotMapped]
        public int? MeasuresCount => Measures?.Count;

        [NotMapped]
        public int? CorrectMeasuresCount => Measures?.Count(m => m.Correct);

        #endregion

        public Examine()
        {
            Measures = new ObservableCollection<Measure>();
        }

        private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("LastMeasure");
            OnPropertyChanged("MeasuresCount");
            OnPropertyChanged("CorrectMeasuresCount");
        }
    }
}
