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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Client
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using MongoDB.Driver.Linq;
    using MongoRepository;
    using System.Data.Entity;
    using Repo;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility =
                      row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var patients = PatientsRepo.GridList();

            if (patients == null || !patients.Any())
            {
                return;
            }

            patientsGrid.ItemsSource = patients;

            //DataTable patientsTable = new DataTable();

            //MongoRepository<Examine> examines = new MongoRepository<Examine>();

            //List<Patient> patients = new PgContext().Patients.OrderByDescending(p => p.Id).ToList();       
            //List<int> patientsIds = patients.Select(p => p.Id).ToList();                        
            //List<Examine> examinesPool = examines.Where(ex => patientsIds.Contains(ex.PatientId))
            //    .OrderByDescending(ex => ex.CreatedAt)
            //    .ToList();

            //List<TablePatient> tablePatients = new List<TablePatient>();
            //foreach (Patient patient in patients)
            //{
            //    var patientExamines = examinesPool.Where(ex => ex.PatientId == patient.Id).ToList();

            //    if (patientExamines.Any())
            //    {
            //        var examine = patientExamines.First();
            //        var tp = new TablePatient(patient, examine);

            //        tablePatients.Add(tp);
            //    }
            //}
        }
    }
}
