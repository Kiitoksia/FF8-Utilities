using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FF8Utilities.Web.Models
{
    public class CardViewModel
    {
        public CardViewModel(int index, string cardsToUse, List<byte[]> headerCards, params CardPosition[] positions)
        {
            Index = index;
            CardsToUse = cardsToUse;
            HeaderCards = headerCards;
            Positions = positions;
        }

        public string CardsToUse { get; }

        public CardPosition[] Positions { get; }

        public List<byte[]> HeaderCards { get; }

        public int Index { get; }

        public static List<CardViewModel> EarlyQuistisModels()
        {
            List<CardViewModel> models = new List<CardViewModel>();

            EarlyQuistisPattern[] patterns = EarlyQuistisPattern.OptionsExcludeLate;
            for (int i = 0; i < patterns.Length; i++)
            {
                EarlyQuistisPattern patern = patterns[i];
                models.Add(new CardViewModel(i + 1,
                    "Funguar, Red Bat, Fastitocalon-F, Caterchipallar, Ifrit",
                    patern.HeaderCards.Select(t => GameScenario.GetCardImage(t)).ToList(),
                    patern.GetCardPositionForQuistisPattern()
                    ));
            }

            return models;
        }
    }
}
