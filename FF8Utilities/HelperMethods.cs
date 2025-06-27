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

        /// <summary>
        /// Gets the description if the enum has a description attribute, otherwise returns the enum.
        /// </summary>
        public static string GetDescription(this Enum enumeration)
        {
            return ((DescriptionAttribute)GetAttribute(enumeration, typeof(DescriptionAttribute)))?.Description ?? enumeration.ToString();
        }

        public static object GetAttribute(Enum enumeration, Type attributeType)
        {
            Type type = enumeration.GetType();

            MemberInfo[] memInfo = type.GetMember(enumeration.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(attributeType, false);

                if (attrs != null && attrs.Length > 0)

                    return attrs[0];

            }

            return null;
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
