using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF8Utilities;

namespace FF8Utilities.Common.Cards.Encounters.Diablos
{
    public class GranaldoEncounter : BaseEncounterModel
    {
        public GranaldoEncounter() : base("Granalado", 22, typeof(TwoPersonFanfareCamera))
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new EncounterAbilityModel("Granaldo Attack", 1));
            Abilities.Add(new Limit(1));
            Abilities.Add(new EncounterAbilityModel("Shiva", 1, 1));
        }

    }
}
