using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateQuistisManipulation.Models
{
    public class LateQuistisStrategy
    {
        public LateQuistisStrategy(int rngIndex, List<LateQuistisPosition> positions, string opponentDeck)
        {
            RNGIndex = rngIndex;
            Positions = positions;
            OpponentDeck = opponentDeck;
        }

        public int RNGIndex { get; }
        public List<LateQuistisPosition> Positions { get; }

        public string OpponentDeck { get; }
    }

    public class LateQuistisPosition
    {
        internal LateQuistisPosition(int position, bool isPlayerTurn, int turn, byte[] card)
        {
            Position = position;
            IsPlayerTurn = isPlayerTurn;
            Turn = turn;
            Card = card;
        }

        public int Position { get; }

        public bool IsPlayerTurn { get; }

        public int Turn { get; }

        public byte[] Card { get; }
    }
}
