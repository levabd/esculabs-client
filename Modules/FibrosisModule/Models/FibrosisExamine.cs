namespace FibrosisModule.Models
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

    public class FibrosisExamine : INotifyPropertyChanged
    {
        private int                     _id;
        private int                     _patientId;
        private int                     _physicianId;
        private SensorType              _sensorType;
        private double                  _med;
        private double                  _iqr;
        private int                     _duration;
        private byte[]                  _whiskerPlot;
        private bool                    _valid;
        private ExpertStatus            _expertStatus;
        private string                  _fibxSource;
        private DateTime?               _createdAt;
        private List<FibrosisMeasure>   _measures;

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

        [Required]
        public int PatientId
        {
            get { return _patientId; }
            set
            {
                if (_patientId == value)
                {
                    return;
                }

                _patientId = value;
                OnPropertyChanged();
            }
        }

        [Required]
        public int PhysicianId
        {
            get { return _physicianId; }
            set
            {
                if (_physicianId == value)
                {
                    return;
                }

                _physicianId = value;
                OnPropertyChanged();
            }
        }

        public SensorType SensorType
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

        public List<FibrosisMeasure> Measures
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

        //public string FibrosisStage
        //{
        //    get
        //    {
        //        if (Med == 0)
        //        {
        //            return "Нет данных";
        //        }

        //        if (Med > 12.5f)
        //        {
        //            return "F4";
        //        }

        //        if (Med >= 9.6f)
        //        {
        //            return "F3";
        //        }

        //        if (Med >= 7.3f)
        //        {
        //            return "F2";
        //        }

        //        if (Med >= 5.9f)
        //        {
        //            return "F1";
        //        }

        //        if (Med >= 1.5f)
        //        {
        //            return "F0";
        //        }

        //        return "Отсутствует";
        //    }
        //}

        //public int? IqrMed
        //{
        //    get
        //    {
        //        try
        //        {
        //            return Convert.ToInt32(Math.Round(Iqr / Med * 100));
        //        }
        //        catch (Exception)
        //        {
        //            return null;
        //        }
        //    }
        //}

        //public bool Validate() => IqrMed > 30;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
