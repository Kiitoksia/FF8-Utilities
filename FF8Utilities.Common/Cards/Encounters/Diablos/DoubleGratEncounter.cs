using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Common.Cards.Encounters.Diablos
{
    public class DoubleGratEncounter : BaseEncounterModel
    {
        public DoubleGratEncounter() : base("2X Grat", 15)
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new EncounterAbilityModel("Vampire Bites", 33));
            Abilities.Add(new EncounterAbilityModel("Sleeping Gas", 1));
        }
    }
}
