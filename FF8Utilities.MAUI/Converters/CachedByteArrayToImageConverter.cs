using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace FF8Utilities.MAUI.Converters
{
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
    public class CachedByteArrayToImageSourceConverter : IValueConverter
    {
        private static readonly ConditionalWeakTable<byte[], ImageSource> _cache = new();
        private static readonly object _cacheLock = new();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not byte[] byteArray || byteArray.Length == 0) return null;

            if (_cache.TryGetValue(byteArray, out var cached))
                return cached;

            var imageSource = ImageSource.FromStream(() => new MemoryStream(byteArray, writable: false));
            lock (_cacheLock)
            {
                if (!_cache.TryGetValue(byteArray, out cached))
                {
                    _cache.Add(byteArray, imageSource);
                    return imageSource;
                }
            }

            return cached;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }            
    }
}
