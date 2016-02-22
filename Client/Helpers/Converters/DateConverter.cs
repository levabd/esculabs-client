namespace Client.Helpers.Converters
{
    using System;
    using System.Globalization;
    using Cimbalino.Toolkit.Converters;
    using Models;

    class DateConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime))
            {
                return null;
            }

            var date = (DateTime)value;

            return new DateTime(date.Year, date.Month, date.Day);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;

            return new DateTime(date.Year, date.Month, date.Day);
        }
    }
}