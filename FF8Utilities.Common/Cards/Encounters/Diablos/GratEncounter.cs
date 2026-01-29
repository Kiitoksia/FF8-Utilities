using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF8Utilities;

namespace FF8Utilities.Common.Cards.Encounters.Diablos
{
    public class GratEncounter : BaseEncounterModel
    {
        public GratEncounter() : base("Grat", 11)
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new EncounterAbilityModel("Vampire Bites", 33));
            Abilities.Add(new EncounterAbilityModel("Sleeping Gas", 1));
        }
    }
}
