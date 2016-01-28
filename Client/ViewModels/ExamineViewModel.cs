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
    class ExamineViewModel : BaseViewModel
    {
        private Patient _patient;
        private ObservableCollection<FibrosisExamine> _examines;

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

        public ExamineViewModel(Patient patient)
        {
            Examines = new ObservableCollection<FibrosisExamine>();

            Patient = patient;

            ReloadExamines();
        }

        private void ReloadExamines()
        {
            Examines.Clear();

            Examines.AddRange(new List<FibrosisExamine>()
            {
                new FibrosisExamine()
                {
                    CreatedAt = new DateTime(2013, 2, 1),
                    Duration = 224,
                    ExpertStatus = ExpertStatus.Pending,
                    Iqr = 5.2,
                    PatientIin = "831223387948",
                    Valid = true,
                    Med = 12,
                    SensorType = SensorType.Xl
                },
                new FibrosisExamine()
                {
                    CreatedAt = new DateTime(2014, 12, 14),
                    Duration = 326,
                    ExpertStatus = ExpertStatus.Pending,
                    Iqr = 5.8,
                    PatientIin = "911001387949",
                    Valid = true,
                    Med = 14.2,
                    SensorType = SensorType.Medium
                },
                new FibrosisExamine()
                {
                    CreatedAt = new DateTime(2013, 8, 23),
                    Duration = 122,
                    ExpertStatus = ExpertStatus.Pending,
                    Iqr = 6.1,
                    PatientIin = "911001387949",
                    Valid = true,
                    Med = 8,
                    SensorType = SensorType.Xl
                },
                new FibrosisExamine()
                {
                    CreatedAt = new DateTime(2013, 4, 7),
                    Duration = 248,
                    ExpertStatus = ExpertStatus.Pending,
                    Iqr = 4.2,
                    PatientIin = "911001387949",
                    Valid = true,
                    Med = 13,
                    SensorType = SensorType.Medium
                },
                new FibrosisExamine()
                {
                    CreatedAt = new DateTime(2013, 12, 11),
                    Duration = 228,
                    ExpertStatus = ExpertStatus.Pending,
                    Iqr = 8.1,
                    PatientIin = "831223387947",
                    Valid = true,
                    Med = 10,
                    SensorType = SensorType.Small
                }
            });
        }
    }
}
