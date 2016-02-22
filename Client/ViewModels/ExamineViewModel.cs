namespace Client.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Cimbalino.Toolkit.Extensions;
    using Repositories;
    using System;
    using Models;

    public class ExamineViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Examine> _examines;
        private ObservableCollection<Examine> _filteredExamines;
        private Patient _patient;
        private DateTimeOffset _dateFromFilter = new DateTimeOffset(DateTime.Now);
        private DateTimeOffset _dateToFilter = new DateTimeOffset(DateTime.Now);
        private string _stiffnessFilter;

        public ObservableCollection<Examine> Examines
        {
            get { return _examines; }
            set
            {
                _examines = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Examine> FilteredExamines
        {
            get { return _filteredExamines; }
            set
            {
                _filteredExamines = value;
                OnPropertyChanged();
            }
        }

        public DateTimeOffset DateFromFilter
        {
            get { return _dateFromFilter; }
            set
            {
                _dateFromFilter = value;
                OnPropertyChanged();
            }
        }

        public DateTimeOffset DateToFilter
        {
            get { return _dateToFilter; }
            set
            {
                _dateToFilter = value;
                OnPropertyChanged();
            }
        } 

        public Patient Patient
        {
            get { return _patient; }
            set
            {
                _patient = value;
                OnPropertyChanged();
            }
        }

        public string StiffnessFilter
        {
            get { return _stiffnessFilter; }
            set
            {
                _stiffnessFilter = value;
                OnPropertyChanged();
            }
        }

        public ExamineViewModel(Patient patient)
        {
            Patient = patient;

            var examines = ExaminesRepository.Instance.GetPatientExamines(Patient);
            Examines = new ObservableCollection<Examine>(examines);
            FilteredExamines = new ObservableCollection<Examine>(examines);

            var createdAt = Examines.FirstOrDefault()?.CreatedAt;
            if (createdAt != null)
            {
                DateToFilter = new DateTimeOffset(createdAt.Value);
            }

            var dateTime = Examines.LastOrDefault()?.CreatedAt;
            if (dateTime != null)
            {
                DateFromFilter = new DateTimeOffset(dateTime.Value);
            }
        }
        
        public void FilterPatients()
        {
            var filteredExamines = Examines.ToList();

            filteredExamines = filteredExamines.Where(e => e.CreatedAt >= DateFromFilter && e.CreatedAt <= DateToFilter).ToList();

            if (!string.IsNullOrEmpty(StiffnessFilter))
            {
                double stiffness = 0;

                try
                {
                    stiffness = double.Parse(StiffnessFilter, CultureInfo.InvariantCulture);
                }
                finally
                {
                    filteredExamines = filteredExamines.Where(e => Math.Abs(e.Med - stiffness) < 0.1).ToList();
                }
            }

            FilteredExamines.Clear();
            FilteredExamines.AddRange(filteredExamines);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName != null && propertyName.EndsWith("Filter"))
            {
                FilterPatients();
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
