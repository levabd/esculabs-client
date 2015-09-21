using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client
{
    using Microsoft.Win32;
    using Model;
    using MongoRepository;
    using System.IO;
    using System.Windows.Media.Effects;

    /// <summary>
    /// Interaction logic for ExaminesWindow.xaml
    /// </summary>
    public partial class ExaminesWindow : Window
    {
        private Patient patient = null;
        private List<TableExamine> examines = new List<TableExamine>();

        public ExaminesWindow()
        {
            InitializeComponent();
        }

        public ExaminesWindow(Patient Patient) : this()
        {
            patient = Patient;

            if (patient != null)
            {
                RefreshExaminesList();
            }
        }

        private void RefreshExaminesList()
        {
            MongoRepository<Examine> examinesRepo = new MongoRepository<Examine>();

            var patientExamines = examinesRepo.Where(ex => ex.PatientId == patient.Id)
                .OrderByDescending(ex => ex.CreatedAt).ToList();

            if (examines != null && examines.Any())
            {
                examines.Clear();
            }

            examines = new List<TableExamine>();

            var i = patientExamines.Count;
            foreach (Examine examine in patientExamines)
            {
                examines.Add(new TableExamine(examine, i));
                --i;
            }
        }

        private void newMeasureBtn_Click(object sender, RoutedEventArgs e)
        {
            //ExamineWindow window = new ExamineWindow();
            //window.ShowDialog();
        }

        private void ShowExamine(object sender, RoutedEventArgs e)
        {
            TableExamine tableExamine = ((FrameworkElement)sender).DataContext as TableExamine;

            MongoRepository<Examine> examinesRepo = new MongoRepository<Examine>();
            var examine = examinesRepo.Where(x => x.Id == tableExamine.Guid).FirstOrDefault() as Examine;

            if (examine != null)
            {
                ExamineWindow window = new ExamineWindow(patient, examine);
                window.Owner = this;
                window.ShowDialog();
                RefreshExaminesList();
            }
            else
            {
                MessageBox.Show("Не удалось найти обследование");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (patient != null)
            {
                nameLabel.Content = string.Format("{0} {1} {2}", patient.LastName, patient.FirstName, patient.MiddleName);
                examinesGrid.ItemsSource = examines;
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void importFbixBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                var blur = new BlurEffect();
                blur.Radius = 4;
                Effect = blur;

                var loader = new LoaderWindow();
                loader.Owner = this;
                loader.Show();

                var examine = FIBXParser.Instance.Import(openFileDialog.FileName, patient.Id);

                if (examine != null && IsLoaded)
                {
                    RefreshExaminesList();
                    examinesGrid.ItemsSource = examines;
                }

                loader.Close();
                Effect = null;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var window = Application.Current.MainWindow as PatientsWindow;
            window.RefreshPatientsList();
            window.Activate();
        }
    }
}
