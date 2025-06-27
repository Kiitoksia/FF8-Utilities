using System;
using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using FF8Utilities.Models.AbilityModels;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class SingleSoldierEncounter : BaseEncounterModel
    {
        public SingleSoldierEncounter(bool hasFanfare) : base("Soldier", 14, hasFanfare ? typeof(ThreePersonFanfareCamera) : null)
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new SeiferAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new SoldierAttack());

            ShowPlusOneToAllButton = true;
        }
    }
}
