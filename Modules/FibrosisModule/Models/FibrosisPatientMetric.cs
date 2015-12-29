namespace FibrosisModule.Models
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.ComponentModel.DataAnnotations;

    public class FibrosisPatientMetric : INotifyPropertyChanged
    {
        private int     _id;
        private int     _patientId;
        private double? _tp;
        private double? _scd;

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

        public double? Tp
        {
            get { return _tp; }
            set
            {
                if (_tp == value)
                {
                    return;
                }

                _tp = value;
                OnPropertyChanged();
            }
        }

        public double? Scd
        {
            get { return _scd; }
            set
            {
                if (_scd == value)
                {
                    return;
                }

                _scd = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
