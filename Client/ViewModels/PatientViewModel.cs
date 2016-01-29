using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace Client.ViewModels
{
    using System.Collections.ObjectModel;
    using Repositories;
    using Models;

    public class PatientViewModel : BaseViewModel
    {
        private ObservableCollection<ExamineViewModel> _patients;

        public ObservableCollection<ExamineViewModel> Patients
        {
            get { return _patients; }
            set
            {
                if (_patients == value)
                {
                    return;
                }

                OnPropertyChanging();
                _patients = value;
                OnPropertyChanged();
            }
        }

        public PatientViewModel()
        {
            Patients = new ObservableCollection<ExamineViewModel>();
            ReloadPatients();
        }

        private async void ReloadPatients()
        {
            Patients.Clear();
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High, async () =>
            {
                var patients = await PatientsRepository.Instance.AllAsync();
                foreach (var p in patients)
                {
                    Patients.Add(new ExamineViewModel(p));
                }
            });
        }
    }
}
