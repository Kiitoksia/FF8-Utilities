using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FF8Utilities.MAUI.Converters
{
    public class BoolConverter<T> : IValueConverter
    {
        public T True { get; set; }
        public T False { get; set; }

        public BoolConverter()
        {

        }

        public BoolConverter(T trueVal, T falseVal)
        {
            True = trueVal;
            False = falseVal;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? True : False;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((T)value).Equals(True);
        }
    }
}
