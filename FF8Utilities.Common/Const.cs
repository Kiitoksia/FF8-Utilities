using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace FF8Utilities.Common
{
    public static class Const
    {
        /// <summary>
        /// The delay pole series, in milliseconds
        /// </summary>
        public const int SeriesInterval = 3000;

        public const int LastMapFramerate = 30;

        public const string CSREnglishFile = "CSR-English";
        public const string CSRFrenchFile = "CSR-French";

        public static string PackagesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FF8-Utilities");
        public const string SettingsFile = "Settings.xml";
    }

    public enum Platform
    {
        PS2,
        PC
    }

    public enum QuistisPattern
    {
        [Description("[Frame 1] - Elastoid (Jellyeye)")]
        [CardResult(1)]
        Elastoid_JellyEye = 1,

        [Description("[Frame 2] - Malboro (Anacondaur)")]
        [CardResult(2)]
        Malboro_Snek = 2,

        [Description("[Frame 3] - Biggs & Wedge (Jellyeye)")]
        [CardResult(3)]
        BiggsWedge_JellyEye = 3,

        [Description("[Frame 4] - Elastoid (Grendel)")]
        [CardResult(0x65c6be07)]
        Elastoid_Grendel = 4,

        [Description("[Frame 5] - Malboro (Grand Mantis) *Unwinnable*")]
        [CardResult(5)]
        Malboro_GrandMantis = 5,

        [Description("[Frame 6] - Grand Mantis (Elastoid) *Unwinnable*")]
        [CardResult(6)]
        GrandMantis_Elastoid = 6,

        [Description("[Frame 7] - Glacial Eye (Grand Mantis)")]
        [CardResult(0x832b19d2)]
        GlacialEye_GrandMantis = 7,

        [Description("[Frame 8] - Anacondaur (GIM47N) *Unwinnable*")]
        [CardResult(8)]
        Snek_GIM = 8,

        [Description("[Frame 9] - Jellyeye (Biggs & Wedge)")]
        [CardResult(0xad8f1b2f)]
        JellyEye_BiggsWedge = 9,

        [Description("[Frame 10] - Chimera (Thrustaevis)")]
        [CardResult(0xf99a05ef)]
        Chimera_Thrustaevis = 10,

        [Description("Late Quistis")]
        [CardResult(0)]
        LateQuistis = -1
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

    public interface IEncounter
    {
        int Base { get; }
        int RngAddition { get; }
        string Description { get; }
    }

    public enum IfritEncounterType
    {
        [Description("2x Red Bats")]
        RedBat,
        Buel
    }
}
