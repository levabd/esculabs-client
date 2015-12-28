<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
﻿using Common.Logging;
using Common.Logging.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
=======
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
using System.Windows.Shapes;

namespace Client
{
    using Model;
    using Repo;
    using System.Globalization;

    /// <summary>
    /// Interaction logic for NewPatient.xaml
    /// </summary>
    public partial class NewPatientWindow : Window
    {
        private const string DatePickerWatermark = "Выберите дату";
=======
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Views
{
    using System.IO.Ports;
    using EsculabsCommon;
    using EsculabsCommon.Models;
    using EsculabsCommon.Repositories;
    using Common.Logging;
    using System.Configuration;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Interaction logic for AddPatientView.xaml
    /// </summary>
    public partial class AddPatientView : BaseView
    {
        public delegate void BackButtonDelegate();

        public BackButtonDelegate BackButtonFunc;
<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs

        private SerialPort serial;
        private ILog log;

<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
        public NewPatientWindow()
        {
            log = LogManager.GetLogger("NewPatientWindow");

            InitializeComponent();
            
=======
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
        public AddPatientView()
        {
            log = LogManager.GetLogger("Add Patient");

            InitializeComponent();

<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
            string portStr = string.Empty;
            var str = ConfigurationManager.AppSettings["barcodeScannerPort"];
            if (str != null)
            {
                try
                {
                    serial = new SerialPort(str, 9600, Parity.None, 8, StopBits.One);
                    serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
                    serial.Open();
                }
                catch (Exception e)
                {
                    log.Error(string.Format("Can't open serial port. Reason: {0}", e.Message));
                }
            }
            else
            {
<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
                log.Error(string.Format("Can't extract barcode scanner port name from app settings!"));
            }
        }

=======
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
                log.Error("Can't extract barcode scanner port name from app settings!");
            }
        }
        
        public override void ClearInput()
        {
            iinTextBox.Text = null;
            lastNameTextBox.Text = null;
            firstNameTextBox.Text = null;
            middleNameTextBox.Text = null;
            birthdateDatePicker.SelectedDate = null;
            maleRadioButton.IsChecked = false;
            femaleRadioButton.IsChecked = false;
        }
        
<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var input = serial.ReadLine();

<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
            /// TODO: убрать из сканнера отправку символа \r
=======
            // TODO: убрать из сканнера отправку символа \r
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
            // TODO: убрать из сканнера отправку символа \r
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs

            if (input.EndsWith("\r"))
            {
                input = input.Remove(input.Length - 1);
            }

            if (input.Length == 12)
            {
                Dispatcher.Invoke(() => iinTextBox.Text = input);
            }
        }

<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            birthdateDatePicker.SetWatermarkText(DatePickerWatermark);
            iinTextBox.Focus();
        }

        private void iinTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{12}$");
            string iin = (sender as TextBox).Text;
=======
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
        private void iinTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{12}$");
            string iin = (sender as TextBox)?.Text;
<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs

            if (!string.IsNullOrEmpty(iin) && regex.Match(iin).Success)
            {
                string year = iin.Substring(0, 2);
                string month = iin.Substring(2, 2);
                string day = iin.Substring(4, 2);

                byte chr = byte.Parse(iin.Substring(6, 1));

<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
                Gender gender = (chr % 2 == 0) ? Gender.Female : Gender.Male;
=======
                PatientGender gender = (chr % 2 == 0) ? PatientGender.Female : PatientGender.Male;
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
                PatientGender gender = (chr % 2 == 0) ? PatientGender.Female : PatientGender.Male;
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
                year = (17 + (chr + 1) / 2).ToString() + year;

                birthdateDatePicker.SelectedDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));

<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
                if (gender == Gender.Male)
=======
                if (gender == PatientGender.Male)
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
                if (gender == PatientGender.Male)
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
                {
                    maleRadioButton.IsChecked = true;
                }
                else
                {
                    femaleRadioButton.IsChecked = true;
                }

                if (iin.Equals("921210350914"))
                {
                    firstNameTextBox.Text = "Алексей";
                    middleNameTextBox.Text = "Григорьевич";
                    lastNameTextBox.Text = "Попов";
<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
                    tpTextBox.Text = "2.0";
                    scdTextBox.Text = "3.0";
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
                }
            }
        }

<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            serial.Close();
        }

        private void startExamineBtn_Click(object sender, RoutedEventArgs e)
        {
            Patient p = new Patient();
            p.FirstName = firstNameTextBox.Text;
            p.MiddleName = middleNameTextBox.Text;
            p.LastName = lastNameTextBox.Text;
            p.IIN = iinTextBox.Text;

            // TODO: Нормальный вывод ошибок
            try
            {
                p.TP = double.Parse(tpTextBox.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте формат записи поля \"TP\" на правильность. Ошибка:\n\n" + ex.Message);
                return;
            }

            try
            {
                p.SCD = double.Parse(scdTextBox.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте формат записи поля \"SCD\" на правильность. Ошибка:\n\n" + ex.Message);
                return;
            }
=======
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            iinTextBox.Focus();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            serial.Close();
            BackButtonFunc?.Invoke();
        }

        private void addPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            Patient p = new Patient
            {
                FirstName = firstNameTextBox.Text,
                MiddleName = middleNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                Iin = iinTextBox.Text
            };
<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs

            if (!maleRadioButton.IsChecked.Value && !femaleRadioButton.IsChecked.Value)
            {
                MessageBox.Show("Вы должны выбрать пол пациента!");
                return;
            }

<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
            p.Gender = maleRadioButton.IsChecked.Value ? Gender.Male : Gender.Female;
=======
            p.Gender = maleRadioButton.IsChecked.Value ? PatientGender.Male : PatientGender.Female;
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
            p.Gender = maleRadioButton.IsChecked.Value ? PatientGender.Male : PatientGender.Female;
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs

            if (!birthdateDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Вы должны выбрать дату рождения пациента!");
                return;
            }

            p.Birthdate = birthdateDatePicker.SelectedDate.Value;

<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
            p = PatientsRepo.Instance.Add(p);
=======
            p = PatientsRepository.Instance.Add(p);
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
            p = PatientsRepository.Instance.Add(p);
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
            if (p == null)
            {
                MessageBox.Show("Не удалось сохранить пациента. Проверьте заполненные поля на наличие ошибок.");
                return;
            }

<<<<<<< HEAD:Client/Views/AddPatientView.xaml.cs
<<<<<<< HEAD:Client/NewPatientWindow.xaml.cs
            ExaminesWindow window = new ExaminesWindow(p);
            window.Owner = Owner;
            window.Show();
            Close();
=======
            BackButtonFunc?.Invoke();
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
=======
            BackButtonFunc?.Invoke();
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Client/Views/AddPatientView.xaml.cs
        }
    }
}
