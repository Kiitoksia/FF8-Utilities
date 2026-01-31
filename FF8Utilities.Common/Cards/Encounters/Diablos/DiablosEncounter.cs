using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF8Utilities;

namespace FF8Utilities.Common.Cards.Encounters.Diablos
{
    public class DiablosEncounter : BaseEncounterModel
    {

        public DiablosEncounter() : base("Diablos", 13, FanfareCamera.ThreePerson.All)
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new EncounterAbilityModel("Gravija", 1));
            Abilities.Add(new Limit());
        }
    }
}
