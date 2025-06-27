using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using FF8Utilities.Models.AbilityModels;
using System;
using System.Windows.Media.Media3D;

namespace FF8Utilities.Entities.Encounters.Ifrits_Cavern
{
    public class BuelEncounter : BaseEncounterModel
    {
        public BuelEncounter() : base("Buel", 11, typeof(TwoPersonFanfareCamera))
        {
            Abilities.Add(new EncounterAbilityModel("Buel Attacks", 5));
            Abilities.Add(new SquallAttack());
        }
    }
}
