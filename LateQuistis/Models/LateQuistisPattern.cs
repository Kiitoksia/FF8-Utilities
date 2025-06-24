using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateQuistisManipulation.Models
{
    public class LateQuistisPattern
    {
        internal LateQuistisPattern(string rngHex, int rngIndex, GameScenario scenario, OpponentDeck deck, PlayPattern pattern, RNGResult result)
        {

        }

        public string RNGHex { get; }
        public int RNGIndex { get; }

        public GameScenario Scenario { get; }
        public OpponentDeck Deck { get; }

        public PlayPattern Pattern { get; }

        public RNGResult Result { get; }

    }
}
