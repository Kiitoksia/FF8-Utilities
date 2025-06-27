using System;
using System.ComponentModel;
using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using FF8Utilities.Models.AbilityModels;

namespace FF8Utilities.Entities.Encounters.Ifrits_Cavern
{
    public class TwoBatsEncounter : BaseEncounterModel
    {
        public TwoBatsEncounter() : base("2x Bats", 15, typeof(TwoPersonFanfareCamera))
        {
            Abilities.Add(new SquallAttack());
        }
    }
}
