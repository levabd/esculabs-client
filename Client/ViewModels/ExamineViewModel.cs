using System.ComponentModel.DataAnnotations.Schema;

namespace Client.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Models;

    public class ExamineViewModel : BaseViewModel
    {
        #region private fields

        private Examine                 _examine;
        private Patient                 _patient;
        private User                    _user;

        private int                     _id;
        private string                  _sensorType;
        private double                  _med;
        private double                  _iqr;
        private int                     _duration;
        private byte[]                  _whiskerPlot;
        private bool                    _valid;
        private ExpertStatus            _expertStatus;
        private string                  _fibxSource;
        private DateTime?               _createdAt;
        private PatientMetric           _patientMetric;
        private List<Measure>           _measures;

        #endregion

        public Examine Examine
        {
            get { return _examine; }
            set
            {
                if (_examine == value)
                {
                    return;
                }

                _examine = value;
                OnPropertyChanged();
            }
        }

        public Patient Patient
        {
            get { return _patient; }
            set
            {
                if (_patient == value)
                {
                    return;
                }

                _patient = value;
                OnPropertyChanged();
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                if (_user == value)
                {
                    return;
                }

                _user = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                OnPropertyChanged();
            }
        }

        public string SensorType
        {
            get { return _sensorType; }
            set
            {
                if (_sensorType == value)
                {
                    return;
                }

                _sensorType = value;
                OnPropertyChanged();
            }
        }

        public double Med
        {
            get { return _med; }
            set
            {
                if (_med == value)
                {
                    return;
                }

                _med = value;
                OnPropertyChanged();
            }
        }

        public double Iqr
        {
            get { return _iqr; }
            set
            {
                if (_iqr == value)
                {
                    return;
                }

                _iqr = value;
                OnPropertyChanged();
            }
        }

        public int Duration
        {
            get { return _duration; }
            set
            {
                if (_duration == value)
                {
                    return;
                }

                _duration = value;
                OnPropertyChanged();
            }
        }

        public byte[] WhiskerPlot
        {
            get { return _whiskerPlot; }
            set
            {
                if (_whiskerPlot == value)
                {
                    return;
                }

                _whiskerPlot = value;
                OnPropertyChanged();
            }
        }

        public bool Valid
        {
            get { return _valid; }
            set
            {
                if (_valid == value)
                {
                    return;
                }

                _valid = value;
                OnPropertyChanged();
            }
        }

        public ExpertStatus ExpertStatus
        {
            get { return _expertStatus; }
            set
            {
                if (_expertStatus == value)
                {
                    return;
                }

                _expertStatus = value;
                OnPropertyChanged();
            }
        }

        public string FibxSource
        {
            get { return _fibxSource; }
            set
            {
                if (_fibxSource == value)
                {
                    return;
                }

                _fibxSource = value;
                OnPropertyChanged();
            }
        }

        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set
            {
                if (_createdAt == value)
                {
                    return;
                }

                _createdAt = value;
                OnPropertyChanged();
            }
        }

        public PatientMetric PatientMetric
        {
            get { return _patientMetric; }
            set
            {
                if (_patientMetric == value)
                {
                    return;
                }

                _patientMetric = value;
                OnPropertyChanged();
            }
        }

        public List<Measure> Measures
        {
            get { return _measures; }
            set
            {
                if (_measures == value)
                {
                    return;
                }

                _measures = value;
                OnPropertyChanged();
            }
        }

        public string FormattedFibrosisStage
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

        public bool ValidateIqrMed => IqrMed > 30;

        public ExamineViewModel(Examine examine)
        {
            Id = examine.Id;
            CreatedAt = examine.CreatedAt;
            Duration = examine.Duration;
            ExpertStatus = examine.ExpertStatus;
            FibxSource = examine.FibxSource;
            Iqr = examine.Iqr;
            Measures = examine.Measures;
            Med = examine.Med;
            Patient = examine.Patient;
           // PatientIin = examine.PatientIin;
            PatientMetric = examine.PatientMetric;
           // UserId = examine.UserId;
            SensorType = examine.SensorType;
            Valid = examine.Valid;
            WhiskerPlot = examine.WhiskerPlot;
        }
    }
}
