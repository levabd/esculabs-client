using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Helpers
{
    using Models;
    using System.Windows.Data;
    using System.Globalization;

    [ValueConversion(typeof(PatientGender), typeof(String))]
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
