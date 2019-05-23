using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FF8Utilities.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class KiiVisibilityConverter : IValueConverter
    {
        public static KiiVisibilityConverter FalseToCollapsed { get; private set; }
        public static KiiVisibilityConverter FalseToHidden { get; private set; }
        public static KiiVisibilityConverter TrueToCollapsed { get; private set; }
        public static KiiVisibilityConverter TrueToHidden { get; private set; }
        public Visibility NonVisibleState { get; private set; }
        private bool Invert { get; set; }

        static KiiVisibilityConverter()
        {
            FalseToCollapsed = new KiiVisibilityConverter();
            FalseToHidden = new KiiVisibilityConverter { NonVisibleState = Visibility.Hidden };
            TrueToCollapsed = new KiiVisibilityConverter { Invert = true };
            TrueToHidden = new KiiVisibilityConverter { Invert = true, NonVisibleState = Visibility.Hidden };
        }

        private KiiVisibilityConverter()
        {
            NonVisibleState = Visibility.Collapsed;
        }

        private bool CalcValue(bool value)
        {
            return Invert ? !value : value;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Visible;
            return (CalcValue((bool)value) ? Visibility.Visible : NonVisibleState);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
