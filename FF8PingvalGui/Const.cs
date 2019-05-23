using System;
using System.ComponentModel;

namespace FF8Utilities
{
    [Flags]
    public enum QuistisPattern
    {
        Elastoid = 1,
        Malboro = 2,
        [Description("Biggs & Wedge")]
        BiggsWedge = 3
    }

    [Flags]
    public enum UltimeciaDirection
    {
        Up = 8,
        Down = 2,
        Left = 4,
        Right = 6
    }

    public static class Const
    {
        /// <summary>
        /// The delay pole series, in milliseconds
        /// </summary>
        public const int SeriesInterval = 3000;

        public const int LastMapFramerate = 30;

    }

    public enum WorldMapFormation
    {
        [Description("Big Bug")]
        BiteBug,
        [Description("2x Bite Bug")]
        BiteBugx2,
        [Description("3x Bite Bug")]
        BiteBugx3,
        [Description("Glacial Eye")]
        GlacialEye,
        [Description("Caterchipillar")]
        Caterchipillar,
        [Description("Caterchipillar & 2x Bite Big")]
        CaterchipillarAnd2xBiteBug,
        [Description("T-Rexaur")]
        TRex
    }

    public enum TwoPersonFanfareCamera
    {
        [Description("1 Character")]
        SingleCharacter,
        [Description("2 Characters")]
        TwoCharacters
    }

    public enum ThreePersonFanfareCamera
    {
        [Description("1 Character")]
        SingleCharacter,
        [Description("3 characters")]
        ThreeCharacters,
        [Description("One to One")]
        OneToOne
    }

    public enum ElvoretFanfareCamera
    {
        [Description("One to One")]
        OneToOne,
        [Description("1-2 Characters Dead")]
        CharacterDead,
        Other
    }

    public enum CardPosition
    {
        [Description("Top Left")]
        TopLeft,
        [Description("Top Centre")]
        TopCentre,
        [Description("Top Right")]
        TopRight,
        [Description("Centre Left")]
        CentreLeft,        
        Centre,
        [Description("Centre Right")]
        CentreRight,
        [Description("Bottom Left")]
        BottomLeft,
        [Description("Bottom Centre")]
        BottomCentre,
        [Description("Bottom Right")]
        BottomRight
    }

    public enum Card
    {
        Gayla,
        Caterchipillar,
        Funguar,
        [Description("Fastitocalon-F")]
        Fastitocalon,
        Geezard
    }
}
