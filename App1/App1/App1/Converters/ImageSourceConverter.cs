using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace App1.Converters
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            var byteArray = (byte[])value;
            Stream stream = new MemoryStream(byteArray);
            return ImageSource.FromStream(() => { return stream; });
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}