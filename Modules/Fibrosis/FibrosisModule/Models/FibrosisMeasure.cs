namespace FibrosisModule.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    // using FibroscanProcessor;

    public class FibrosisMeasure : INotifyPropertyChanged
    {
        private int             _id;
        private byte[]          _source;
        private byte[]          _resultMerged;
        private byte[]          _resultModeA;
        private byte[]          _resultModeM;
        private byte[]          _resultElasto;
        private int             _validationModeA;
        private int             _validationModeM;
        private int             _validationElasto;
        private double          _stiffness;
        private DateTime?       _createdAt;
        private FibrosisExamine _examine;

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

        public byte[] Source
        {
            get { return _source; }
            set
            {
                if (_source == value)
                {
                    return;
                }

                _source = value;
                OnPropertyChanged();
            }
        }

        public byte[] ResultMerged
        {
            get { return _resultMerged; }
            set
            {
                if (_resultMerged == value)
                {
                    return;
                }

                _resultMerged = value;
                OnPropertyChanged();
            }
        }

        public byte[] ResultModeA
        {
            get { return _resultModeA; }
            set
            {
                if (_resultModeA == value)
                {
                    return;
                }

                _resultModeA = value;
                OnPropertyChanged();
            }
        }

        public byte[] ResultModeM
        {
            get { return _resultModeM; }
            set
            {
                if (_resultModeM == value)
                {
                    return;
                }

                _resultModeM = value;
                OnPropertyChanged();
            }
        }

        public byte[] ResultElasto
        {
            get { return _resultElasto; }
            set
            {
                if (_resultElasto == value)
                {
                    return;
                }

                _resultElasto = value;
                OnPropertyChanged();
            }
        }

        public int ValidationModeA
        {
            get { return _validationModeA; }
            set
            {
                if (_validationModeA == value)
                {
                    return;
                }

                _validationModeA = value;
                OnPropertyChanged();
            }
        }

        public int ValidationModeM
        {
            get { return _validationModeM; }
            set
            {
                if (_validationModeM == value)
                {
                    return;
                }

                _validationModeM = value;
                OnPropertyChanged();
            }
        }

        public int ValidationElasto
        {
            get { return _validationElasto; }
            set
            {
                if (_validationElasto == value)
                {
                    return;
                }

                _validationElasto = value;
                OnPropertyChanged();
            }
        }

        public double Stiffness
        {
            get { return _stiffness; }
            set
            {
                if (_stiffness == value)
                {
                    return;
                }

                _stiffness = value;
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

        public FibrosisExamine Examine
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

        //public bool IsCorrect => ValidationModeA != VerificationStatus.Incorrect &&
        //                         ValidationModeM != VerificationStatus.Incorrect &&
        //                         ValidationElasto != VerificationStatus.Incorrect;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
