using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Models;

    public class ExamineViewModel : BaseViewModel
    {

        private ObservableCollection<Examine> _examines;
        private Patient _patient;

        public ObservableCollection<Examine> Examines
        {
            get { return _examines; }
            set
            {
                _examines = value;
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

        public ExamineViewModel(Patient patient)
        {
            Patient = patient;
            Examines = Patient.Examines;
        }

        /*
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
        */

        public ExamineViewModel()
        {
   
        }
    }
}
