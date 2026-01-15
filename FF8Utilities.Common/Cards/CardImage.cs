using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FF8Utilities.Common.Cards
{
    public static class CardImage
    {
        public static byte[] GetCardImage(string card)
        {
            var assembly = typeof(CardImage).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream($"FF8Utilities.Common.Resources.{card}.png"))
            {
                if (stream == null) return null;
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    ms.Position = 0;
                    return ms.ToArray();
                }
            }
        }
    }
}
