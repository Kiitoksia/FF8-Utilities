using System;
using FF8Utilities;

namespace FF8Utilities.Common.Cards.Encounters.Dollet
{
    public class ElvoretEncounter : BaseEncounterModel
    {
        public ElvoretEncounter() : base("Elvoret", 16, FanfareCamera.Elvoret.All)
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new EncounterAbilityModel("Biggs Machine Gun", 5));
            Abilities.Add(new EncounterAbilityModel("Biggs Charge", 4));
            Abilities.Add(new EncounterAbilityModel("Wedge Fire", 28));
            Abilities.Add(new EncounterAbilityModel("Elvoret Spell", 12));
            Abilities.Add(new EncounterAbilityModel("Elvoret Storm Breath", 1));
            Abilities.Add(new Limit(4));
        }

        protected override int CustomRNGAddition
        {
            get
            {
                return 3; // Elvoret appearing
            }
        }
    }
}
