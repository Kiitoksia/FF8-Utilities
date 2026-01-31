using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace FF8Utilities.Converters
{
    public class EqualsParameterConverer : IMultiValueConverter
    {

        private object _currentItem;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] != null && values[1] != null)
            {
                _currentItem = values[0]; // Store the current item for ConvertBack
                return values[0].Equals(values[1]);
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value is bool isChecked && isChecked && _currentItem != null)
            {
                // When checked, set the selected value (second binding) to the current item
                return new object[] { Binding.DoNothing, _currentItem };
            }

            // When unchecked, don't update anything
            return new object[] { Binding.DoNothing, Binding.DoNothing };
        }
    }
}
