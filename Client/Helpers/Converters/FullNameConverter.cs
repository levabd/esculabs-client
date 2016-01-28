﻿namespace Client.Helpers.Converters
{
    using System;
    using System.Globalization;
    using Cimbalino.Toolkit.Converters;
    using System.Linq;

    public class FullNameConverter: MultiValueConverterBase
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

            return $"{names[0]} {s} {o}";
        }

        public override object[] ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
