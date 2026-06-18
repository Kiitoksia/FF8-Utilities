using FF8Utilities.Common.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
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

        public static List<FishPatternModel> AllFishPatterns { get; private set; }

        public static async Task LoadFishPatterns(HttpClient client, string baseUrl)
        {
            string url = $"{baseUrl.TrimEnd('/')}/fins.json";
            string json = await client.GetStringAsync(url);
            dynamic jObj = JsonConvert.DeserializeObject(json);

            AllFishPatterns = new List<FishPatternModel>();
            foreach (var pattern in jObj)
            {
                AllFishPatterns.Add(new FishPatternModel(pattern));
            }
        }
        
    }
}
