using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using FF8Utilities.Models.AbilityModels;

namespace FF8Utilities.Entities.Encounters.Ifrits_Cavern
{
    public class IfritEncounter : BaseEncounterModel
    {
        public IfritEncounter() : base("Ifrit", 10)
        {
            Abilities.Add(new Limit());
            Abilities.Add(new SquallAttack());
            Abilities.Add(new EncounterAbilityModel("Ifrit Punches", 2));
        }
    }
}
