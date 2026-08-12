using System;
using System.ComponentModel;
using System.IO;

namespace FF8Utilities
{
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

        public const string CSREnglishFile = "CSR-English";
        public const string CSRFrenchFile = "CSR-French";

        public static string PackagesFolder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FF8-Utilities");
        public const string SettingsFile = "Settings.xml";
    }

    public enum WorldMapFormation
    {
        [Description("Bite Bug")]
        BiteBug,
        [Description("2x Bite Bug")]
        BiteBugx2,
        [Description("3x Bite Bug")]
        BiteBugx3,
        [Description("Glacial Eye")]
        GlacialEye,
        [Description("Caterchipillar")]
        Caterchipillar,
        [Description("Caterchipillar & 2x Bite Bug")]
        CaterchipillarAnd2xBiteBug,
        [Description("T-Rexaur")]
        TRex
    }

    public enum CardPosition
    {
        [Description("Top Left")]
        TopLeft = 1,
        [Description("Top Centre")]
        TopCentre = 2,
        [Description("Top Right")]
        TopRight = 3,
        [Description("Centre Left")]
        CentreLeft = 4,        
        Centre = 5,
        [Description("Centre Right")]
        CentreRight = 6,
        [Description("Bottom Left")]
        BottomLeft = 7,
        [Description("Bottom Centre")]
        BottomCentre = 8,
        [Description("Bottom Right")]
        BottomRight = 9
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

    public enum QuistisPatternsOrderBy
    {
        Alphabetical,
        Frame
    }
    
    public enum UpdateBranch
    {
        Stable,
        Beta
    }
}
