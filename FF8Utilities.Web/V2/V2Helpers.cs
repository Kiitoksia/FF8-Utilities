using System.Drawing;
using UltimeciaManip;

namespace FF8Utilities.Web.V2
{
    public static class V2Helpers
    {
        /// <summary>
        /// Maps the models' instant mash colours (DarkRed / DarkOrange / Transparent) onto v2 CSS classes
        /// </summary>
        public static string MashClass(Color colour)
        {
            int argb = colour.ToArgb();
            if (argb == Color.DarkRed.ToArgb()) return "hot";
            if (argb == Color.DarkOrange.ToArgb()) return "warm";
            return string.Empty;
        }

        public static string Glyph(Direction direction) => direction switch
        {
            Direction.Up => "↑",
            Direction.Down => "↓",
            Direction.Left => "←",
            Direction.Right => "→",
            _ => "?"
        };
    }
}
