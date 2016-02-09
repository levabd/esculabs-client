namespace Client.Helpers.Converters
{
    using System;
    using System.Globalization;
    using Cimbalino.Toolkit.Converters;
    using Models;

    class ExpertStatusConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ExpertStatus))
            {
                return null;
            }

            var status = (ExpertStatus)value;

            switch (status)
            {
                case ExpertStatus.Confirmed:
                    return "Подтверждён";

                case ExpertStatus.Pending:
                    return "Ожидается проверка";

                case ExpertStatus.Unconfirmed:
                    return "Не подтверждён";

                default:
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}