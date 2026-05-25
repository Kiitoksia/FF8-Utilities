using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace FF8Utilities.Web
{
    public static class WebHelper
    {
        public static string ToCss(this Color c) => $"rgba({c.R},{c.G},{c.B},{c.A / 255f:F3})";

        private static readonly Dictionary<byte[], string> CachedDataImageSources = new Dictionary<byte[], string>(ReferenceEqualityComparer.Instance);

        public static string GetDataImageSource(byte[] imageData)
        {
            if (imageData == null) return null;
            if (CachedDataImageSources.TryGetValue(imageData, out var dataImageSource)) return dataImageSource;
            dataImageSource = $"data:image/png;base64,{Convert.ToBase64String(imageData)}";
            CachedDataImageSources[imageData] = dataImageSource;
            return dataImageSource;
        }

        public static event EventHandler<KeyboardEventArgs> KeyPressed;

        [JSInvokable]
        public static Task JsKeyDown(KeyboardEventArgs args)
        {
            KeyPressed?.Invoke(null, args);
            return Task.CompletedTask;
        }

        
    }
}
