using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using FF8Utilities.Models.AbilityModels;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class DoubleSoldierEncounter : BaseEncounterModel
    {

        public DoubleSoldierEncounter(bool hasFanfare) : base("2X Soldier", 18, hasFanfare ? typeof(ThreePersonFanfareCamera) : null)
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new SeiferAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new SoldierAttack());

            ShowPlusOneToAllButton = true;
        }
    }
}
