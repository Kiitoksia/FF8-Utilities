using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using FF8Utilities.Models.AbilityModels;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class SpiderTankEncounter : BaseEncounterModel
    {
        public SpiderTankEncounter() : base("X-ATM092", 13)
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new Limit(1));
            Abilities.Add(new EncounterAbilityModel("Ray Bomb", 1));

            ToggleOptionDescription = "Extra ATM Encounter";            
        }

        protected override int CustomRNGAddition
        {
            get
            {
                if (IsToggled) return 13;
                return 0;
            }
        }
    }
}
