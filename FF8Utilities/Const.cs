using System;
using System.ComponentModel;
using System.IO;

namespace FF8Utilities
{
    [Flags]
    public enum QuistisPattern
    {
        [Description("[Frame 1] - Elastoid (Jellyeye)")]
        Elastoid_JellyEye = 1,
        [Description("[Frame 2] - Malboro (Anacondaur)")]
        Malboro_Snek = 2,
        [Description("[Frame 3] - Biggs & Wedge (Jellyeye)")]
        BiggsWedge_JellyEye = 3,
        [Description("[Frame 4] - Elastoid (Grendel)")]
        Elastoid_Grendel = 4,
        [Description("[Frame 5] - Malboro (Grand Mantis) *Unwinnable*")]
        Malboro_GrandMantis = 5,
        [Description("[Frame 6] - Grand Mantis (Elastoid) *Unwinnable*")]
        GrandMantis_Elastoid = 6,
        [Description("[Frame 7] - Glacial Eye (Grand Mantis)")]
        GlacialEye_GrandMantis = 7,
        [Description("[Frame 8] - Anacondaur (GIM47N) *Unwinnable*")]
        Snek_GIM = 8,
        [Description("[Frame 9] - Jellyeye (Biggs & Wedge)")]
        JellyEye_BiggsWedge = 9,
        [Description("[Frame 10] - Chimera (Thrustaevis)")]
        Chimera_Thrustaevis = 10
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

    public enum TwoPersonFanfareCamera
    {
        [Description("1 Character")]
        SingleCharacter = 2,
        [Description("2 Characters")]
        TwoCharacters = 3
    }

    public enum ThreePersonFanfareCamera
    {
        [Description("1 Character")]
        SingleCharacter,
        [Description("3 Characters")]
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

    public enum DownloadResult
    {
        Downloaded,
        Error
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

    public enum IfritEncounterType
    {
        [Description("2x Red Bats")]
        RedBat,
        Buel
    }    

    public enum CSRLanguage
    {
        English,
        French
    }

    public enum DefaultFishFinEncounters
    {
        [Description("Standard (3 Battles)")]
        ThreeBattles,
        [Description("Quetz Manip (1.5 battles)")]
        QuetzManip,
    }
}
