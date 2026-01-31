using System;
using System.ComponentModel;

namespace FF8Utilities.Common.Cards.Encounters.IfritsCavern
{
    public class TwoBatsEncounter : BaseEncounterModel
    {
        public TwoBatsEncounter() : base("2x Bats", 15, FanfareCamera.TwoPerson.All)
        {
            Abilities.Add(new SquallAttack());
        }
    }
}
