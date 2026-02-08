using System;
using System.Collections.Generic;
using System.Text;
using UltimeciaManip;

namespace FF8Utilities.MAUI
{
    public static class FontAwesome
    {
        // Add more from https://fontawesome.com/search?ip=classic&s=solid&ic=free-collection

        public const string ArrowDown = "\uf063";

        public const string ArrowLeft = "\uf060";

        public const string ArrowRight = "\uf061";

        public const string ArrowUp = "\uf062";

        public const string Asterik = "\u002a";

        public const string CircleXMark = "\uf057";

        public const string ClipboardList = "\uf46d";

        public const string CogWheel = "\uf013";

        public const string FishFins = "\ue4f2";

        public const string List = "\uf03a";

        public const string NavLeft = "\uf104";

        public const string PeopleLine = "\ue534";

        public const string PersonWalkingRight = "\ue553";

        public const string QuestionMark = "\u003F";

        public const string Train = "\uf239";

        public static string GetGlyph(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return ArrowUp;
                case Direction.Down: return ArrowDown;
                case Direction.Left: return ArrowLeft;
                case Direction.Right: return ArrowRight;
                case Direction.Unknown: return QuestionMark;
                default: throw new NotImplementedException();
            }
        }
    }
}
