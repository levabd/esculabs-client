using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Converters;

namespace Client.Helpers.Converters
{
    class FibrosisStageConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var med = (int) value;

            if (med == 0)
            {
                return "Нет данных";
            }

            if (med > 12.5f)
            {
                return "F4";
            }

            if (med >= 9.6f)
            {
                return "F3";
            }

            if (med >= 7.3f)
            {
                return "F2";
            }

            if (med >= 5.9f)
            {
                return "F1";
            }

            if (med >= 1.5f)
            {
                return "F0";
            }

            return "Отсутствует";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}