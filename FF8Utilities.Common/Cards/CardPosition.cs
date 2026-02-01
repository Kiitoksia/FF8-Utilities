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

        public static readonly CardPosition[] ZellPlayerFirstPositions = new[]
        {
            new CardPosition(1, false, 0, GameScenario.GetCardImage("empty")),
            new CardPosition(2, false, 0, GameScenario.GetCardImage("empty")),
            new CardPosition(3, true, 5, GameScenario.GetCardImage("q")),
            new CardPosition(4, true, 4, GameScenario.GetCardImage("m")),
            new CardPosition(5, false, 0, GameScenario.GetCardImage("empty")),
            new CardPosition(6, false, 1, GameScenario.GetCardImage("z")),
            new CardPosition(7, true, 3, GameScenario.GetCardImage("i")),
            new CardPosition(8, true, 2, GameScenario.GetCardImage("g")),
            new CardPosition(9, true, 1, GameScenario.GetCardImage("b"))
        };

        public static readonly CardPosition[] ZellMomFirstPositionsWeak = new[]
        {
            new CardPosition(1, false, 1, GameScenario.GetCardImage("z")),
            new CardPosition(2, false, 0, GameScenario.GetCardImage("empty"), "#", "= 1", "#", "#"),
            new CardPosition(3, true, 4, GameScenario.GetCardImage("q")),
            new CardPosition(4, true, 3, GameScenario.GetCardImage("m")),
            new CardPosition(5, false, 0, GameScenario.GetCardImage("empty")),
            new CardPosition(6, false, 0, GameScenario.GetCardImage("empty")),
            new CardPosition(7, false, 0, GameScenario.GetCardImage("empty")),
            new CardPosition(8, true, 2, GameScenario.GetCardImage("i")),
            new CardPosition(9, true, 1, GameScenario.GetCardImage("g"))
        };

        public static readonly CardPosition[] ZellMomFirstPositionsStrong = new[]
        {
            new CardPosition(1, false, 1, GameScenario.GetCardImage("z")),
            new CardPosition(2, false, 0, GameScenario.GetCardImage("empty"), "#", "2+", "#", "#"),
            new CardPosition(3, true, 3, GameScenario.GetCardImage("b")),
            new CardPosition(4, false, 0, GameScenario.GetCardImage("empty")),
            new CardPosition(5, true, 4, GameScenario.GetCardImage("q")),
            new CardPosition(6, false, 0, GameScenario.GetCardImage("empty")),
            new CardPosition(7, false, 0, GameScenario.GetCardImage("empty")),
            new CardPosition(8, true, 2, GameScenario.GetCardImage("i")),
            new CardPosition(9, true, 1, GameScenario.GetCardImage("g"))
        };
    }
    
    
}
