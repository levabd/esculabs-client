namespace Client.Helpers.Converters
{
    using System;
    using System.Globalization;
    using Cimbalino.Toolkit.Converters;
    using System.Linq;

    public class BloodGroupConverter: MultiValueConverterBase
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var names = values.ToArray();

            if (names?[0] == null)
            {
                return null;
            }

            var s = (int)names[0];
            var o = (bool?)names[1];

            string group;

            switch (s)
            {
                case (1):
                    group = "o (I)";
                    break;
                case (2):
                    group = "A (II)";
                    break;
                case (3):
                    group = "B (III)";
                    break;
                case (4):
                    group = "AB (IV)";
                    break;
                default:
                    return "Нет данных";
            }

            string rh = "";
            if (o.HasValue)
            {
                var t = o.Value ? "+" : "-";
                rh = $" (Rh{t})";
            }

            return $"{group}{rh}";
        }

        public override object[] ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
