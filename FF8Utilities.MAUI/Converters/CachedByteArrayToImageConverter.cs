using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace FF8Utilities.MAUI.Converters
{
    public class CachedByteArrayToImageSourceConverter : IValueConverter
    {
        private static readonly SHA1 _sha = SHA1.Create();
        private static readonly Dictionary<string, ImageSource> _cache = new();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not byte[] byteArray || byteArray.Length == 0) return null;

            string hash = GetHash(byteArray);


            if (_cache.TryGetValue(hash, out var cached)) return cached;

            var imageSource = ImageSource.FromStream(() => new MemoryStream(byteArray));
            _cache[hash] = imageSource;

            return imageSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();

        private static string GetHash(byte[] data)
        {
            return string.Concat(_sha.ComputeHash(data).Select(t => t.ToString("X2")));            
        }
    }
}
