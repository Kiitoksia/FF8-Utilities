using FF8Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FF8Utilities.MAUI.Converters
{
    public class EnumToListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is Type type)
            {
                var enumValues = Enum.GetValues(type);
                return enumValues.Cast<object>().Select(t => new SelectableComboBoxItem { Value = t, Description = ((Enum)t).GetDescription() }).ToList();
            }

            throw new InvalidCastException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
