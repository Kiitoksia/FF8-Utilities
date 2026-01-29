using CarawayCode.Entities;
using FF8Utilities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FF8Utilities
{
    public static class HelperMethods
    {
        /// <summary>
        /// Converts PoleModels into PoleCount entities for interacting with CarawayCode project
        /// </summary>
        public static PoleCount[] ConvertTo(List<PoleModel> poles)
        {
            return poles.Where(p => p.Count != null).Select(p => new PoleCount(p.Count.Value)).ToArray();
        }               

        public static Color ToWPFColor(this System.Drawing.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }

    public class ByteArrayToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is byte[] bytes) || bytes.Length == 0)
                return null;

            using (MemoryStream stream = new MemoryStream(bytes))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze(); // for cross-thread safety
                return image;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // not needed
        }
    }

    public class BoolConverter<T> : MarkupExtension, IValueConverter
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

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
