using System.Windows.Controls;
using Fibrosis.Models;

namespace Fibrosis.Controls
{
    using EsculabsCommon;
    using System.Windows;
    using Repositories;

    /// <summary>
    /// Interaction logic for Widget.xaml
    /// </summary>
    public partial class FibrosisWidget : UserControl
    {
        public IPatient         Patient { get; set; }
        public PatientMetric    PatientMetric { get; set; }
        public Examine          LastExamine { get; set; }

        public FibrosisWidget(IPatient patient)
        {
            InitializeComponent();

            Patient = patient;
            if (Patient != null)
            {
                PatientMetric = FibrosisRepository.Instance.GetPatientMetric(Patient.Id);
                LastExamine = FibrosisRepository.Instance.GetLastExamine(Patient.Id);
            }

            DataContext = this;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
   
        }
    }


}
