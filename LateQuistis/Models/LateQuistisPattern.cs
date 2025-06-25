using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateQuistisManipulation.Models
{
    public class LateQuistisPattern
    {
        internal LateQuistisPattern(string rngHex, int rngIndex, GameScenario scenario, OpponentDeck deck, PlayPattern pattern, RNGResult result, bool loadImages)
        {
            RNGHex = rngHex;
            RNGIndex = rngIndex;
            Scenario = scenario;
            Deck = deck;
            Pattern = pattern;

            Strategies = new List<LateQuistisStrategy>();
            for (int i = 1; i < 11; i++)
            {
                Strategies.Add(new LateQuistisStrategy(RNGIndex, i, scenario?.CreatePositions(i, loadImages), deck?.GetFrame(i), result?.GetFrame(i), loadImages));
            }
        }

        public string RNGHex { get; }
        public int RNGIndex { get; }

        public GameScenario Scenario { get; }
        public OpponentDeck Deck { get; }

        public PlayPattern Pattern { get; }

        public RNGResult Result { get; }

        public List<LateQuistisStrategy> Strategies { get; }


    }
}
