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
        public LateQuistisStrategy(int rngIndex, List<LateQuistisPosition> positions)
        {
            RNGIndex = rngIndex;
            Positions = positions;
        }

        public int RNGIndex { get; }
        public List<LateQuistisPosition> Positions { get; }
    }

    public class LateQuistisPosition
    {
        internal LateQuistisPosition(int position, bool isPlayerTurn, int turn, Bitmap card)
        {
            Position = position;
            IsPlayerTurn = isPlayerTurn;
            Turn = turn;
            Card = card;
        }

        public int Position { get; }

        public bool IsPlayerTurn { get; }

        public int Turn { get; }

        public Bitmap Card { get; }
    }
}
