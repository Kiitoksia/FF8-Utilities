using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF8Utilities;

namespace FF8Utilities.Common.Cards.Encounters.Dollet
{
    public class TripleSoldierEncounter : BaseEncounterModel
    {
        public TripleSoldierEncounter(string description = "3X Soldier") : base(description, 22, FanfareCamera.ThreePerson.All)
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new SeiferAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new SoldierAttack());

            ShowPlusOneToAllButton = true;
        }
    }
}
