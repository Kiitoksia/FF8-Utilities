using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FF8Utilities.MAUI.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Drawing.Color colour)
            {
                return Color.FromRgba(colour.R, colour.G, colour.B, colour.A);
            }

            throw new InvalidCastException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
