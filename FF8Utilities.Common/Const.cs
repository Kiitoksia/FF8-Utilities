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

    public class EarlyQuistisPattern
    {
        internal EarlyQuistisPattern(string description, uint result)
        {
            Description = description;
            Result = result;
        }
        public string Description { get; }
        public uint Result { get; }        

        public static readonly EarlyQuistisPattern Frame1 = new EarlyQuistisPattern("[Frame 1] - Elastoid (Jellyeye)", 0x1de5_b942);
        public static readonly EarlyQuistisPattern Frame2 = new EarlyQuistisPattern("[Frame 2] - Malboro (Anacondaur)", 0x963c_b5e4);
        public static readonly EarlyQuistisPattern Frame3 = new EarlyQuistisPattern("[Frame 3] - Biggs & Wedge (Jellyeye)", 0x1f13_2481);
        public static readonly EarlyQuistisPattern Frame4 = new EarlyQuistisPattern("[Frame 4] - Elastoid (Grendel)", 0x65c6be07);
        public static readonly EarlyQuistisPattern Frame5 = new EarlyQuistisPattern("[Frame 5] - Malboro (Grand Mantis) *Unwinnable*", 5);
        public static readonly EarlyQuistisPattern Frame6 = new EarlyQuistisPattern("[Frame 6] - Grand Mantis (Elastoid) *Unwinnable*", 6);
        public static readonly EarlyQuistisPattern Frame7 = new EarlyQuistisPattern("[Frame 7] - Glacial Eye (Grand Mantis)", 0x832b19d2);
        public static readonly EarlyQuistisPattern Frame8 = new EarlyQuistisPattern("[Frame 8] - Anacondaur (GIM47N) *Unwinnable*", 8);
        public static readonly EarlyQuistisPattern Frame9 = new EarlyQuistisPattern("[Frame 9] - Jellyeye (Biggs & Wedge)", 0xad8f1b2f);
        public static readonly EarlyQuistisPattern Frame10 = new EarlyQuistisPattern("[Frame 10] - Chimera (Thrustaevis)", 0xf99a05ef);
        public static readonly EarlyQuistisPattern LateQuistis = new EarlyQuistisPattern("Late Quistis", 0);

        public static readonly EarlyQuistisPattern[] Options = new[]
        {
            Frame1,
            Frame2,
            Frame3,
            Frame4,
            Frame5,
            Frame6,
            Frame7,
            Frame8,
            Frame9,
            Frame10,
            LateQuistis
        };

        public static readonly EarlyQuistisPattern[] OptionsExcludeLate = new[]
        {
            Frame1,
            Frame2,
            Frame3,
            Frame4,
            Frame5,
            Frame6,
            Frame7,
            Frame8,
            Frame9,
            Frame10
        };

    }

    public class FanfareCamera
    {
        internal FanfareCamera(string description, int rngAddition)
        {
            Description = description;
            RngAddition = rngAddition;
        }
        public string Description { get; }
        public int RngAddition { get; }

        public static class TwoPerson
        {
            public static readonly FanfareCamera None = new FanfareCamera("None", 0);
            public static readonly FanfareCamera OneCharacter = new FanfareCamera("1 Character", 2);
            public static readonly FanfareCamera TwoCharacters = new FanfareCamera("2 Characters", 3);

            public static readonly FanfareCamera[] All = new[] { None, OneCharacter, TwoCharacters };
        }

        public static FanfareCamera[] TwoPersonCameras => FanfareCamera.TwoPerson.All;

        public static class ThreePerson
        {
            public static readonly FanfareCamera None = new FanfareCamera("None", 0);
            public static readonly FanfareCamera OneCharacter = new FanfareCamera("1 Character", 2);
            public static readonly FanfareCamera ThreeCharacters = new FanfareCamera("3 Characters", 4);
            public static readonly FanfareCamera OneToOne = new FanfareCamera("One to One", 3);

            public static readonly FanfareCamera[] All = new[] { None, OneCharacter, ThreeCharacters, OneToOne };

            public static readonly FanfareCamera[] AllExcludeNone = new[] { OneCharacter, ThreeCharacters, OneToOne };
        }

        public static FanfareCamera[] ThreePersonCameras => FanfareCamera.ThreePerson.All;

        public static class Elvoret
        {
            public static readonly FanfareCamera OneToOne = new FanfareCamera("One to One", 2);
            public static readonly FanfareCamera OneToTwoCharactersDead = new FanfareCamera("1-2 Characters Dead", 2);
            public static readonly FanfareCamera Other = new FanfareCamera("Other", 3);

            public static readonly FanfareCamera[] All = new[] { OneToOne, OneToTwoCharactersDead, Other };
        }

        public static FanfareCamera[] ElvoretCameras => FanfareCamera.Elvoret.All;
    }

    public enum Platform
    {
        PS2,
        PC
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

    public enum CSRLanguage
    {
        English,
        French
    }

    public enum DownloadResult
    {
        Downloaded,
        Error
    }

    public enum Card
    {
        [ImageResource("snake")]
        Anacondaur,
        [ImageResource("beast", "behemot")] // Looks incorrect but a CSV index has a bad spelling
        Behemoth,
        [ImageResource("mask")]
        Belhelmel,
        [ImageResource("biggs", "wedge+biggs")]
        BiggsWedge,
        [ImageResource("buel")]
        Buel,
        [ImageResource("c")]
        Caterchipallar,
        [ImageResource("chimera", "himera")] // Looks incorrect but a CSV index has a bad spelling
        Chimera,
        [ImageResource("creeps")]
        Creeps,
        [ImageResource("elastoid")]
        Elastoid,
        [ImageResource("elnoyle")]
        Elnoyle,
        [ImageResource("t")]
        Fasticalcon,
        [ImageResource("f")]
        Fungar,
        [ImageResource("m")] // ???
        Gayla,
        [ImageResource("g")]
        Geezard,
        [ImageResource("robot")]
        Gim47N,
        [ImageResource("glacial")]
        GlacialEye,
        [ImageResource("mantis")]
        GrandMantis,
        [ImageResource("grat")]
        Grat,
        [ImageResource("grendel")]
        Grendel,
        [ImageResource("i")]
        Ifrit,
        [ImageResource("giant", "irongiant")]
        IronGiant,
        [ImageResource("jelleye")]
        Jelleye,
        [ImageResource("malboro")]
        Malboro,
        [ImageResource("unicorn")]
        Mesmerize,
        [ImageResource("none")]
        None,
        [ImageResource("b")]
        RedBat,
        [ImageResource("ruby")]
        RubyDragon,
        [ImageResource("bird")]
        Thrustaevis,
        [ImageResource("king")]
        TonberryKing,
        [ImageResource("q")]
        Quistis,
        [ImageResource("z")]
        Zell
    }

    public class ImageResourceAttribute : Attribute
    {
        public ImageResourceAttribute(string filename, params string[] aliases)
        {
            Filename = filename;
            Aliases = aliases;
        }

        public string Filename { get; }
        public string[] Aliases { get; }
    }

    public static class CardExtensionMethods
    {
        /// <summary>
        /// Returns Card.None if not found
        /// Parses the string and its known aliases
        /// </summary>
        public static Card Parse(string cardString)
        {
            cardString = cardString?.Trim();
            if (string.IsNullOrWhiteSpace(cardString)) return Card.None;
            foreach (Card card in Enum.GetValues(typeof(Card)))
            {
                ImageResourceAttribute attribute = (ImageResourceAttribute)EnumMethods.GetAttribute(card, typeof(ImageResourceAttribute));
                if (cardString.Equals(attribute.Filename, StringComparison.CurrentCultureIgnoreCase)) return card;
                if (attribute.Aliases != null)
                {
                    foreach (string alias in attribute.Aliases)
                    {
                        if (cardString.Equals(alias, StringComparison.CurrentCultureIgnoreCase)) return card;
                    }
                }
            }
            return Card.None;
        }

        public static string GetImageResourceName(this Card card)
        {
            return ((ImageResourceAttribute)EnumMethods.GetAttribute(card, typeof(ImageResourceAttribute))).Filename;
        }
    }
}
