using System;
using System.Collections.Generic;
using System.Text;
using FF8Utilities.Common;

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

        public CardPosition(int position, bool isPlayerTurn, int turn, Card card, string customTopInfo = null, string customRightInfo = null, string customBotInfo = null, string customLeftInfo = null)
            :this(position, isPlayerTurn, turn, GameScenario.GetCardImage(card), customTopInfo, customRightInfo, customBotInfo, customLeftInfo)
        {

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

        public static readonly CardPosition[] EarlyQuistisFrame1 = new[]
        {
            new CardPosition(1, true, 4, Common.Card.Fasticalcon),
            new CardPosition(2, false, 1, Common.Card.Gayla),
            new CardPosition(3, false, 1, Common.Card.Anacondaur),
            new CardPosition(4, false, 3, Common.Card.Elastoid),
            new CardPosition(5, false, 2, Common.Card.Quistis),
            new CardPosition(6, true, 2, Common.Card.Caterchipallar),
            new CardPosition(7, true, 5, Common.Card.Geezard),
            new CardPosition(8, false, 4, Common.Card.Jelleye),
            new CardPosition(9, true, 3, Common.Card.Fungar),
        };

        public static readonly CardPosition[] EarlyQuistisFrame2 = new[]
        {
            new CardPosition(1, false, 5, Common.Card.GrandMantis),
            new CardPosition(2, true, 4, Common.Card.Geezard),
            new CardPosition(3, false, 4, Common.Card.Belhelmel),
            new CardPosition(4, false, 3, Common.Card.Anacondaur),
            new CardPosition(5, false, 2, Common.Card.Quistis),
            new CardPosition(6, true, 1, Common.Card.Fungar),
            new CardPosition(7, false, 1, Common.Card.Malboro),
            new CardPosition(8, true, 3, Common.Card.Fasticalcon),
            new CardPosition(9, true, 2, Common.Card.Gayla)
        };

        public static readonly CardPosition[] EarlyQuistisFrame3 = new[]
        {
            new CardPosition(1, false, 5, Common.Card.Anacondaur),
            new CardPosition(2, false, 4, Common.Card.Jelleye),
            new CardPosition(3, true, 1, Common.Card.Fungar),
            new CardPosition(4, true, 4, Common.Card.Caterchipallar),
            new CardPosition(5, true, 2, Common.Card.Fasticalcon),
            new CardPosition(6, false, 2, Common.Card.Quistis),
            new CardPosition(7, false, 1, Common.Card.BiggsWedge),
            new CardPosition(8, false, 3, Common.Card.Elnoyle),
            new CardPosition(9, true, 3, Common.Card.Gayla)
        };

        public static readonly CardPosition[] EarlyQuistisFrame4 = new[]
        {
            new CardPosition(1, true, 4, Common.Card.Fasticalcon),
            new CardPosition(2, false, 1, Common.Card.TonberryKing),
            new CardPosition(3, true, 1, Common.Card.Caterchipallar),
            new CardPosition(4, false, 3, Common.Card.Elastoid),
            new CardPosition(5, false, 2, Common.Card.Quistis),
            new CardPosition(6, true, 2, Common.Card.Fungar),
            new CardPosition(7, true, 5, Common.Card.Geezard),
            new CardPosition(8, false, 4, Common.Card.Grendel),
            new CardPosition(9, true, 3, Common.Card.Gayla)
        };

        public static readonly CardPosition[] EarlyQuistisFrame7 = new[]
        {
            new CardPosition(1, false, 2, Common.Card.Gim47N),
            new CardPosition(2, true, 4, Common.Card.Fasticalcon),
            new CardPosition(3, false, 5, Common.Card.Grat),
            new CardPosition(4, true, 1, Common.Card.Gayla),
            new CardPosition(5, true, 2, Common.Card.Geezard),
            new CardPosition(6, false, 4, Common.Card.GlacialEye),
            new CardPosition(7, false, 1, Common.Card.Quistis),
            new CardPosition(8, false, 3, Common.Card.GrandMantis),
            new CardPosition(9, true, 3, Common.Card.Caterchipallar)
        };

        public static readonly CardPosition[] EarlyQuistisFrame9 = new[]
        {
            new CardPosition(1, false, 4, Common.Card.Grendel),
            new CardPosition(2, true, 4, Common.Card.Geezard),
            new CardPosition(3, false, 5, Common.Card.Buel),
            new CardPosition(4, false, 1, Common.Card.Quistis),
            new CardPosition(5, true, 1, Common.Card.Fungar),
            new CardPosition(6, false, 2, Common.Card.BiggsWedge),
            new CardPosition(7, true, 3, Common.Card.Fasticalcon),
            new CardPosition(8, true, 2, Common.Card.Gayla),
            new CardPosition(9, false, 3, Common.Card.Jelleye)
        };

        public static readonly CardPosition[] EarlyQuistisFrame10 = new[]
        {
            new CardPosition(1, false, 4, Common.Card.GlacialEye),
            new CardPosition(2, false, 3, Common.Card.Chimera),
            new CardPosition(3, true, 3, Common.Card.Caterchipallar),
            new CardPosition(4, true, 4, Common.Card.Geezard),
            new CardPosition(5, false, 2, Common.Card.Quistis),
            new CardPosition(6, true, 2, Common.Card.Gayla),
            new CardPosition(7, true, 5, Common.Card.Fasticalcon),
            new CardPosition(8, true, 1, Common.Card.Fungar),
            new CardPosition(9, false, 1, Common.Card.Behemoth)
        };
    }        
}
