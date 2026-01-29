using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LateQuistisManipulation.Models
{
    public class LateQuistisStrategy
    {
        internal LateQuistisStrategy(int rngIndex, int frame, List<LateQuistisPosition> positions, string opponentDeck, string resultHex, bool loadImages)
        {
            RNGIndex = rngIndex;
            Frame = frame;
            Positions = positions?.OrderBy(t => t.Position).ToList();
            OpponentDeck = opponentDeck;
            ResultHex = resultHex;

            MatchCollection matches = Regex.Matches(opponentDeck ?? string.Empty, @"([^ \/]+)");
            OpponentCards = new List<byte[]>();

            if (loadImages)
            {
                int index = 0;
                foreach (Match match in matches)
                {
                    if (index > 1) break;
                    OpponentCards.Add(GameScenario.GetDeckCardImage(match.Groups[1].Value));
                    index++;
                }
            }
        }

        public int Frame { get; }

        public int RNGIndex { get; }
        public List<LateQuistisPosition> Positions { get; }

        public string OpponentDeck { get; }

        /// <summary>
        /// Opponent Deck has some outliers like "Wedge+Biggs", this changes it into an expected order
        /// </summary>
        public string OpponentDeckOrderer
        {
            get
            {
                if (string.IsNullOrEmpty(OpponentDeck)) return string.Empty;
                string output = OpponentDeck;
                output = Regex.Replace(output, @"Wedge\+Biggs", "Biggs/Wedge");
                return output;
            }
        }

        public List<byte[]> OpponentCards { get; }

        public string ResultHex { get; set; }
    }

    public class LateQuistisPosition
    {
        public LateQuistisPosition(int position, bool isPlayerTurn, int turn, byte[] card, string customTopInfo = null, string customRightInfo = null, string customBotInfo = null, string customLeftInfo = null)
        {
            Position = position;
            IsPlayerTurn = isPlayerTurn;
            Turn = turn;
            Card = card;
            CustomTopInfo = customTopInfo;
            CustomRightInfo = customRightInfo;
            CustomBotInfo = customBotInfo;
            CustomLeftInfo = customLeftInfo;
        }

        public int Position { get; }

        public bool IsPlayerTurn { get; }

        public int Turn { get; }

        public byte[] Card { get; }


        public string CustomTopInfo { get; }
        public string CustomRightInfo { get; }
        public string CustomBotInfo { get; }
        public string CustomLeftInfo { get; }

        public bool ShowTurnNumber => Turn != 0;
    }
}
