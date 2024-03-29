﻿namespace Fibrosis.Controls
{
    using System.Windows.Controls;
    using EsculabsCommon.Models;
    using Fibrosis.Models;
    using EsculabsCommon;
    using System.Windows;
    using Repositories;
    using Views;

    /// <summary>
    /// Interaction logic for Widget.xaml
    /// </summary>
    public partial class FibrosisWidget : UserControl
    {
        private readonly ModuleProvider _moduleProvider;

        public Patient                 Patient { get; set; }
        public PatientMetric            PatientMetric { get; set; }
        public Examine                  LastExamine { get; set; }

        public FibrosisWidget(ModuleProvider moduleProvider, Patient patient)
        {
            InitializeComponent();

            Patient = patient;
            if (Patient != null)
            {
                PatientMetric = FibrosisRepository.Instance.GetPatientMetric(Patient.Id);
                LastExamine = FibrosisRepository.Instance.GetLastExamine(Patient.Id);
            }

            _moduleProvider = moduleProvider;

            DataContext = this;
        }

        private void AddExamineBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExaminesListBtn_Click(object sender, RoutedEventArgs e)
        {
            _moduleProvider.SetView(new ViewChangeArgs
            {
                ViewName = typeof(ExaminesListView).FullName,
                ViewInitDelegate = x =>
                {
                    ((ExaminesListView) x).Patient = Patient;
                    ((ExaminesListView) x).ModuleProvider = _moduleProvider;
                }
            });
        }
    }
}
