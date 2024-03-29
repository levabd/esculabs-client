﻿using System;
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

        private SerialPort serial;
        private ILog log;

        public AddPatientView()
        {
            log = LogManager.GetLogger("Add Patient");

            InitializeComponent();

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
        
        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var input = serial.ReadLine();

            // TODO: убрать из сканнера отправку символа \r

            if (input.EndsWith("\r"))
            {
                input = input.Remove(input.Length - 1);
            }

            if (input.Length == 12)
            {
                Dispatcher.Invoke(() => iinTextBox.Text = input);
            }
        }

        private void iinTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{12}$");
            string iin = (sender as TextBox)?.Text;

            if (!string.IsNullOrEmpty(iin) && regex.Match(iin).Success)
            {
                string year = iin.Substring(0, 2);
                string month = iin.Substring(2, 2);
                string day = iin.Substring(4, 2);

                byte chr = byte.Parse(iin.Substring(6, 1));

                PatientGender gender = (chr % 2 == 0) ? PatientGender.Female : PatientGender.Male;
                year = (17 + (chr + 1) / 2).ToString() + year;

                birthdateDatePicker.SelectedDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));

                if (gender == PatientGender.Male)
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
                }
            }
        }

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

            if (!maleRadioButton.IsChecked.Value && !femaleRadioButton.IsChecked.Value)
            {
                MessageBox.Show("Вы должны выбрать пол пациента!");
                return;
            }

            p.Gender = maleRadioButton.IsChecked.Value ? PatientGender.Male : PatientGender.Female;

            if (!birthdateDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Вы должны выбрать дату рождения пациента!");
                return;
            }

            p.Birthdate = birthdateDatePicker.SelectedDate.Value;

            p = PatientsRepository.Instance.Add(p);
            if (p == null)
            {
                MessageBox.Show("Не удалось сохранить пациента. Проверьте заполненные поля на наличие ошибок.");
                return;
            }

            BackButtonFunc?.Invoke();
        }
    }
}
