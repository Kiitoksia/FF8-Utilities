using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using FF8Utilities.Models.AbilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class RedSoldierEncounter : BaseEncounterModel
    {
        public RedSoldierEncounter(bool hasFanfare) : base("Elite (Red) Soldier", 13, hasFanfare ? typeof(ThreePersonFanfareCamera) : null)
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new EncounterAbilityModel("Machine Gun", 5));
            Abilities.Add(new EncounterAbilityModel("Charge", 4));
        }
    }
}
