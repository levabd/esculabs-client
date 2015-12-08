using System.Windows.Controls;
using Fibrosis.Models;

namespace Fibrosis.Controls
{
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

        public IPatient                 Patient { get; set; }
        public PatientMetric            PatientMetric { get; set; }
        public Examine                  LastExamine { get; set; }

        public FibrosisWidget(ModuleProvider moduleProvider, IPatient patient)
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
                ViewName = typeof(ExaminesListView).Name,
                ViewInitDelegate = x =>
                {
                    ((ExaminesListView) x).Patient = Patient;
                }
            });
        }
    }
}
