using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using FF8Utilities.Models.AbilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Entities.Encounters.Diablos
{
    public class DiablosEncounter : BaseEncounterModel
    {

        public DiablosEncounter() : base("Diablos", 13, typeof(ThreePersonFanfareCamera))
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new EncounterAbilityModel("Gravija", 1));
            Abilities.Add(new Limit());
        }
    }
}
