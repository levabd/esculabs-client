namespace Fibrosis.Views
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Data;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Microsoft.Win32;

    using EsculabsCommon;
    using EsculabsCommon.Models;
    using Models;
    using Repositories;
    using Helpers;
    using Controls;

    public partial class ExaminesListView : BaseView, INotifyPropertyChanged
    {
        private ModuleProvider _moduleProvider;
        private Patient _patient;

        public event PropertyChangedEventHandler PropertyChanged;

        public CollectionViewSource Examines { get; private set; }

        public Patient Patient
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
                OnPropertyChanged();
            }
        }

        public ModuleProvider ModuleProvider
        {
            get
            {
                return _moduleProvider;
            }
            set
            {
                _moduleProvider = value;
                OnPropertyChanged();
            }
        }

        public ExaminesListView()
        {
            InitializeComponent();

            Examines = new CollectionViewSource();

            DataContext = this;
        }

        private async void ReloadExaminesList()
        {
            var examinesTask = FibrosisRepository.Instance.AllExaminesAsync(Patient.Id);
            Examines.Source = await examinesTask;
        }

        private void DateFilterTextBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterExaminesList(DateFromFilterTextBox.SelectedDate, DateToFilterTextBox.SelectedDate);
        }

        private void FilterExaminesList(DateTime? dateFrom, DateTime? dateTo)
        {
            Examines.View.Filter = item =>
            {
                var e = item as Examine;

                if (e == null)
                {
                    return true;
                }

                if (!dateFrom.HasValue)
                {
                    dateFrom = DateTime.MinValue;
                }

                if (!dateTo.HasValue)
                {
                    dateTo = DateTime.MaxValue;
                }

                return e.CreatedAt.HasValue &&
                    e.CreatedAt.Value.Date >= dateFrom.Value.Date && e.CreatedAt.Value.Date <= dateTo.Value.Date;
            };
        }

        private void Tile_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var examinesListTile = sender as ExaminesListTile;
            if (examinesListTile != null)
            {
                ModuleProvider?.SetView(new ViewChangeArgs
                {
                    ViewName = typeof (ExamineView).FullName,
                    ViewInitDelegate = x =>
                    {
                        ((ExamineView) x).ModuleProvider = ModuleProvider;
                        ((ExamineView) x).Patient = Patient;
                        ((ExamineView) x).Examine = examinesListTile.DataContext as Examine;
                        ((ExamineView) x).ReloadView();
                    }
                });
            }
        }

        private void AddExamineBtn_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }

            if (FibxParser.Instance.Import(openFileDialog.FileName, _patient.Id))
            {
                ReloadExaminesList();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == "Patient")
            {
                ReloadExaminesList();
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OpenFibxFolder_Click(object sender, RoutedEventArgs e)
        {
            var localPath = $"{ Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Esculabs Import";
            Directory.CreateDirectory(localPath);

            Process.Start(localPath);
        }

        private void ClearDateFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            DateFromFilterTextBox.SelectedDate = DateToFilterTextBox.SelectedDate = null;
        }
    }
}
