using System;
using FF8Utilities;

namespace FF8Utilities.Common.Cards.Encounters.IfritsCavern
{
    public class BuelEncounter : BaseEncounterModel
    {
        public BuelEncounter() : base("Buel", 11, FanfareCamera.TwoPerson.All)
        {
            Abilities.Add(new EncounterAbilityModel("Buel Attacks", 5));
            Abilities.Add(new SquallAttack());
        }
    }
}
