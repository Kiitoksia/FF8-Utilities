using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FF8Utilities.Common.Cards
{
    public class GameScenario
    { 
        public GameScenario()
        {

        }

        public GameScenario(string rngHex, int rngIndex, string frame1, string frame2, string frame3, string frame4, string frame5, 
            string frame6, string frame7, string frame8, string frame9, string frame10, string extraFrame)
        {
            RNGHex = rngHex;
            RNGIndex = rngIndex;
            Frame1 = frame1;
            Frame2 = frame2;
            Frame3 = frame3;
            Frame4 = frame4;
            Frame5 = frame5;
            Frame6 = frame6;
            Frame7 = frame7;
            Frame8 = frame8;
            Frame9 = frame9;
            Frame10 = frame10;
            ExtraFrame = extraFrame;
        }

        [Name("RNG Hexa")]
        public string RNGHex { get; set; }

        [Name("RNG Index")]
        public int RNGIndex { get; set; }

        [Name("Frame 1")]
        public string Frame1 { get; set; }

        [Name("Frame 2")]
        public string Frame2 { get; set; }

        [Name("Frame 3")]
        public string Frame3 { get; set; }

        [Name("Frame 4")]
        public string Frame4 { get; set; }

        [Name("Frame 5")]
        public string Frame5 { get; set; }

        [Name("Frame 6")]
        public string Frame6 { get; set; }

        [Name("Frame 7")]
        public string Frame7 { get; set; }

        [Name("Frame 8")]
        public string Frame8 { get; set; }

        [Name("Frame 9")]
        public string Frame9 { get; set; }

        [Name("Frame 10")]
        public string Frame10 { get; set; }

        [Name("Extra Frame 1")]
        public string ExtraFrame { get; set; }

        internal bool IsValid => !string.IsNullOrEmpty(string.Concat(Frame1, Frame2, Frame3, Frame4, Frame5, Frame6, Frame7, Frame8, Frame9, Frame10, ExtraFrame));


        public static byte[] GetCardImage(string card)
        {
            return CardImage.GetCardImage(card);
        }

        internal static byte[] GetDeckCardImage(string card)
        {
            switch (card.ToLower())
            {
                case "behemoth": 
                case "behemot":
                    return GetCardImage("beast");
                case "irongiant": return GetCardImage("giant");
                case "gim47n": return GetCardImage("robot");
                case "glacialeye": return GetCardImage("glacial");
                case "buel": return GetCardImage("buel");
                case "malboro": return GetCardImage("malboro");
                case "creeps": return GetCardImage("creeps");
                case "elnoyle": return GetCardImage("elnoyle");
                case "grendel": return GetCardImage("grendel");
                case "tonberryking": return GetCardImage("king");
                case "chimera": return GetCardImage("chimera");
                case "grat": return GetCardImage("grat");
                case "jelleye": return GetCardImage("jelleye");
                case "anacondaur": return GetCardImage("snake");
                case "belhelmel": return GetCardImage("mask");
                case "elastoid": return GetCardImage("elastoid");
                case "rubydragon": return GetCardImage("ruby");
                case "wedge+biggs": return GetCardImage("biggs");
                case "grandmantis": return GetCardImage("mantis");
                case "mesmerize": return GetCardImage("unicorn");
                case "thrustaevis": return GetCardImage("bird");
                case "xx": return null;
                default: throw new NotImplementedException();
            }
        }

        private string GetPattern(int frame)
        {
            switch (frame)
            {
                case 1: return Frame1;
                case 2: return Frame2;
                case 3: return Frame3;
                case 4: return Frame4;
                case 5: return Frame5;
                case 6: return Frame6;
                case 7: return Frame7;
                case 8: return Frame8;
                case 9: return Frame9;
                case 10: return Frame10;
                case 11: return ExtraFrame;
                default: throw new NotImplementedException();
            }
        }

        internal List<LateQuistisPosition> CreatePositions(int frame, bool loadImages)
        {
            List<LateQuistisPosition> positions = new List<LateQuistisPosition>();

            string frameString = GetPattern(frame);
            if (string.IsNullOrWhiteSpace(frameString)) return null;
            MatchCollection matches = Regex.Matches(frameString, "([^ ]+)");

            int playerTurns = 1;
            int opponentTurns = 1;
            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                string pattern = match.Groups[1].Value;

                bool isPlayerTurn = !pattern.StartsWith("(");

                Match patternMatch = Regex.Match(pattern, @"\(?(.+)(\d+)\)?");
                if (!patternMatch.Success) return null;
                string card = patternMatch.Groups[1].Value;
                int boardPosition = int.Parse(patternMatch.Groups[2].Value);

                positions.Add(new LateQuistisPosition(boardPosition, isPlayerTurn, isPlayerTurn ? playerTurns : opponentTurns, loadImages ? GetCardImage(card) : null));

                if (isPlayerTurn) playerTurns++;
                else opponentTurns++;
            }


            return positions;
        }
    }
}
