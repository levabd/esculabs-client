﻿using System;

namespace Client.Helpers.Converters
{
    using System.Windows.Data;
    using System.Globalization;
    using EsculabsCommon.Models;

    [ValueConversion(typeof(PatientGender), typeof(string))]
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (PatientGender)value == PatientGender.Male ? "Мужской" : "Женский";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value == "Мужской" ? PatientGender.Male : PatientGender.Female;
        }
    }
}
