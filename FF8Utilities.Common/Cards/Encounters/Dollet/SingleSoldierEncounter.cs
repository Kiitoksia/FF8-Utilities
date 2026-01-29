using System;

namespace FF8Utilities.Common.Cards.Encounters.Dollet
{
    public class SingleSoldierEncounter : BaseEncounterModel
    {
        public SingleSoldierEncounter(bool hasFanfare, string description = "Soldier") : base(description, 14, hasFanfare ? typeof(ThreePersonFanfareCamera) : null)
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new SeiferAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new SoldierAttack());

            ShowPlusOneToAllButton = true;
        }
    }
}
