using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Client.Helpers;

namespace Client.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    // using FibroscanProcessor;

    public class Measure : INotifyPropertyChanged
    {
        private int             _id;
        private string          _sourceImage;
        private string          _processedImage;
        private int             _validationModeA;
        private int             _validationModeM;
        private int             _validationElasto;
        private double          _stiffness;
        private DateTime?       _createdAt;

        private Examine         _examine;

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

        public string SourceImage
        {
            get { return _sourceImage; }
            set
            {
                if (_sourceImage == value)
                {
                    return;
                }

                _sourceImage = value;

                OnPropertyChanged();
            }
        }

        public string ProcessedImage
        {
            get { return _processedImage; }
            set
            {
                if (_processedImage == value)
                {
                    return;
                }

                _processedImage = value;
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

        [Required]
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

        [NotMapped]
        //public bool Correct => ValidationModeA != VerificationStatus.Incorrect &&
        //                         ValidationModeM != VerificationStatus.Incorrect &&
        //                         ValidationElasto != VerificationStatus.Incorrect;
        public bool Correct => false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
