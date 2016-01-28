namespace Client.Helpers.Converters
{
    using System;
    using System.Globalization;
    using Cimbalino.Toolkit.Converters;
    using System.Linq;

    public class ShortenedNameConverter: MultiValueConverterBase
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var names = values.ToArray();

            if (names == null)
            {
                return null;
            }

            var s = names[1] as string;
            var o = names[2] as string;

            if (s != null && o != null)
            {
                return $"{names[0]} {s.Substring(0, 1)}. {o.Substring(0, 1)}.";
            }

            return null;
        }

        public override object[] ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
