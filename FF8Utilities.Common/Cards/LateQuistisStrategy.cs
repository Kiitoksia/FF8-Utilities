using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FF8Utilities.Common.Cards
{
    public class LateQuistisStrategy
    {
        internal LateQuistisStrategy(int rngIndex, int frame, List<CardPosition> positions, string opponentDeck, string resultHex, bool loadImages)
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
        public List<CardPosition> Positions { get; }

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
}
