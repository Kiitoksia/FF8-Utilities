using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZellCardManip.Entities
{
    public static class Settings
    {
        public static int Base { get; set; } = 500;
        public static int Width { get; set; } = 400;
        public static int RecoveryWidth { get; set; } = 360;
        public static int CountingWidth { get; set; } = 100;
        public static int TurboSpeed { get; set; } = 12;
        public static int FrameDelay { get; set; } = 285;
        public static int AcceptFrameDelay { get; set; } = 3;
        public static int ForcedIncrement { get; set; } = 10;
        public static string[] Arguments { get; set; }

    }

    public static class InputArguments
    {
        public static QuistisPattern FirstState { get; set; } = QuistisPattern.Elastoid;
        public static long State { get; set; }
        public static int? Count { get; set; }
        public static SearchType SearchType { get; set; } = SearchType.First;
    }
}
