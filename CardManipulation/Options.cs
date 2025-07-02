using System.IO;
using Newtonsoft.Json;

namespace ff8_card_manip
{
    public class Options
    {
        public uint Base { get; set; } = 550;
        public uint Width { get; set; } = 400;
        public uint RecoveryWidth { get; set; } = 360;
        public uint CountingWidth { get; set; } = 100;
        public uint CountingFrameWidth { get; set; } = 40;
        public string EarlyQuistis { get; set; } = "pingval";
        public int AutofireSpeed { get; set; } = 12;
        public float DelayFrame { get; set; } = 285;
        public string RanksOrder { get; set; } = "ulrd";
        public int[] StrongHighlightCards { get; set; } = new[] { 103, 105 };
        public int[] HighlightCards { get; set; } = new[] { 21, 48, 53 };
        public TOrder Order { get; set; } = TOrder.Reverse;
        public int ConsoleFps { get; set; } = 60;
        public string Player { get; set; } = "zellmama";
        public string[] Fuzzy { get; set; } = new[] { ".", "r", "o", "ro" };
        public uint ForcedIncr { get; set; } = 10;
        public float AcceptDelayFrame { get; set; } = 3;
        public string Prompt { get; set; } = "> ";
        public bool Interactive { get; set; } = false;
        public float GameFps { get; set; } = 60;

        public enum TOrder
        {
            Reverse,
            Descending,
            Ascending,
        }

        public static Options ParseFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                return new Options();
            }

            var json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<Options>(json);
        }
    }
}
