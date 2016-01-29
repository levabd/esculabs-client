namespace Client.Helpers.Converters
{
    using System;
    using System.Globalization;
    using Cimbalino.Toolkit.Converters;
    using System.Linq;

    public class IqrMedConverter: MultiValueConverterBase
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var omg = values.ToArray();

            if (omg[0] == null || omg[1] == null)
            {
                return null;
            }

            var iqr = (double)omg[0];
            var med = (double)omg[1];

            var x = System.Convert.ToInt32(Math.Round(iqr / med * 100));
            var valid = x > 30;

            return $"{x}% " + (valid ? "(корректно)" : "(некорректно)");
        }

        public override object[] ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
