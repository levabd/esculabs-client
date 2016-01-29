using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Cimbalino.Toolkit.Extensions;
using Client.Models;
using Client.Repositories;
using FibrosisModule.Models;

namespace Client.ViewModels
{
    public class ExamineViewModel : BaseViewModel
    {
        private Patient _patient;
        private ObservableCollection<FibrosisExamine> _examines;

        private FibrosisExamine _selectedExamine ;

        public ObservableCollection<FibrosisExamine> Examines
        {
            get { return _examines; }
            set
            {
                if (_examines == value)
                {
                    return;
                }

                OnPropertyChanging();
                _examines = value;
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

                OnPropertyChanging();
                _patient = value;
                OnPropertyChanged();
            }
        }

        public FibrosisExamine SelectedExamine
        {
            get { return _selectedExamine; }
            set
            {
                if (_selectedExamine == value)
                {
                    return;
                }

                OnPropertyChanging();
                _selectedExamine = value;
                OnPropertyChanged();
            }
        }

        public FibrosisExamine LastExamine => Examines.FirstOrDefault();

        public ExamineViewModel(Patient patient, FibrosisExamine selectedExamine = null)
        {
            Examines = new ObservableCollection<FibrosisExamine>();
            SelectedExamine = selectedExamine;

            Patient = patient;

            ReloadExamines();
        }

        private void ReloadExamines()
        {
            Examines.Clear();

            switch (Patient.Iin)
            {
                case "831223387948":
                    Examines.Add(
                        new FibrosisExamine()
                        {
                            CreatedAt = new DateTime(2013, 2, 1, 9, 23, 0),
                            Duration = 224,
                            ExpertStatus = ExpertStatus.Pending,
                            Iqr = 5.2,
                            PatientIin = "831223387948",
                            Valid = true,
                            Med = 12,
                            SensorType = SensorType.Xl,
                            SourceImage = "ms-appx:///Assets/Measures/1/01before.jpg"
                        });
                    break;
                case "911001387949":
                    Examines.AddRange(new List<FibrosisExamine>()
                    {
                        new FibrosisExamine()
                        {
                            CreatedAt = new DateTime(2014, 12, 14, 10, 1, 0),
                            Duration = 326,
                            ExpertStatus = ExpertStatus.Pending,
                            Iqr = 5.8,
                            PatientIin = "911001387949",
                            Valid = true,
                            Med = 14.2,
                            SensorType = SensorType.Medium,
                            SourceImage = "ms-appx:///Assets/Measures/1/02before.jpg"
                        },
                        new FibrosisExamine()
                        {
                            CreatedAt = new DateTime(2013, 8, 23, 11, 1, 0),
                            Duration = 122,
                            ExpertStatus = ExpertStatus.Pending,
                            Iqr = 6.1,
                            PatientIin = "911001387949",
                            Valid = true,
                            Med = 8,
                            SensorType = SensorType.Xl,
                            SourceImage = "ms-appx:///Assets/Measures/1/06before.jpg"
                        },
                        new FibrosisExamine()
                        {
                            CreatedAt = new DateTime(2013, 4, 7, 16, 27, 0),
                            Duration = 248,
                            ExpertStatus = ExpertStatus.Pending,
                            Iqr = 4.2,
                            PatientIin = "911001387949",
                            Valid = true,
                            Med = 13,
                            SensorType = SensorType.Medium,
                            SourceImage = "ms-appx:///Assets/Measures/1/07before.jpg"
                        }   
                    });
                    break;
                case "831223387947":
                    Examines.Add(
                       new FibrosisExamine()
                       {
                           CreatedAt = new DateTime(2013, 12, 11, 13, 56, 0),
                           Duration = 228,
                           ExpertStatus = ExpertStatus.Pending,
                           Iqr = 8.1,
                           PatientIin = "831223387947",
                           Valid = true,
                           Med = 10,
                           SensorType = SensorType.Small,
                           ProcessedImage = "../Assets/Measures/1/08before.jpg"
                       });
                    break;
                default:
                    break;
            }
        }
    }
}
