namespace Client.Helpers.Converters
{
    using System;
    using System.Globalization;
    using Cimbalino.Toolkit.Converters;
    using Models;

    class SensorTypeConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sensor = value as string;

            switch (sensor)
            {
                case "S":
                    return "Small";
                case "M":
                    return "Medium";
                default:
                    return sensor;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}