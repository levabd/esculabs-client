using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Converters;
using FibrosisModule.Models;

namespace Client.Helpers.Converters
{
    class SensorTypeConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is SensorType))
            {
                return null;
            }

            var sensorType = (SensorType)value;

            return sensorType.ToString().ToUpper();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}