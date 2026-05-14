using System.Drawing;

namespace FF8Utilities.Web
{
    public static class WebHelper
    {
        public static string ToCss(this Color c) => $"rgba({c.R},{c.G},{c.B},{c.A / 255f:F3})";

    }
}
