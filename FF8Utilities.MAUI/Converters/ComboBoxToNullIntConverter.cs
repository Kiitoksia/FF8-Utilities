using FF8Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FF8Utilities.MAUI.Converters
{
    public class ComboBoxToNullIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ComboBoxItem comboBoxItem)
            {
                return comboBoxItem.Value as int?;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ComboBoxItem comboBoxItem)
            {
                return comboBoxItem.Value as int?;
            }
            return null;
        }
    }
}
