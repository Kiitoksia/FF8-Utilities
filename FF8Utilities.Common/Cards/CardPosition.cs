using System;
using System.Collections.Generic;
using System.Text;

namespace FF8Utilities.Common.Cards
{
    public class CardPosition
    {
        public CardPosition(int position, bool isPlayerTurn, int turn, byte[] card, string customTopInfo = null, string customRightInfo = null, string customBotInfo = null, string customLeftInfo = null)
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
