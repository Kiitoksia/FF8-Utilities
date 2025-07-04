using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManipulation.Models
{
    public class Options
    {
        public string Language { get; set; }
        public uint Base { get; set; }
        public uint Width { get; set; }
        public uint RecoveryWidth { get; set; }
        public uint CountingWidth { get; set; }
        public uint CountingFrameWidth { get; set; }
        public string EarlyQuistis { get; set; }
        public int AutofireSpeed { get; set; }
        public float DelayFrame { get; set; }
        public string RanksOrder { get; set; }
        public List<int> StrongHighlightCards { get; set; }
        public List<int> HighlightCards { get; set; }
        public TOrder Order { get; set; }
        public int ConsoleFps { get; set; }
        public float GameFps { get; set; }
        public string Player { get; set; }
        public List<string> Fuzzy { get; set; }
        public uint ForcedIncr { get; set; }
        public float AcceptDelayFrame { get; set; }
        public string Prompt { get; set; }
        public bool Interactive { get; set; }

        public static Options Default() => new Options
        {
            Language = "en",
            Base = 550,
            Width = 400,
            RecoveryWidth = 600,
            CountingWidth = 600,
            CountingFrameWidth = 40,
            EarlyQuistis = "pingval",
            AutofireSpeed = 12,
            DelayFrame = 285,
            RanksOrder = "ulrd",
            StrongHighlightCards = new List<int> { 103, 105 },
            HighlightCards = new List<int> { 21, 48, 53 },
            Order = TOrder.Reverse,
            ConsoleFps = 60,
            GameFps = 60,
            Player = "zellmama",
            Fuzzy = new List<string> { ".", "r", "o", "ro" },
            ForcedIncr = 10,
            AcceptDelayFrame = 3,
            Prompt = "> ",
            Interactive = false
        };
    }

    public enum TOrder
    {
        Reverse,
        Descending,
        Ascending,
    }
}
