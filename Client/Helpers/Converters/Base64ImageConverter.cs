using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Cimbalino.Toolkit.Converters;
using Cimbalino.Toolkit.Extensions;

namespace Client.Helpers.Converters
{
    class Base64ImageConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var base64 = value as string;

            if (base64 == null)
            {
                return null;
            }

            var bytes = System.Convert.FromBase64String(base64);

            var image = new BitmapImage();
            using (var stream = new InMemoryRandomAccessStream())
            {
                stream.WriteAsync(bytes.AsBuffer()).Completed = (i, j) => {
                    stream.Seek(0);
                    image.SetSource(stream);
                };
            }

            return image;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}