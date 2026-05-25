using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FF8Utilities.Web.Models
{
    public class CardViewModel
    {
        public CardViewModel(int index, string cardsToUse, uint rngResult, List<byte[]> headerCards, params CardPosition[] positions)
        {
            Index = index;
            CardsToUse = cardsToUse;
            HeaderCards = headerCards;
            Positions = positions;
            RNGResult = rngResult;
        }

        public string CardsToUse { get; }

        public CardPosition[] Positions { get; }

        public List<byte[]> HeaderCards { get; }

        public int Index { get; }

        public uint RNGResult { get; }
        
    }

    public static class CardViewModelExtensionMethods
    {
        public static List<CardViewModel> EarlyQuistisModels()
        {
            List<CardViewModel> models = new List<CardViewModel>();

            EarlyQuistisPattern[] patterns = EarlyQuistisPattern.OptionsExcludeLate;
            for (int i = 0; i < patterns.Length; i++)
            {
                EarlyQuistisPattern pattern = patterns[i];
                models.Add(new CardViewModel(i + 1,
                    "Funguar, Red Bat, Fastitocalon-F, Caterchipallar, Ifrit",
                    pattern.Result,
                    pattern.HeaderCards.Select(t => GameScenario.GetCardImage(t)).ToList(),
                    pattern.GetCardPositionForQuistisPattern()
                    ));
            }

            return models;
        }

        public static CardViewModel ToCardViewModel(this LateQuistisStrategy strategy)
        {
            var result = uint.Parse(strategy.ResultHex, System.Globalization.NumberStyles.HexNumber);
            return new CardViewModel(strategy.Frame,
                "Funguar, Red Bat, Fastitocalon-F, Caterchipallar, Ifrit",
                result,
                strategy.OpponentCards,
                strategy.Positions.ToArray());
        }
    }
}
