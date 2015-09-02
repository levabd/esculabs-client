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
    using System.Windows.Controls.Primitives;
    using Repo;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string NameSearchText = "Поиск по ФИО...";
        private const string DateSearchText = "Поиск по дате последнего сканирования...";

        private List<TablePatient> patients = new List<TablePatient> { };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RefreshFilter()
        {
            IEnumerable<TablePatient> list = patients;
            string name = nameFilterTextBox.Text;
            DateTime? date = dateFilterDatePicker.SelectedDate;

            bool applyNameFilter = !string.IsNullOrWhiteSpace(name) && !name.Equals(NameSearchText);
            bool applyDateFilter = (date != null);

            if (applyNameFilter || applyDateFilter)
            {
                list = list.Where(x => (applyNameFilter ? x.Name.Contains(name) : true) &&
                    (applyDateFilter ? (DateTime.Compare(x.LastExamineDate.Date, date.Value.Date) == 0) : true));
            }

            /*if (!string.IsNullOrWhiteSpace(name) && !name.Equals(NameSearchText))
            {
                list = list.Where(x => x.Name.Contains(name));
            }*/

            //if (date != null)
            //{
            //    list = list.Where(x => x.LastExamineDate.Date == ((DateTime)date).Date) as List<TablePatient>;
            //}

            patientsGrid.ItemsSource = list;
            //MessageBox.Show('')
        }

        private void SetDatePickerText(DatePicker dp, string text = null)
        {
            DatePickerTextBox datePickerTextBox = FindVisualChild<DatePickerTextBox>(dp);
            if (datePickerTextBox != null)
            {
                ContentControl watermark = datePickerTextBox.Template.FindName("PART_Watermark", datePickerTextBox) as ContentControl;
                if (watermark != null)
                {
                    watermark.Content = text == null ? DateSearchText : text;
                }
            }
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
            nameFilterTextBox.Text = NameSearchText;
            
            patients = PatientsRepo.GridList();

            if (patients == null || !patients.Any())
            {
                return;
            }

            patientsGrid.ItemsSource = patients;
        }

        private void nameFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshFilter();
        }

        private void clearNameFilterButton_Click(object sender, RoutedEventArgs e)
        {
            nameFilterTextBox.Text = NameSearchText;
        }

        private void nameFilterTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (nameFilterTextBox.Text.Equals(NameSearchText))
            { 
                nameFilterTextBox.Text = "";
            }
        }

        private void nameFilterTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (nameFilterTextBox.Text.Length == 0)
            {
                nameFilterTextBox.Text = NameSearchText;
            }
        }

        private void dateFilterDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshFilter();
        }

        private void clearDateFilterButton_Click(object sender, RoutedEventArgs e)
        {
            dateFilterDatePicker.SelectedDate = null;
            SetDatePickerText(dateFilterDatePicker);
        }

        private void patientsGrid_Loaded(object sender, RoutedEventArgs e)
        {
            nameFilterTextBox.IsEnabled = true;
            dateFilterDatePicker.IsEnabled = true;
            clearNameFilterButton.IsEnabled = true;
            clearDateFilterButton.IsEnabled = true;
        }

        private void dateFilterDatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            if (datePicker != null)
            {
                SetDatePickerText(datePicker);
            }
        }

        private T FindVisualChild<T>(DependencyObject depencencyObject) where T : DependencyObject
        {
            if (depencencyObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depencencyObject); ++i)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depencencyObject, i);
                    T result = (child as T) ?? FindVisualChild<T>(child);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }
    }
}
