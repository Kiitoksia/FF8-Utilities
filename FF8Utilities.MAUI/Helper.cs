using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.MAUI
{
    public static class Helper
    {
        public static TBindable Bind<TBindable>(this TBindable bindable,
            BindableProperty targetProperty,
            string path = Binding.SelfPath,
            BindingMode mode = BindingMode.Default,
            IValueConverter converter = null,
            object converterParameter = null,
            string stringFormat = null,
            object source = null,
            object targetNullValue = null,
            object fallbackValue = null) where TBindable : BindableObject
        {
            bindable.SetBinding(
                targetProperty,
                new Binding(path, mode, converter, converterParameter, stringFormat, source)
                {
                    TargetNullValue = targetNullValue,
                    FallbackValue = fallbackValue
                });

            return bindable;
        }

        public static SKColor ToSKColor(this Color colour)
        {
            return new SKColor(
            (byte)(colour.Red * 255),
            (byte)(colour.Green * 255),
            (byte)(colour.Blue * 255),
            (byte)(colour.Alpha * 255));
        }
    }
}
